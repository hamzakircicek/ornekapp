using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ornekapp
{
    public class Model
    {
        public static SqlConnection sqlBaglantisi = new SqlConnection("Data Source=DESKTOP-VMQ4RDT;Initial Catalog=marketDB;Integrated Security=True;MultipleActiveResultSets=True");

        public static string kayitName;
        public static bool kayitDurum;
        public static int id;
        public static string name;

       



    }
}
