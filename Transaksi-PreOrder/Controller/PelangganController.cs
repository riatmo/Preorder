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
    public class PelangganController
    {
        private PelangganRepository _repository;

        public int Create(Pelanggan plg)
        {
            int result = 0;

            // Validasi kode pembeli tidak boleh NULL
            if (string.IsNullOrEmpty(plg.KdPembeli))
            {
                MessageBox.Show("Kode pembeli harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi nama tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi hp tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Hp))
            {
                MessageBox.Show("Hp harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi alamat tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kecamatan tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Kecamatan))
            {
                MessageBox.Show("Kecamatan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kabupaten tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Kabupaten))
            {
                MessageBox.Show("Kabupaten harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Provinsi tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Provinsi))
            {
                MessageBox.Show("Provinsi harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi KodePos tidak boleh NULL
            if (string.IsNullOrEmpty(plg.KodePos))
            {
                MessageBox.Show("KodePos harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new PelangganRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(plg);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Pelanggan berhasil ditambah !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Pelanggan gagal ditambah !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }       

        public int Update(Pelanggan plg)
        {
            int result = 0;

            // Validasi kode pembeli tidak boleh NULL
            if (string.IsNullOrEmpty(plg.KdPembeli))
            {
                MessageBox.Show("Kode pembeli harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi nama tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi hp tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Hp))
            {
                MessageBox.Show("Hp harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi alamat tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kecamatan tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Kecamatan))
            {
                MessageBox.Show("Kecamatan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Kabupaten tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Kabupaten))
            {
                MessageBox.Show("Kabupaten harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Provinsi tidak boleh NULL
            if (string.IsNullOrEmpty(plg.Provinsi))
            {
                MessageBox.Show("Provinsi harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi KodePos tidak boleh NULL
            if (string.IsNullOrEmpty(plg.KodePos))
            {
                MessageBox.Show("KodePos harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(plg);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pelanggan berhasil diperbaiki !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data pelanggan gagal diperbaiki !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Pelanggan plg)
        {
            int result = 0;

            // Validasi kode pembeli tidak boleh NULL
            if (string.IsNullOrEmpty(plg.KdPembeli))
            {
                MessageBox.Show("Kode pembeli harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(plg);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pelanggan berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data pelanggan gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public List<Pelanggan> ReadAllPelanggan()
        {
            // membuat objek collection
            List<Pelanggan> list = new List<Pelanggan>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAllPelanggan();
            }

            return list;
        }

        public List<Pelanggan> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Pelanggan> list = new List<Pelanggan>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama);
            }

            return list;
        }
    }
}
