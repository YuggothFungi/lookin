using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    [Serializable]
    class AutoRegister
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public int IssueDate { get; set; }
        public int SellDate {  get; set; }
        public string Color { get; set; }
        public string Owner { get; set; }


        public AutoRegister(string number, string model, int issueDate, int sellDate, string color, string owner)
        {
            Number = number; Model = model; IssueDate = issueDate; SellDate = sellDate; Color = color; Owner = owner;
        }
    }
        
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
