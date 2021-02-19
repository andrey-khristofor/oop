#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "Structures.h"
#include "Master.h"
#include "Slave.h"
#include "Input.h"
#include "Output.h"

struct Master master;
struct Slave slave;

char choice[10];
int id;
char error[51];


void insert_m()
{
	readMaster(&master);
	insertMaster(master);
}

void insert_s()
{
	printf("Enter master\'s ID: ");
	scanf("%d", &id);

	if (getMaster(&master, id, error))
	{
		slave.masterId = id;
		printf("Enter car ID: ");
		scanf("%d", &id);

		slave.id = id;
		readSlave(&slave);
		insertSlave(master, slave, error);
		printf("Inserted successfully. To access, use master\'s and car\'s IDs\n");
	}
	else
	{
		printf("Error: %s\n", error);
	}
}

void get_m()
{
	printf("Enter ID: ");
	scanf("%d", &id);
	getMaster(&master, id, error) ? printMaster(master) : printf("Error: %s\n", error);
}

void get_s()
{
	printf("Enter master\'s ID: ");
	scanf("%d", &id);

	if (getMaster(&master, id, error))
	{
		printf("Enter car ID: ");
		scanf("%d", &id);
		getSlave(master, &slave, id, error) ? printSlave(slave, master) : printf("Error: %s\n", error);
	}
	else
	{
		printf("Error: %s\n", error);
	}
}

void update_m()
{
	printf("Enter ID: ");
	scanf("%d", &id);

	master.id = id;

	readMaster(&master);
	updateMaster(master, error) ? printf("Updated successfully\n") : printf("Error: %s\n", error);
}

void update_s()
{
	printf("Enter master\'s ID: ");
	scanf("%d", &id);

	if (getMaster(&master, id, error))
	{
		printf("Enter car ID: ");
		scanf("%d", &id);

		if (getSlave(master, &slave, id, error))
		{
			readSlave(&slave);
			updateSlave(slave, id);
			printf("Updated successfully\n");
		}
		else
		{
			printf("Error: %s\n", error);
		}
	}
	else
	{
		printf("Error: %s\n", error);
	}
}

void delete_m()
{
	printf("Enter ID: ");
	scanf("%d", &id);
	deleteMaster(id, error) ? printf("Deleted successfully\n") : printf("Error: %s\n", error);
}

void delete_s()
{
	printf("Enter master\'s ID: ");
	scanf("%d", &id);

	if (getMaster(&master, id, error))
	{
		printf("Enter car ID: ");
		scanf("%d", &id);

		if (getSlave(master, &slave, id, error))
		{
			deleteSlave(master, slave, id, error);
			printf("Deleted successfully\n");
		}
		else
		{
			printf("Error: %s\n", error);
		}
	}
	else
	{
		printf("Error: %s\n", error);
	}
}

void ut_m()
{
	FILE* indexTable = fopen(MASTER_IND, "rb");				
	FILE* database = fopen(MASTER_DATA, "rb");				

	if (!checkFileExistence(indexTable, database, error))
	{
		return 0;
	}
	
	struct Indexer indexer;
	
	
	while (fread(&indexer, INDEXER_SIZE, 1, indexTable)) {
		getMaster(&master, indexer.id, error);
		printf("Does exist: %d",indexer.exists);
		printf(". ID: %d", indexer.id);
		printf(". Name: %s", master.name);
		printf(". Surname: %s", master.surname);
		printf(". Slaves quantity: %d", master.slavesCount);
		printf(".\n");
	}

	fclose(indexTable);									
	fclose(database);
}

void ut_s()
{
	FILE* database = fopen(SLAVE_DATA, "a+b");
	FILE* garbageZone = fopen(SLAVE_GARBAGE, "rb");
	
	struct Slave current;

	while (fread(&current, SLAVE_SIZE, 1, database)) {
		getMaster(&master, current.masterId, error);
		printf("Does exist: %d", current.exists);
		printf(". ID: %d", current.id);
		printf(". Brand: %s", current.brand);
		printf(". Model: %s", current.model);
		printf(". Master's name: %s", master.name);
		printf(". Master's surname: %s", master.surname);
		printf(". Master's ID: %d", master.id);
		printf("\n");
	}
	fclose(database);											

	master.slavesCount++;										
	updateMaster(master, error);
}

void execute(char str[])
{
	if (strcmp(str, "insert_m") == 0) { insert_m(); }
	if (strcmp(str, "insert_s") == 0) { insert_s(); }
	if (strcmp(str, "get_m") == 0) { get_m(); }
	if (strcmp(str, "get_s") == 0) { get_s(); }
	if (strcmp(str, "update_m") == 0) { update_m(); }
	if (strcmp(str, "update_s") == 0) { update_s(); }
	if (strcmp(str, "delete_m") == 0) { delete_m(); }
	if (strcmp(str, "delete_s") == 0) { delete_s(); }
	if (strcmp(str, "ut_m") == 0) { ut_m(); }
	if (strcmp(str, "ut_s") == 0) { ut_s(); }
	if (strcmp(str, "info") == 0) { info(); }
}

void readAndExecute()
{
	FILE* commands = fopen("commands.txt", "r+");
	char current[10];
	while (fscanf(commands, "%s", &current))
	{
		printf(current);
		printf("\n");
		execute(current);
	}

}