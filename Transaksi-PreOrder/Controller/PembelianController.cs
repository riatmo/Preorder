using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Transaksi_PreOrder.Model.Entity;
using Transaksi_PreOrder.Model.Repository;
using Transaksi_PreOrder.Model.Context;

namespace Transaksi_PreOrder.Controller
{
    public class PembelianController
    {
        // CRUD
        private PembelianRepository _repository;

        public int Create(Pembelian pmb)
        {
            int result = 0;

            // kode pembelian wajib diisi
            if (string.IsNullOrEmpty(pmb.KdPembelian))
            {
                MessageBox.Show("Kode pembelian harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // nama barang wajib diisi
            if (string.IsNullOrEmpty(pmb.NamaBarang))
            {
                MessageBox.Show("Nama barang haru diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Harga pembelian wajib diisi
            if (string.IsNullOrEmpty(Convert.ToString(pmb.HargaBeli)))
            {
                MessageBox.Show("Harga harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // produsen
            if (string.IsNullOrEmpty(pmb.KdProdusen))
            {
                MessageBox.Show("Kode produsen harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Barang
            if (string.IsNullOrEmpty(pmb.KdBarang))
            {
                MessageBox.Show("Kode barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Pesanan
            if (string.IsNullOrEmpty(pmb.KdPesanan))
            {
                MessageBox.Show("Kode pesanan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Admin
            if (string.IsNullOrEmpty(pmb.KdAdmin))
            {
                MessageBox.Show("Kode barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // buat clas repo
                _repository = new PembelianRepository(context);

                // manggil method repo biar nambah data
                result = _repository.Create(pmb);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pembelian berhasil disimpan !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data pembelian gagal disimpan !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }
    }
}