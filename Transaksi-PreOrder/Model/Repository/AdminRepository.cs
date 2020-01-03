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
        // deklarsi objek connection
        private MySqlConnection _conn;

        // constructor
        public AdminRepository(DbContext context)
        {
            // inisialisasi objek connection
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
            string kodeadmin = " ";

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
                        kodeadmin = Convert.ToString(dtr["kd_admin"]);
                    }
                }
            }

            return kodeadmin;
        }

        public int Create(Admin adm)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into admin (kd_admin, nama, email, jabatan, hp, username, pwd)
                           values (@kd_admin, @nama, @email, @jabatan, @hp, @username, @pwd)";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kd_admin", adm.KdAdmin);
                cmd.Parameters.AddWithValue("@nama", adm.Nama);
                cmd.Parameters.AddWithValue("@email", adm.Email);
                cmd.Parameters.AddWithValue("@jabatan", adm.Jabatan);
                cmd.Parameters.AddWithValue("@hp", adm.Hp);
                cmd.Parameters.AddWithValue("@username", adm.Username);
                cmd.Parameters.AddWithValue("@pwd", adm.Password);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Update(Admin adm)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update admin set kd_Admin = @kd_admin,  nama = @nama, email = @email, jabatan = @jabatan, hp = @hp, username = @username, pwd =@pwd
                           where kd_admin = @kd_admin";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kd_admin", adm.KdAdmin);
                cmd.Parameters.AddWithValue("@nama", adm.Nama);
                cmd.Parameters.AddWithValue("@email", adm.Email);
                cmd.Parameters.AddWithValue("@jabatan", adm.Jabatan);
                cmd.Parameters.AddWithValue("@hp", adm.Hp);
                cmd.Parameters.AddWithValue("@username", adm.Username);
                cmd.Parameters.AddWithValue("@pwd", adm.Password);

                try
                {
                    // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(Admin adm)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from admin
                           where KdAdmin = @kd_admin";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kd_admin", adm.KdAdmin);

                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }
            return result;
        }

        public List<Admin> ReadAllAdmin()
        {
            // membuat objek collection untuk menampung objek 
            List<Admin> list = new List<Admin>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kd_admin, nama, email, jabatan, hp, username, pwd
                               from admin 
                               order by nama";

                //objek command
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    //membuat data reader
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Admin adm = new Admin();
                            adm.KdAdmin = dtr["kd_admin"].ToString();
                            adm.Nama = dtr["nama"].ToString();
                            adm.Email = dtr["email"].ToString();
                            adm.Jabatan = dtr["jabatan"].ToString();
                            adm.Hp = dtr["hp"].ToString();
                            adm.Username = dtr["username"].ToString();
                            adm.Password = dtr["pwd"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(adm);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }

        public List<Admin> ReadByNama(string nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Admin> list = new List<Admin>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kd_admin, nama, email, jabatan, hp, username, pwd
                               from admin 
                               where nama like @nama
                               order by nama";

                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama", "%" + nama + "%");

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Admin admin = new Admin();
                            admin.KdAdmin = dtr["kd_admin"].ToString();
                            admin.Nama = dtr["nama"].ToString();
                            admin.Email = dtr["email"].ToString();
                            admin.Jabatan = dtr["jabatan"].ToString();
                            admin.Hp = dtr["hp"].ToString();
                            admin.Username = dtr["username"].ToString();
                            admin.Password = dtr["pwd"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(admin);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }

            return list;
        }
    }
}
