using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Transaksi_PreOrder.Model.Entity;
using Transaksi_PreOrder.Model.Context;

namespace Transaksi_PreOrder.Model.Repository
{
    public class BarangRepository
    {
        //objek connection 
        private MySqlConnection _conn;

        //constructor
        public BarangRepository(DbContext context)
        {
            //inisialisasi objek conn
            _conn = context.Conn;
        }

        

        public int Create(Barang brg)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into barang (kd_barang, nama, harga, ukuran, warna)
                           values (@kdbarang, @nama, @harga, @ukuran, @warna)";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kdbarang", brg.KdBarang);
                cmd.Parameters.AddWithValue("@nama", brg.Nama);
                cmd.Parameters.AddWithValue("@harga", brg.Harga);
                cmd.Parameters.AddWithValue("@ukuran", brg.Ukuran);
                cmd.Parameters.AddWithValue("@warna", brg.Warna);


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

        public int Update(Barang brg)
        {
            int result = 0;

            // deklarasi perintah SQL

            string sql = @"update barang set nama = @nama,  warna = @warna
                           where kdbarang = @kdbarang";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kdbarang", brg.KdBarang);
                cmd.Parameters.AddWithValue("@nama", brg.Nama);
                cmd.Parameters.AddWithValue("@harga", brg.Harga);
                cmd.Parameters.AddWithValue("@ukuran", brg.Ukuran);
                cmd.Parameters.AddWithValue("@warna", brg.Warna);

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

        public List<Barang> ReadAll()
        {
            List<Barang> list = new List<Barang>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select kd_barang, nama,  ukuran, warna, kuantitas
                               from barang 
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
                            Barang brg = new Barang();
                            brg.KdBarang = dtr["kd_barang"].ToString();
                            brg.Nama = dtr["nama"].ToString();
                            //brg.Harga = (int32)dtr["harga"].ToString(); ;
                            brg.Harga = Convert.ToInt16(dtr["harga"]);
                            brg.Ukuran = dtr["ukuran"].ToString();
                            brg.Warna = dtr["warna"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(brg);
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
