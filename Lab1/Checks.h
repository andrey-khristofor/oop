﻿#pragma once

#include <stdio.h>
#include <stdlib.h>
#include "Slave.h"

int checkFileExistence(FILE* indexTable, FILE* database, char* error)
{
	// DB files do not exist yet
	if (indexTable == NULL || database == NULL)
	{
		strcpy(error, "database files are not created yet");
		return 0;
	}

	return 1;
}

int checkIndexExistence(FILE* indexTable, char* error, int id)
{
	fseek(indexTable, 0, SEEK_END);

	long indexTableSize = ftell(indexTable);

	if (indexTableSize == 0 || id * sizeof(struct Indexer) > indexTableSize)
	{
		strcpy(error, "no such ID in table");
		return 0;
	}

	return 1;
}

int checkRecordExistence(struct Indexer indexer, char* error)
{
	// Record's been removed
	if (!indexer.exists)
	{
		strcpy(error, "the record you\'re looking for has been removed");
		return 0;
	}

	return 1;
}

// !!! WARNING !!!
// This function causes some file flush error and may be actually omitted
// (IRL different supplements may have same kind of product supplied).
// [DEPRECATED]
int checkKeyPairUniqueness(struct Master master, int productId)
{
	FILE* slavesDb = fopen(SLAVE_DATA, "r+b");
	struct Slave slave;

	fseek(slavesDb, master.firstSlaveAddress, SEEK_SET);

	for (int i = 0; i < master.slavesCount; i++)
	{
		fread(&slave, SLAVE_SIZE, 1, slavesDb);
		fclose(slavesDb);

		if (slave.id == productId)
		{
			return 0;
		}

		slavesDb = fopen(SLAVE_DATA, "r+b");
		fseek(slavesDb, slave.nextAddress, SEEK_SET);
	}

	fclose(slavesDb);

	return 1;
}

void info()
{
	FILE* indexTable = fopen("master.ind", "rb");

	if (indexTable == NULL)
	{
		printf("Error: database files are not created yet\n");
		return;
	}

	int masterCount = 0;
	int slaveCount = 0;

	fseek(indexTable, 0, SEEK_END);
	int indAmount = ftell(indexTable) / sizeof(struct Indexer);

	struct Master master;

	char dummy[51];

	for (int i = 1; i <= indAmount; i++)
	{
		if (getMaster(&master, i, dummy))
		{
			masterCount++;
			slaveCount += master.slavesCount;

			printf("Master #%d has %d slave(s)\n", i, master.slavesCount);
		}
	}

	fclose(indexTable);

	printf("Total masters: %d\n", masterCount);
	printf("Total slaves: %d\n", slaveCount);
}

