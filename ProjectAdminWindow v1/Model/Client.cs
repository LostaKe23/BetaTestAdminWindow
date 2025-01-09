using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAdminWindow_v1.Client
{
    public class Client
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int BirthYear { get; set; }
        public string EGRN { get; set; }
        public string Status { get; set; } // Варианты статусов "Ожидает проверки", "Проверка пройдена", "Проверка не пройдена"
    }
}
