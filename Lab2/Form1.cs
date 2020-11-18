using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public string path = @"C:\Users\Andrey\Desktop\ООП Христофор\Lab2.1\XMLCar.xml";
        Dictionary<string, SortedSet<string>> modelList = new Dictionary<string, SortedSet<string>>();
        public Form1()
        {
            InitializeComponent();
            GetAllCars();
            Model.Enabled = false;
            ModelCheck.Enabled = false;
        }
        
        public void GetAllCars()
        {
            string currBrand;
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlElement xRoot = doc.DocumentElement;
            foreach (XmlNode n in xRoot.ChildNodes)
            {
                foreach (XmlNode a in n.ChildNodes)
                {
                    currBrand = n.Attributes[0].Value;
                    if (!Brand.Items.Contains(currBrand)) Brand.Items.Add(currBrand);

                    if (modelList.ContainsKey(currBrand))
                        modelList[currBrand].Add(a.Attributes[0].Value);
                    else
                    {
                        SortedSet<string> x = new SortedSet<string>();
                        x.Add(a.Attributes[0].Value);
                        modelList[currBrand] = x;
                    }
                    if (!Color.Items.Contains(a.Attributes[4].Value)) Color.Items.Add(a.Attributes[4].Value);
                }
            }
        }

        private void PrintInfo(List<Car> lis)
        {
            CarInfo.Text = "";
            foreach (Car car in lis)
            {
                CarInfo.Text += "Марка: " + car.brand + '\n';
                CarInfo.Text += "Модель: " + car.model + '\n';
                CarInfo.Text += "Рік випуску: " + car.year + '\n';
                CarInfo.Text += "Об'єм двигуна: " + car.volume + '\n';
                CarInfo.Text += "Колір: " + car.color + '\n';
                CarInfo.Text += "Ціна: " + car.price + '\n';
                CarInfo.Text += "\n\n";
            }
        }

        private CarSearch FindParams()
        {
            CarSearch car = new CarSearch();
            if (BrandCheck.Checked) { car.brand = Brand.Text; }
            if (ModelCheck.Checked) { car.model = Model.Text; }
            if (ColorCheck.Checked) { car.color = Color.Text; }
            if (PriceCheck.Checked)
            {
                if (LowerPrice.Text != "") { car.lowPrice = Convert.ToInt32(LowerPrice.Text); }
                if (HigherPrice.Text != "") { car.highPrice = Convert.ToInt32(HigherPrice.Text); }
            }
            if (VolumeCheck.Checked)
            {
                if (LowerVolume.Text != "") { car.lowVolume = Convert.ToDouble(LowerVolume.Text); }
                if (HigherVolume.Text != "") { car.highVolume = Convert.ToDouble(HigherVolume.Text); }
            }
            if (YearCheck.Checked)
            {
                if (LowerYear.Text != "") { car.lowYear = Convert.ToInt32(LowerYear.Text); }
                if (HigherYear.Text != "") { car.highYear = Convert.ToInt32(HigherYear.Text); }
            }

            return car;
        }

        private void Find_Click(object sender, EventArgs e)
        {
            LINQtoXML d = new LINQtoXML();
            CarSearch c = FindParams();
            List<Car> list = d.Search(c);
            PrintInfo(list);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            CarInfo.Text = "";
            Brand.Text = "";
            Model.Text = "";
            Color.Text = "";
            LowerYear.Text = "";
            HigherYear.Text = "";
            LowerPrice.Text = "";
            HigherPrice.Text = "";
            LowerVolume.Text = "";
            HigherVolume.Text = "";
            BrandCheck.Checked = false;
            ModelCheck.Checked = false;
            YearCheck.Checked = false;
            ColorCheck.Checked = false;
            PriceCheck.Checked = false;
            VolumeCheck.Checked = false;
        }

        private void Brand_TextUpdate(object sender, EventArgs e)
        {
            if (Brand.Text != "")
            {
                Model.Enabled = true;
                ModelCheck.Enabled = true;
                Model.Items.Clear();
                foreach (string str in modelList[Brand.Text])
                {
                    Model.Items.Add(str);
                }
            }
            else
            {
                Model.Enabled = false;
                ModelCheck.Enabled = false;
                ModelCheck.Checked = false;
                Model.Items.Clear();
            }
        }
    }
    
}
