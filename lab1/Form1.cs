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
    class AutoRegister
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public int IssueDate { get; set; }
        public int SellDate { get; set; }
        public string Color { get; set; }
        public string Owner { get; set; }


        public AutoRegister(string number, string model, int issueDate, int sellDate, string color, string owner)
        {
            Number = number; Model = model; IssueDate = issueDate; SellDate = sellDate; Color = color; Owner = owner;
        }
        public AutoRegister()
        {
            Number = ""; Model = ""; IssueDate = 0; SellDate = 0; Color = ""; Owner = "";
        }
        public void WriteAutoRegisterToBinaryFile(string fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Append)))
            {
                // Записываем поля класса в файл
                writer.Write(this.Number);
                writer.Write(this.Model);
                writer.Write(this.IssueDate);
                writer.Write(this.SellDate);
                writer.Write(this.Color);
                writer.Write(this.Owner);
            }
        }       
    }

    class AutoManager
    {
        private HashSet<string> existingIds = new HashSet<string>();
        private Random random = new Random();

        public AutoRegister CreateUniqueItem()
        {
            string number;

            // Генерируем уникальный Number
            do
            {
                number = "А" + random.Next(100, 1000).ToString() + "МВ" + random.Next(10, 100).ToString(); ; // Генерация случайного Number
            } while (!existingIds.Add(number)); // Проверка на уникальность

            return new AutoRegister(number, "Форд", 19920701, 20030802, "Зелёный", "Владелец");
        }

        public AutoRegister ReadOneFromBinaryFile(string fileName)
        {
            AutoRegister readAuto = new AutoRegister();
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                readAuto.Number = reader.ReadString();
                readAuto.Model = reader.ReadString();
                readAuto.IssueDate = reader.ReadInt32();
                readAuto.SellDate = reader.ReadInt32();
                readAuto.Color = reader.ReadString();
                readAuto.Owner = reader.ReadString();
            }

            return readAuto;
        }

        public AutoRegister[] ReadAllFromBinaryFile(string fileName)
        {
            int i = 0;
            List<AutoRegister> list = new List<AutoRegister>();
            list[i] = new AutoRegister();

            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new BinaryReader(stream))
            {
                bool endOfStream = stream.Position == stream.Length;
                while (!endOfStream)
                {
                    list[i] = ReadOneFromBinaryFile(fileName);
                    i++;
                }
            }
            return list.ToArray();  
        }
    }

    class ARIndex
    {
        public string arNumber { get; set; }
        public long arAddress { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateRegister_Click(object sender, EventArgs e)
        {
            AutoManager autoManager = new AutoManager();
            AutoRegister auto = autoManager.CreateUniqueItem();
            auto.WriteAutoRegisterToBinaryFile("autoregister.dat");

            label11.Text = auto.Number + " " + auto.Model + " " + auto.Owner;

            // 61Б на одну запись
            long length = new System.IO.FileInfo("autoregister.dat").Length;
            label9.Text = length.ToString() + " Б";

        }

        private void CreateIndex_Click(object sender, EventArgs e)
        {
            AutoManager autoManager = new AutoManager();
            AutoRegister[] auto = autoManager.ReadAllFromBinaryFile("autoregister.dat");
            label12.Text = auto[1].Number + " " + auto[1].Model + " " + auto[1].Owner;
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
