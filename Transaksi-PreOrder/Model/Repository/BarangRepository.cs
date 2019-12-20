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

        public List<Barang> ReadAll()
        {
            List<Barang> list = new List<Barang>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select nama, harga, ukuran, warna 
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
                            brg.Nama = dtr["nama"].ToString();
                            brg.Harga = (int)dtr["harga"];
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
