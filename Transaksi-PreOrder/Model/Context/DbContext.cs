using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Transaksi_PreOrder.Model.Context
{
    public class DbContext : IDisposable
    {
        private MySqlConnection _conn;

        public MySqlConnection Conn {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }

        private MySqlConnection GetOpenConnection()
        {
            MySqlConnection conn = null;

            try
            {
                string connectionString = @"server=127.0.0.1;userid=root;password=root;database=preorder";
                conn = new MySqlConnection(connectionString);
                conn.Open();
            }

            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}", ex.Message);
            }
            return conn;
        }


        // Method ini digunakan untuk menghapus objek koneksi dari memory ketika sudah tidak digunakan
        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
