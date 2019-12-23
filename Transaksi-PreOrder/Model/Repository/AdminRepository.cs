using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MySql.Data.MySqlClient;
using Transaksi_PreOrder.Model.Context;
using Transaksi_PreOrder.Model.Entity;



namespace Transaksi_PreOrder.Model.Repository
{
    public class AdminRepository
    {
        private MySqlConnection _conn;

        public AdminRepository(DbContext context)
        {
            _conn = context.Conn;
        }


        public bool IsValidAdmin(string Username, string Password)
        {
            bool result = false;

            string sql = @"select count(*) as row_count
                           from admin
                           where username = @Username and pwd = @Password";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@password", Password);

                // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    // panggil method Read untuk mendapatkan baris dari result set
                    if (dtr.Read())
                    {
                        result = Convert.ToInt32(dtr["row_count"]) > 0;
                    }
                }
            }

            return result;

        }


        public string KodeAdmin(string username, string password)
        {
            string kodeadmin = "AD001";

            string sql = @"select kd_admin 
                           from admin
                           where username = @Username and pwd = @Password";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    // panggil method Read untuk mendapatkan baris dari result set
                    if (dtr.Read())
                    {
                        kodeadmin = Convert.ToString(dtr["kd_admin"] );
                    }
                }
            }

            return kodeadmin;
        }




    }
}
