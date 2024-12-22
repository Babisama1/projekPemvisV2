using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace projekPemvis1
{
    internal class Koneksi
    {
        private SqlConnection konek = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Kelvin\Kampus\Pemvis\projekPemvis1\projekPemvis1\dataBarang.mdf;Integrated Security=True");
        public SqlConnection GetCon()
        {
            return konek;
        }

        public void OpenCon()
        {
            if (konek.State == System.Data.ConnectionState.Closed)
            {
                konek.Open();
            }
        }

        public void CloseCon()
        {
            if (konek.State == System.Data.ConnectionState.Open)
            {
                konek.Close();
            }
        }
    }
}
