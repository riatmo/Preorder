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
    class PembelianRepository
    {
        private MySqlConnection _conn;

        public PembelianRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Pembelian pembelian)
        {
            int result = 0;

            string sql = @"insert into pembelian (kd_pembelian, TglPembelian, NamaBarang, HargaBeli, kdProdusen, kdBarang, kdPesanan, kdAdmin) values
        (@kd_pembelian, @TglPembelian, @NamaBarang, @HargaBeli, @kdProdusen, @kdBarang, @kdPesanan, @kdAdmin)";

            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@kd_pembelian", pembelian.KdPembelian);
                cmd.Parameters.AddWithValue("@TglPembelian", pembelian.TglPembelian);
                cmd.Parameters.AddWithValue("@NamaBarang", pembelian.NamaBarang);
                cmd.Parameters.AddWithValue("@HargaBeli", pembelian.HargaBeli);
                cmd.Parameters.AddWithValue("@kdProdusen", pembelian.KdProdusen);
                cmd.Parameters.AddWithValue("@kdBarang", pembelian.KdBarang);
                cmd.Parameters.AddWithValue("@kdPesanan", pembelian.KdPesanan);
                cmd.Parameters.AddWithValue("@kdAdmin", pembelian.KdAdmin);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error : {0}", ex.Message);
                }
            }

            return result;
        }

        public List<Pembelian> ReadAll()
        {
            List<Pembelian> list = new List<Pembelian>();

            try
            {
                string sql = @"select kd_pembelian, TglPembelian, Namabarang, HargaBeli, kdProdusen, kdBarang, kdPesanan, kdAdmin
                from pembelian order by kd_pembelian";

                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Pembelian pmb = new Pembelian();

                            pmb.KdPembelian = dtr["kd_pembelian"].ToString();
                            pmb.TglPembelian = dtr["TglPembelian"].ToString();
                            pmb.NamaBarang = dtr["NamaBarang"].ToString();
                            pmb.HargaBeli = Convert.ToInt32(dtr["HargaBeli"].ToString());
                            pmb.KdProdusen = dtr["kdProdusen"].ToString();
                            pmb.KdBarang = dtr["kdBarang"].ToString();
                            pmb.KdPesanan = dtr["kdPesanan"].ToString();
                            pmb.KdAdmin = dtr["kdAdmin"].ToString();

                            list.Add(pmb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Read All error : {0}", ex.Message);
            }
            return list;
        }

    }
}