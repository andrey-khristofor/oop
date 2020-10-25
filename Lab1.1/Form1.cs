using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace Lab1._1
{
    public partial class Form1 : Form
    {
        bool IsSaved = true;
        Parser calculate = new Parser();
        Dictionary<string, double> ValueList = new Dictionary<string, double> { };
        Dictionary<string, string> FormulaList = new Dictionary<string, string> { };
        int ColNumber = 1, RowNumber = 1;
        new string Name; 
        string Expression;

        
        public Form1()
        {
            InitializeComponent();
            Table.Rows.Add(Convert.ToString(RowNumber), "");
            LoadSaved();
            IsSaved = true;
        }

        void DeleteLastRow()
        {
            if (RowNumber < 1) { return; }
            Table.Rows.RemoveAt(RowNumber - 1);
            Table.Refresh();
            RowNumber--;

            IsSaved = false;
        }

        void DeleteLastCol()
        {
            if (ColNumber < 1) { return; }
            Table.Columns.RemoveAt(ColNumber);
            Table.Refresh();
            ColNumber--;

            IsSaved = false;
        }

        void DeleteTable()
        {
            IsSaved = false;
            Table.Rows.Clear();
            Table.Columns.Clear();
            ColNumber = 0;
            RowNumber = 0;
            Table.Columns.Add("", "");
            calculate.Vars.Clear();
            FormulaList.Clear();
        }

        void LoadSaved()
        {
            Open.DropDownItems.Clear();
            string s;
            int z;
            StreamReader sr = new StreamReader("saves.txt");
            while ((s = sr.ReadLine()) != null)
            {
                if (s.Contains("FILE"))
                {
                    s = s.Replace("FILE ", "");
                    ToolStripMenuItem x = new ToolStripMenuItem(s, null, new EventHandler(Open1_Click));
                    x.Tag = s;
                    z = Open.DropDownItems.Add(x);
                }
            }
            sr.Close();
        }

        private void Open1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            string args = menuItem.Tag.ToString();


            if (IsSaved != true)
            {
                DialogResult res = MessageBox.Show("Файл не збережено.\nЗавантажити інший?", "", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    LoadTable(args);
                }
            }
            else LoadTable(args);
            IsSaved = true;
        }

        private void LoadTable(string str)
        {
            string s;
            DeleteTable();
            StreamReader sr = new StreamReader("saves.txt");
            while ((s = sr.ReadLine()) != null)
            {
                if (s == "FILE " + str)
                {
                    s = sr.ReadLine();
                    s = sr.ReadLine();
                    ColNumber = Convert.ToInt32(s);
                    s = sr.ReadLine();
                    s = sr.ReadLine();
                    RowNumber = Convert.ToInt32(s);
                    

                    for (int i = 0; i < ColNumber; i++)
                    {
                        string c = Convert.ToString((char)(i + 65));
                        Table.Columns.Add(c, c);
                    }

                    for (int i = 0; i < RowNumber; i++)
                    {
                        Table.Rows.Add(Convert.ToString(i + 1), "");
                    }


                    s = sr.ReadLine();
                    while ((s = sr.ReadLine()) != "__________")
                    {
                        if (s == "Expressions") continue;
                        Name = Convert.ToString(s[0]) + Convert.ToString(s[1]) + Convert.ToString(s[2]);
                        Name = Name.Replace(" ", "");
                        s = s.Replace(Name + " # ", "");
                        try
                        {
                            ValueList[Name] = Convert.ToDouble(s);
                            Expression = Name + " # " + s;
                            ValueList[Name] = calculate.Evaluate(Expression);
                        }
                        catch (Exception)
                        {
                            FormulaList[Name] = s;
                            Expression = Name + " # " + FormulaList[Name];
                            ValueList[Name] = calculate.Evaluate(Expression);
                        }
                    }

                    

                    Reset();
                    break;
                }

            }
            sr.Close();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            
        }

        void Reset()
        {
            IsSaved = false;
            for (int i = 0; i <= ColNumber; i++)
            {
                for (int j = 0; j <= RowNumber; j++)
                {
                    Name = MakeName(i, j);
                    if (FormulaList.ContainsKey(Name))
                    {
                        Expression = Name + " # " + FormulaList[Name];
                        ValueList[Name] = calculate.Evaluate(Expression);
                        Table[i, j].Value = ValueList[Name];
                    }
                    if (ValueList.ContainsKey(Name))
                    {
                        Table[i, j].Value = ValueList[Name];
                    }
                }
            }
        }

        private string MakeName(int Col, int Row)
        {
            //return Convert.ToString(Table[Col, 0].Value) + Convert.ToString(Table[0, Row].Value);
            return Convert.ToString((char)(Col + 64)) + Convert.ToString(Row + 1);
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            IsSaved = false;
            RowNumber++;
            Table.Rows.Add(Convert.ToString(RowNumber), "");
        }

        private void Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            IsSaved = false;
            DeleteLastRow();
            Reset();
        }

        private void Formula_TextChanged(object sender, EventArgs e)
        {
        }

        private void DeleteCol_Click(object sender, EventArgs e)
        {
            IsSaved = false;
            DeleteLastCol();
        }

        private void Table_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (FormulaList.ContainsKey(MakeName(e.ColumnIndex, e.RowIndex)))
                Formula.Text = FormulaList[MakeName(e.ColumnIndex, e.RowIndex)];
            else Formula.Text = "";
        }

        private void Table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            IsSaved = false;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string s = Convert.ToString(Table[e.ColumnIndex, e.RowIndex].Value);
                Name = MakeName(e.ColumnIndex, e.RowIndex);
                try
                {
                    ValueList[Name] = Convert.ToDouble(s);
                    Expression = Name + " # " + s;
                    ValueList[Name] = calculate.Evaluate(Expression);
                }
                catch (Exception)
                {
                    FormulaList[Name] = s;
                    Expression = Name + " # " + FormulaList[Name];
                    ValueList[Name] = calculate.Evaluate(Expression);
                    Table[e.ColumnIndex, e.RowIndex].Value = ValueList[Name];
                }
                Reset();
            }
        }

        private void File_Click(object sender, EventArgs e)
        {

        }

        private void Table_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (FormulaList.ContainsKey(MakeName(e.ColumnIndex, e.RowIndex)))
                Formula.Text = FormulaList[MakeName(e.ColumnIndex, e.RowIndex)];
            else Formula.Text = "";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            IsSaved = false;
        DialogResult res = MessageBox.Show("Ви впевнені, що хочете очистити таблицю?", "", MessageBoxButtons.YesNo);
        if (res == DialogResult.Yes)
            DeleteTable();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSaved != true)
            {
                DialogResult res = MessageBox.Show("Файл не збережено.\nВийти?", "", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) { e.Cancel = true; }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string FileName = Interaction.InputBox("Збереження", "Введіть назву таблиці");
            if (FileName == "") { return; }
            IsSaved = true;
            StreamWriter sw = new StreamWriter("saves.txt",true);
            sw.WriteLine("FILE " + FileName);
            sw.WriteLine("Columns :\n" + ColNumber + "\nRows :\n" + RowNumber);
            sw.WriteLine("Values");
            for (int i = 0; i <= ColNumber; i++)
            {
                for (int j = 0; j <= RowNumber; j++)
                {
                    Name = MakeName(i, j);
                    if (calculate.Vars.ContainsKey(Name))
                    {
                        sw.WriteLine(Name + " # " + calculate.Vars[Name]);
                    }
                }
            }
            sw.WriteLine("Expressions");
            for (int i = 0; i <= ColNumber; i++)
            {
                for (int j = 0; j <= RowNumber; j++)
                {
                    Name = MakeName(i, j);
                    if (FormulaList.ContainsKey(Name))
                    {
                        sw.WriteLine(Name + " # " + FormulaList[Name]);
                    }
                }
            }
            sw.WriteLine("__________");
            sw.Close();
            LoadSaved();
        }

        private void DeleteSaved_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Ви впевнені, що хочете \nвидалити всі збереження?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes) { StreamWriter sw = new StreamWriter("saves.txt", false); sw.Close(); }
            
        }

        private void довідкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Лабораторна робота №1 \nВиконав студент групи К-25 Христофор Андрій\nВаріант 57\n\nТехнічна довідка:\nПрограма підтримує бінарні операції(+,-,*,/), =,<,>,<=,>=,<>,not,and,or\nДля запису виразу у клітинку достатньо написати його значення або формулу без дорівнює(наприклад \"125\",\"B4 + C7 * E1\")");
        }

        private void AddCol_Click(object sender, EventArgs e)
        {
            IsSaved = false;
            ColNumber++;
            string s = Convert.ToString((char)(ColNumber + 64));
            Table.Columns.Add(s,s);
        }
    }
}
