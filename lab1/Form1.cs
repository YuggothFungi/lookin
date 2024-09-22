using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateRegister_Click(object sender, EventArgs e)
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            AutoRegister[] autoreg = new AutoRegister[10000];
            Random rndNumber = new Random();

            for (int i = 0; i < 10000; i++)
            {    
                string owner = "Владелец" + i.ToString();
                string number = "А" + rndNumber.Next(100, 1000).ToString() + "МВ" + rndNumber.Next(10, 100).ToString();
                autoreg[i] = new AutoRegister();
                autoreg[i].Number = number;
                autoreg[i].Model = "Форд";
                autoreg[i].IssueDate = 19920701;
                autoreg[i].SellDate = 20030802;
                autoreg[i].Color = "Зелёный";
                autoreg[i].Owner = owner;
            }
            label11.Text = autoreg[5].Number + " " + autoreg[5].Model + " " + autoreg[5].Owner;
            label12.Text = autoreg[150].Number + " " + autoreg[150].Model + " " + autoreg[150].Owner;
            label13.Text = autoreg[1500].Number + " " + autoreg[1500].Model + " " + autoreg[1500].Owner;

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("autoregister.dat", FileMode.Append))
            {
                formatter.Serialize(fs, autoreg);
                fs.Close();
            }

            long length = new System.IO.FileInfo("autoregister.dat").Length;
            label9.Text = (length / 1024).ToString() + " КБ";

        }

        private void CreateIndex_Click(object sender, EventArgs e)
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();

            // десериализация из файла
            using (FileStream fs = new FileStream("autoregister.dat", FileMode.Open))
            {
                AutoRegister[] loadedRegister = (AutoRegister[])formatter.Deserialize(fs);
                ARIndex[] index = new ARIndex[10000];
                var i = 0;

                foreach (AutoRegister ar in loadedRegister)
                {
                    index[i] = new ARIndex();
                    index[i].arNumber = ar.Number;
                    index[i].arAddress = fs.Position;
                    i++;
                }

                label11.Text = index[5].arAddress.ToString() + " " + index[5].arNumber;
                label12.Text = index[150].arAddress.ToString() + " " + index[150].arNumber;
                label13.Text = index[1500].arAddress.ToString() + " " + index[1500].arNumber;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IndexSearch_Click(object sender, EventArgs e)
        {
            label11.Text = "text";
        }
    }
}
