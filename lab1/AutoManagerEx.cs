using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class AutoManagerEx
    {
        private HashSet<string> existingIds = new HashSet<string>();
        private Random random = new Random();

        //public AutoRegisterEx CreateUniqueItem()
        //{
        //    string number;

        //    // Генерируем уникальный Number
        //    do
        //    {
        //        number = "А" + random.Next(100, 1000).ToString() + "МВ" + random.Next(10, 100).ToString(); ; // Генерация случайного Number
        //    } while (!existingIds.Add(number)); // Проверка на уникальность

        //    return new AutoRegisterEx(number, "Форд", 19920701, 20030802, "Зелёный", "Владелец");
        //}
    }
}
