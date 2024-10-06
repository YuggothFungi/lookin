using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        static string FILE_NAME = "autoregister.dat";
        static int RECORD_SIZE = 61; // 61Б на одну запись
        static long length;
        static long numberOfRecords;
        ARIndex[] register;
        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateRegister_Click(object sender, EventArgs e)
        {
            AutoManager autoManager = new AutoManager();
            for (int i = 0; i < 1000; i++)
            {
                AutoRegister auto = autoManager.CreateUniqueItem();
                auto.WriteAutoRegisterToBinaryFile(FILE_NAME);

                if (i == 5)
                {
                    label11.Text = auto.Number + " " + auto.Model + " " + auto.Owner;
                }
            }
            
            length = GetFileLength(FILE_NAME);
            numberOfRecords = GetNumberOfRecords(FILE_NAME);
            label9.Text = (GetFileLength(FILE_NAME) / 1024).ToString() + " МБ";
            register = new ARIndex[numberOfRecords];
        }

        private void CreateIndex_Click(object sender, EventArgs e)
        {
            AutoManager autoManager = new AutoManager();
           
            for (int i=0; i < numberOfRecords; i+=1)
            {
                AutoRegister auto = autoManager.ReadOneFromBinaryFile(FILE_NAME, i*RECORD_SIZE);
                register[i] = new ARIndex { ArNumber = auto.Number, ArAddress = i*RECORD_SIZE };                
            }

            label12.Text = register[2].ArNumber + " " + register[2].ArAddress;
            Array.Sort(register, (x, y) => x.ArNumber.CompareTo(y.ArNumber));
            label13.Text = register[2].ArNumber + " " + register[2].ArAddress;
            


        }

        private static long GetFileLength(string file)
        {
            long length = new System.IO.FileInfo(file).Length;
            return length;
        }

        private long GetNumberOfRecords(string file)
        {
            long numberOfRecords = GetFileLength(file) / RECORD_SIZE;
            return numberOfRecords;
        }

        private void IndexSearch_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            string searchKey = SearchString.Text;
            var searchItem = Array.Find<ARIndex>(register, item => item.ArNumber == searchKey);
            if (searchItem == null)
            { label12.Text = "Такого ключа не найдено"; }
            else
            { label12.Text = searchKey; }
            
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            label5.Text = elapsedMs.ToString() + "мс";
        }

        private void DumbSearch_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            AutoManager autoManager = new AutoManager();
            string searchKey = SearchString.Text;
            Boolean found = false;
            for (int j = 0; j < numberOfRecords; j += 1)
            {
                AutoRegister auto = autoManager.ReadOneFromBinaryFile(FILE_NAME, j * RECORD_SIZE);
                found = (auto.Number == searchKey);
                if (found)
                { 
                    label12.Text = searchKey;
                    break;
                }
            }

            if (!found)
            { label12.Text = "Такого ключа не найдено"; }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            label6.Text = elapsedMs.ToString() + "мс";
        }

        private void FlushAndExit_Click(object sender, EventArgs e)
        {
            File.Delete(FILE_NAME);
            Application.Exit();
        }


    }

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

        public AutoRegister ReadOneFromBinaryFile(string fileName, long pos)
        {
            AutoRegister readAuto = new AutoRegister();
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                stream.Position = pos;
                readAuto.Number = reader.ReadString();
                readAuto.Model = reader.ReadString();
                readAuto.IssueDate = reader.ReadInt32();
                readAuto.SellDate = reader.ReadInt32();
                readAuto.Color = reader.ReadString();
                readAuto.Owner = reader.ReadString();
            }

            return readAuto;
        }
    }

    class ARIndex
    {
        public string ArNumber { get; set; }
        public long ArAddress { get; set; }
    }
}
