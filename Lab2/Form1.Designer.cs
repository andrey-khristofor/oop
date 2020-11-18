namespace Lab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Linq = new System.Windows.Forms.RadioButton();
            this.Dom = new System.Windows.Forms.RadioButton();
            this.Sax = new System.Windows.Forms.RadioButton();
            this.Brand = new System.Windows.Forms.ComboBox();
            this.BrandCheck = new System.Windows.Forms.CheckBox();
            this.Model = new System.Windows.Forms.ComboBox();
            this.ModelCheck = new System.Windows.Forms.CheckBox();
            this.YearCheck = new System.Windows.Forms.CheckBox();
            this.VolumeCheck = new System.Windows.Forms.CheckBox();
            this.Color = new System.Windows.Forms.ComboBox();
            this.ColorCheck = new System.Windows.Forms.CheckBox();
            this.PriceCheck = new System.Windows.Forms.CheckBox();
            this.Find = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.CarInfo = new System.Windows.Forms.RichTextBox();
            this.LowerVolume = new System.Windows.Forms.TextBox();
            this.HigherVolume = new System.Windows.Forms.TextBox();
            this.LowerYear = new System.Windows.Forms.ComboBox();
            this.HigherYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HigherPrice = new System.Windows.Forms.TextBox();
            this.LowerPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Трансформ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Linq
            // 
            this.Linq.AutoSize = true;
            this.Linq.Location = new System.Drawing.Point(24, 327);
            this.Linq.Name = "Linq";
            this.Linq.Size = new System.Drawing.Size(106, 24);
            this.Linq.TabIndex = 0;
            this.Linq.TabStop = true;
            this.Linq.Text = "Linq to Xml";
            this.Linq.UseVisualStyleBackColor = true;
            // 
            // Dom
            // 
            this.Dom.AutoSize = true;
            this.Dom.Location = new System.Drawing.Point(136, 327);
            this.Dom.Name = "Dom";
            this.Dom.Size = new System.Drawing.Size(65, 24);
            this.Dom.TabIndex = 1;
            this.Dom.TabStop = true;
            this.Dom.Text = "DOM";
            this.Dom.UseVisualStyleBackColor = true;
            // 
            // Sax
            // 
            this.Sax.AutoSize = true;
            this.Sax.Location = new System.Drawing.Point(207, 327);
            this.Sax.Name = "Sax";
            this.Sax.Size = new System.Drawing.Size(57, 24);
            this.Sax.TabIndex = 2;
            this.Sax.TabStop = true;
            this.Sax.Text = "SAX";
            this.Sax.UseVisualStyleBackColor = true;
            // 
            // Brand
            // 
            this.Brand.FormattingEnabled = true;
            this.Brand.Location = new System.Drawing.Point(161, 75);
            this.Brand.Name = "Brand";
            this.Brand.Size = new System.Drawing.Size(246, 28);
            this.Brand.TabIndex = 3;
            this.Brand.SelectedIndexChanged += new System.EventHandler(this.Brand_TextUpdate);
            this.Brand.TextUpdate += new System.EventHandler(this.Brand_TextUpdate);
            // 
            // BrandCheck
            // 
            this.BrandCheck.AutoSize = true;
            this.BrandCheck.Location = new System.Drawing.Point(24, 77);
            this.BrandCheck.Name = "BrandCheck";
            this.BrandCheck.Size = new System.Drawing.Size(76, 24);
            this.BrandCheck.TabIndex = 4;
            this.BrandCheck.Text = "Марка";
            this.BrandCheck.UseVisualStyleBackColor = true;
            // 
            // Model
            // 
            this.Model.FormattingEnabled = true;
            this.Model.Location = new System.Drawing.Point(161, 109);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(246, 28);
            this.Model.TabIndex = 3;
            // 
            // ModelCheck
            // 
            this.ModelCheck.AutoSize = true;
            this.ModelCheck.Location = new System.Drawing.Point(24, 111);
            this.ModelCheck.Name = "ModelCheck";
            this.ModelCheck.Size = new System.Drawing.Size(85, 24);
            this.ModelCheck.TabIndex = 4;
            this.ModelCheck.Text = "Модель";
            this.ModelCheck.UseVisualStyleBackColor = true;
            // 
            // YearCheck
            // 
            this.YearCheck.AutoSize = true;
            this.YearCheck.Location = new System.Drawing.Point(24, 182);
            this.YearCheck.Name = "YearCheck";
            this.YearCheck.Size = new System.Drawing.Size(108, 24);
            this.YearCheck.TabIndex = 4;
            this.YearCheck.Text = "Рік випуску";
            this.YearCheck.UseVisualStyleBackColor = true;
            // 
            // VolumeCheck
            // 
            this.VolumeCheck.AutoSize = true;
            this.VolumeCheck.Location = new System.Drawing.Point(24, 216);
            this.VolumeCheck.Name = "VolumeCheck";
            this.VolumeCheck.Size = new System.Drawing.Size(131, 24);
            this.VolumeCheck.TabIndex = 4;
            this.VolumeCheck.Text = "Об\'єм двигуна";
            this.VolumeCheck.UseVisualStyleBackColor = true;
            // 
            // Color
            // 
            this.Color.FormattingEnabled = true;
            this.Color.Location = new System.Drawing.Point(161, 143);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(246, 28);
            this.Color.TabIndex = 3;
            // 
            // ColorCheck
            // 
            this.ColorCheck.AutoSize = true;
            this.ColorCheck.Location = new System.Drawing.Point(24, 145);
            this.ColorCheck.Name = "ColorCheck";
            this.ColorCheck.Size = new System.Drawing.Size(70, 24);
            this.ColorCheck.TabIndex = 4;
            this.ColorCheck.Text = "Колір";
            this.ColorCheck.UseVisualStyleBackColor = true;
            // 
            // PriceCheck
            // 
            this.PriceCheck.AutoSize = true;
            this.PriceCheck.Location = new System.Drawing.Point(24, 250);
            this.PriceCheck.Name = "PriceCheck";
            this.PriceCheck.Size = new System.Drawing.Size(63, 24);
            this.PriceCheck.TabIndex = 4;
            this.PriceCheck.Text = "Ціна";
            this.PriceCheck.UseVisualStyleBackColor = true;
            // 
            // Find
            // 
            this.Find.Location = new System.Drawing.Point(24, 383);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(108, 55);
            this.Find.TabIndex = 5;
            this.Find.Text = "Знайти";
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(161, 383);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(108, 55);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Очистити";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // CarInfo
            // 
            this.CarInfo.Location = new System.Drawing.Point(413, 12);
            this.CarInfo.Name = "CarInfo";
            this.CarInfo.Size = new System.Drawing.Size(375, 426);
            this.CarInfo.TabIndex = 6;
            this.CarInfo.Text = "";
            // 
            // LowerVolume
            // 
            this.LowerVolume.Location = new System.Drawing.Point(200, 213);
            this.LowerVolume.Name = "LowerVolume";
            this.LowerVolume.Size = new System.Drawing.Size(74, 27);
            this.LowerVolume.TabIndex = 7;
            // 
            // HigherVolume
            // 
            this.HigherVolume.Location = new System.Drawing.Point(333, 213);
            this.HigherVolume.Name = "HigherVolume";
            this.HigherVolume.Size = new System.Drawing.Size(74, 27);
            this.HigherVolume.TabIndex = 7;
            // 
            // LowerYear
            // 
            this.LowerYear.FormattingEnabled = true;
            this.LowerYear.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            ""});
            this.LowerYear.Location = new System.Drawing.Point(200, 179);
            this.LowerYear.Name = "LowerYear";
            this.LowerYear.Size = new System.Drawing.Size(74, 28);
            this.LowerYear.TabIndex = 3;
            // 
            // HigherYear
            // 
            this.HigherYear.FormattingEnabled = true;
            this.HigherYear.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            ""});
            this.HigherYear.Location = new System.Drawing.Point(333, 177);
            this.HigherYear.Name = "HigherYear";
            this.HigherYear.Size = new System.Drawing.Size(74, 28);
            this.HigherYear.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Від:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "До:";
            // 
            // HigherPrice
            // 
            this.HigherPrice.Location = new System.Drawing.Point(333, 247);
            this.HigherPrice.Name = "HigherPrice";
            this.HigherPrice.Size = new System.Drawing.Size(74, 27);
            this.HigherPrice.TabIndex = 7;
            // 
            // LowerPrice
            // 
            this.LowerPrice.Location = new System.Drawing.Point(200, 246);
            this.LowerPrice.Name = "LowerPrice";
            this.LowerPrice.Size = new System.Drawing.Size(74, 27);
            this.LowerPrice.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Від:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "До:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "До:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Від:";
            // 
            // Трансформ
            // 
            this.Трансформ.Location = new System.Drawing.Point(296, 383);
            this.Трансформ.Name = "Трансформ";
            this.Трансформ.Size = new System.Drawing.Size(108, 55);
            this.Трансформ.TabIndex = 5;
            this.Трансформ.Text = "Трансформувати в HTML";
            this.Трансформ.UseVisualStyleBackColor = true;
            this.Трансформ.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Трансформ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LowerPrice);
            this.Controls.Add(this.HigherPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HigherYear);
            this.Controls.Add(this.LowerYear);
            this.Controls.Add(this.HigherVolume);
            this.Controls.Add(this.LowerVolume);
            this.Controls.Add(this.CarInfo);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Find);
            this.Controls.Add(this.PriceCheck);
            this.Controls.Add(this.ColorCheck);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.VolumeCheck);
            this.Controls.Add(this.YearCheck);
            this.Controls.Add(this.ModelCheck);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.BrandCheck);
            this.Controls.Add(this.Brand);
            this.Controls.Add(this.Sax);
            this.Controls.Add(this.Dom);
            this.Controls.Add(this.Linq);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Linq;
        private System.Windows.Forms.RadioButton Dom;
        private System.Windows.Forms.RadioButton Sax;
        private System.Windows.Forms.ComboBox Brand;
        private System.Windows.Forms.CheckBox BrandCheck;
        private System.Windows.Forms.ComboBox Model;
        private System.Windows.Forms.CheckBox ModelCheck;
        private System.Windows.Forms.CheckBox YearCheck;
        private System.Windows.Forms.CheckBox VolumeCheck;
        private System.Windows.Forms.ComboBox Color;
        private System.Windows.Forms.CheckBox ColorCheck;
        private System.Windows.Forms.CheckBox PriceCheck;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.RichTextBox CarInfo;
        private System.Windows.Forms.TextBox LowerVolume;
        private System.Windows.Forms.TextBox HigherVolume;
        private System.Windows.Forms.ComboBox LowerYear;
        private System.Windows.Forms.ComboBox HigherYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HigherPrice;
        private System.Windows.Forms.TextBox LowerPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Трансформ;
    }
}

