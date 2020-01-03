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
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private PembelianRepository _repository;

        public int Create(Pembelian pbl)
        {
            int result = 0;

            // Validavsi kode pembelian tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdPembelian))
            {
                MessageBox.Show("Kode pembelian harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi nama barang tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.NamaBarang))
            {
                MessageBox.Show("Nama barang harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Tanggal pembelian tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.TglPembelian))
            {
                MessageBox.Show("Tanggal Pembelian harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Harga pembelian tidak boleh NULL
            if (string.IsNullOrEmpty(Convert.ToString(pbl.HargaBeli)))
            {
                MessageBox.Show("Harga harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi jumlah tidak boleh NULL
            if (string.IsNullOrEmpty(Convert.ToString(pbl.Jumlah.ToString())))
            {
                MessageBox.Show("Kuantitas harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kode pesanan tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdPesanan))
            {
                MessageBox.Show("Kode pesanan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kode barang tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdBarang))
            {
                MessageBox.Show("Kode barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kode produsen tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdProdusen))
            {
                MessageBox.Show("Kode produsen harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kode admin tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdAdmin))
            {
                MessageBox.Show("Kode admin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // buat clas repo
                _repository = new PembelianRepository(context);

                // manggil method repo biar nambah data
                result = _repository.Create(pbl);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pembelian berhasil ditambah !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data pembelian gagal ditambah !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Update(Pembelian pbl)
        {
            int result = 0;

            // Validavsi kode pembelian tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdPembelian))
            {
                MessageBox.Show("Kode pembelian harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi nama barang tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.NamaBarang))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Tanggal pembelian tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.TglPembelian))
            {
                MessageBox.Show("Tanggal Pembelian harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Harga pembelian tidak boleh NULL
            if (string.IsNullOrEmpty(Convert.ToString(pbl.HargaBeli.ToString())))
            {
                MessageBox.Show("Harga harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi jumlah tidak boleh NULL
            if (string.IsNullOrEmpty(Convert.ToString(pbl.Jumlah.ToString())))
            {
                MessageBox.Show("Kuantitas harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kode pesanan tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdPesanan))
            {
                MessageBox.Show("Kode pesanan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kode barang tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdBarang))
            {
                MessageBox.Show("Kode Barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kode produsen tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdProdusen))
            {
                MessageBox.Show("Kode produsen harus diisi !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kode admin tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdAdmin))
            {
                MessageBox.Show("Kode admin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new PembelianRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Update(pbl);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pembelian berhasil diperbaiki !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data pembelian gagal diperbaiki !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Pembelian pbl)
        {
            int result = 0;

            // Validavsi kode pembelian tidak boleh NULL
            if (string.IsNullOrEmpty(pbl.KdPembelian))
            {
                MessageBox.Show("Kode pembelian harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PembelianRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(pbl);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pembelian berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data pembelian gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public List<Pembelian> ReadAllPembelian()
        {
            List<Pembelian> list = new List<Pembelian>();

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new PembelianRepository(context);

                // panggil method Create class repository untuk menambahkan data
                list = _repository.ReadAllPembelian();
            }

            return list;
        }

        public List<Pembelian> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Pembelian> list = new List<Pembelian>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PembelianRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama);
            }

            return list;
        }


        public Barang Barang(string kdbrg)
        {
            Barang brg = new Barang();

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new PembelianRepository(context);

                // panggil method Create class repository untuk menambahkan data
                brg = _repository.Barang(kdbrg);
            }

            return brg;
        }
    }
}