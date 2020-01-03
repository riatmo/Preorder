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
    public class BarangController
    {
        //objek CRUD
        private BarangRepository _repository;   

        public int Create(Barang brg)
        {
            int result = 0;

            // Validasi kode barang tidak boleh NULL
            if (string.IsNullOrEmpty(brg.KdBarang))
            {
                MessageBox.Show("Kode barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi nama barang tidak boleh NULL
            if (string.IsNullOrEmpty(brg.Nama))
            {
                MessageBox.Show("Nama barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kuantitas tidak boleh NULL
            if (string.IsNullOrEmpty(Convert.ToString(brg.Qty)))
            {
                MessageBox.Show("Kuantitas harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi harga tidak boleh NULL
            if (string.IsNullOrEmpty(Convert.ToString(brg.Harga)))
            {
                MessageBox.Show("Harga harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi warna tidak boleh NULL
            if (string.IsNullOrEmpty(brg.Warna))
            {
                MessageBox.Show("Warna harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi ukuran tidak boleh NULL
            if (string.IsNullOrEmpty(brg.Ukuran))
            {
                MessageBox.Show("Ukuran harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class barang repository
                _repository = new BarangRepository(context);

                // panggil method Create pada repository barang untuk menambahkan data
                result = _repository.Create(brg);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Barang berhasil ditambah!", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Barang gagal ditambah!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Update(Barang brg)
        {
            int result = 0;

            // Validasi kode barang tidak boleh NULL
            if (string.IsNullOrEmpty(brg.KdBarang))
            {
                MessageBox.Show("Kode barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi nama barang tidak boleh NULL
            if (string.IsNullOrEmpty(brg.Nama))
            {
                MessageBox.Show("Nama barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kuantitas tidak boleh NULL
            if (string.IsNullOrEmpty(Convert.ToString(brg.Qty)))
            {
                MessageBox.Show("Kuantitas harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi harga tidak boleh NULL
            if (string.IsNullOrEmpty(Convert.ToString(brg.Harga)))
            {
                MessageBox.Show("Harga harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi warna tidak boleh NULL
            if (string.IsNullOrEmpty(brg.Warna))
            {
                MessageBox.Show("Warna harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi ukuran tidak boleh NULL
            if (string.IsNullOrEmpty(brg.Ukuran))
            {
                MessageBox.Show("Ukuran harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new BarangRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Update(brg);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Barang berhasil diperbaiki !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Barang gagal diperbaiki !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Barang brg)
        {
            int result = 0;

            // Validasi kode barang tidak boleh NULL
            if (string.IsNullOrEmpty(brg.KdBarang))
            {
                MessageBox.Show("Kode barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BarangRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(brg);
            }

            if (result > 0)
            {
                MessageBox.Show("Data barang berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data barang gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public List<Barang> ReadAllBarang()
        {
            List<Barang> list = new List<Barang>();

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new BarangRepository(context);

                // panggil method Create class repository untuk menambahkan data
                list = _repository.ReadAllBarang();
            }

            return list;

        }

        public List<Barang> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Barang> list = new List<Barang>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BarangRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama);
            }

            return list;
        }
    }
}
