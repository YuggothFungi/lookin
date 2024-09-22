using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class AutoRegisterEx
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public int IssueDate { get; set; }
        public int SellDate { get; set; }
        public string Color { get; set; }
        public string Owner { get; set; }

        public AutoRegisterEx(string number, string model, int issueDate, int sellDate, string color, string owner)
        {
            Number = number; Model = model; IssueDate = issueDate; SellDate = sellDate; Color = color; Owner = owner;
        }

        public void WriteAutoRegisterToBinaryFile(string fileName, AutoRegisterEx arElement)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Append)))
            {
                // Записываем поля класса в файл
                writer.Write(arElement.Number);
                writer.Write(arElement.Model);
                writer.Write(arElement.IssueDate);
                writer.Write(arElement.SellDate);
                writer.Write(arElement.Color);
                writer.Write(arElement.Owner);
                writer.Write(true);
            }
        }
    }
}
