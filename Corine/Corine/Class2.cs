using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corine
{
    class Class2
    {
        static string id, name, firstname, lastname;

        public static string Username { get => name; set => name = value; }
        public static string Firstname { get => firstname; set => firstname = value; }
        public static string Lastname { get => lastname; set => lastname = value; }
        public static string Id { get => id; set => id = value; }
    }
}
