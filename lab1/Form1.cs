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


        // Обработчик кнопки создания записей. Использует метод CreateUniqueItem,
        // чтобы удостовериться, что номера будут каждый раз уникальные.
        private void GenerateRegister_Click(object sender, EventArgs e)
        {
            AutoManager autoManager = new AutoManager();
            for (int i = 0; i < 10000; i++)
            {
                AutoRegister auto = autoManager.CreateUniqueItem();
                auto.WriteAutoRegisterToBinaryFile(FILE_NAME);

                if (i == 4) // На самом деле не какой-нибудь, а пятый элемент.
                {
                    label11.Text = "Какой-нибудь элемент: " + auto.Number + " " + auto.Model + " " + auto.Owner;
                }
            }
            
            length = GetFileLength(FILE_NAME);
            numberOfRecords = GetNumberOfRecords(FILE_NAME);
            
            // Выводим на экран размер полученного файла. А также создаём массив нужной размерности для индекса.
            label9.Text = (GetFileLength(FILE_NAME) / 1024).ToString() + " КБ";
            register = new ARIndex[numberOfRecords];
        }

        private void CreateIndex_Click(object sender, EventArgs e)
        {
            AutoManager autoManager = new AutoManager();
            
            //По одному вычитываем записи и заполняем индексный массив (пока не отсортированный).
            for (int i=0; i < numberOfRecords; i+=1)
            {
                AutoRegister auto = autoManager.ReadOneFromBinaryFile(FILE_NAME, i*RECORD_SIZE);
                register[i] = new ARIndex { ArNumber = auto.Number, ArAddress = i*RECORD_SIZE };                
            }

            // Использована стандартная функция Sort для массива, которая обеспечивает упорядочивание массива по возрастанию в лексикографическом порядке.
            Array.Sort(register, (x, y) => x.ArNumber.CompareTo(y.ArNumber));
            label13.Text = "В индексном массиве элемент " + register[2].ArNumber + " с адресом " + register[2].ArAddress;
            // Теперь индексный массив отсортирован, показываем на экране один из элементов.
        }

        // Некоторые функции вынесли отдельно
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

        // Обработчик поиска по индексу. С засеканием времени в мс.
        // Используется стандартная функция Find для массивов.
        private void IndexSearch_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            string searchKey = SearchString.Text;
            // В searchItem сохраняем номер автомобиля и позицию записи в файле, если такой номер найден.
            var searchItem = Array.Find<ARIndex>(register, item => item.ArNumber == searchKey);
            if (searchItem == null)
            { label12.Text = "Результат поиска: такого ключа не найдено"; }
            else
            {
                // Теперь у нас есть позиция элемента в файле searchItem.ArAddress передаём её в качестве аргумента функции чтения из файла.
                // Таким образом, читаем только одну конкретную запись, а не весь файл.
                AutoManager autoManager = new AutoManager();
                AutoRegister pickAuto = autoManager.ReadOneFromBinaryFile(FILE_NAME, searchItem.ArAddress);
                label12.Text = "Результат поиска: " + pickAuto.Number + " " + pickAuto.Model + " " + pickAuto.Owner;
            }
            
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            // Выводим затраченное на поиск время на форму.
            label5.Text = elapsedMs.ToString() + "мс";
        }

        // Обработчик кнопки последовательного поиска. С засеканием времени в мс.
        private void DumbSearch_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int iterationNumber = 0;

            // Читаем из файла по одной записи и помещаем запись в объект класса AutoManager
            // Сравниваем, что номер автомобиля совпадает с номером в строке поиска
            // Делаем, пока не закончится файл, запоминаем, сколько записей мы просмотрели, прежде чем найти искомый номер.
            AutoManager autoManager = new AutoManager();
            string searchKey = SearchString.Text;
            Boolean found = false;
            for (int j = 0; j < numberOfRecords; j += 1)
            {
                AutoRegister auto = autoManager.ReadOneFromBinaryFile(FILE_NAME, j * RECORD_SIZE);
                found = (auto.Number == searchKey);
                if (found)
                { 
                    label12.Text = "Результат поиска: " + auto.Number + " " + auto.Model + " " + auto.Owner;
                    break;
                }
                iterationNumber = j;
            }

            if (!found)
            { label12.Text = "Результат поиска: такого ключа не найдено"; }
            
            // 
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            label6.Text = elapsedMs.ToString() + "мс, просмотрено " + iterationNumber.ToString() + " записей";
        }

        // Удаляем файл и выходим
        private void FlushAndExit_Click(object sender, EventArgs e)
        {
            File.Delete(FILE_NAME);
            Application.Exit();
        }
    }

    // Описание полей класса AutoRegister - описывающего одну запись в нашем реестре автомобилей.
    class AutoRegister
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public int IssueDate { get; set; }
        public int SellDate { get; set; }
        public string Color { get; set; }
        public string Owner { get; set; }

        // Два конструктора, один для инициализации пустого объекта, второй для базового объекта со случайным номером автомобиля.
        public AutoRegister(string number, string model, int issueDate, int sellDate, string color, string owner)
        {
            Number = number; Model = model; IssueDate = issueDate; SellDate = sellDate; Color = color; Owner = owner;
        }
        public AutoRegister()
        {
            Number = ""; Model = ""; IssueDate = 0; SellDate = 0; Color = ""; Owner = "";
        }

        // Метод записи в бинарный файл.
        public void WriteAutoRegisterToBinaryFile(string fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Append)))
            {
                writer.Write(this.Number);
                writer.Write(this.Model);
                writer.Write(this.IssueDate);
                writer.Write(this.SellDate);
                writer.Write(this.Color);
                writer.Write(this.Owner);
            }
        }
    }

    // Вспомогательный класс, здесь с элементами AutoRegister делаем разное.
    class AutoManager
    {
        // 
        private HashSet<string> existingIds = new HashSet<string>();
        private Random random = new Random();

        public AutoRegister CreateUniqueItem()
        {
            string number;

            // Генерируем номер автомобиля и сверяем, можно ли добавить такой же в HashSet.
            do
            {
                // Генерация случайного Number по маске А000МВ00, где 000 - это любое число от 100 до 999 и 00 - от 10 до 99.
                number = "А" + random.Next(100, 1000).ToString() + "МВ" + random.Next(10, 100).ToString(); 
            } while (!existingIds.Add(number)); // Проверка на уникальность

            return new AutoRegister(number, "Форд", 19920701, 20030802, "Зелёный", "Владелец");
        }

        // Читаем по одной записи класса AutoRegister, в переменной pos передаём сдвиг в байтах в файле.
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

    // Класс для индексного массива (надо поработать над унифицированными наименованиями классов).
    class ARIndex
    {
        public string ArNumber { get; set; }
        public long ArAddress { get; set; }
    }
}
