using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Transaksi_PreOrder.Model.Repository;
using Transaksi_PreOrder.Model.Entity;
using Transaksi_PreOrder.Model.Context;

namespace Transaksi_PreOrder.Controller
{
    public class AdminController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private AdminRepository _repository;

        public bool IsValidAdmin(string userName, string password)
        {
            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("User name harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            bool IsValidAdmin = false;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new AdminRepository(context);

                // panggil method Create class repository untuk menambahkan data
                IsValidAdmin = _repository.IsValidAdmin(userName, password);
            }

            if (!IsValidAdmin)
            {
                MessageBox.Show("User name atau password salah !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }

        public string KodeAdmin(string userName, string password)
        {

            string KodeAdmin;
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new AdminRepository(context);

                // panggil method Create class repository untuk menambahkan data
                KodeAdmin = _repository.KodeAdmin(userName, password);
            }

            return KodeAdmin;
        }

        public int Create(Admin admin)
        {
            int result = 0;

            // Validasi Kode admin tidak boleh NULL
            if (string.IsNullOrEmpty(admin.KdAdmin))
            {
                MessageBox.Show("Kode Admin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Nama tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Email tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Email))
            {
                MessageBox.Show("Email harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi jabatan tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Jabatan))
            {
                MessageBox.Show("Jabatan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi hp tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Hp))
            {
                MessageBox.Show("Nomor Hp harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi username tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Username))
            {
                MessageBox.Show("Username harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi password tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class barang repository
                _repository = new AdminRepository(context);

                // panggil method Create pada repository barang untuk menambahkan data
                result = _repository.Create(admin);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Admin berhasil ditambah!", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("Data Admin gagal ditambah!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Update(Admin admin)
        {
            int result = 0;

            // Validasi Kode admin tidak boleh NULL
            if (string.IsNullOrEmpty(admin.KdAdmin))
            {
                MessageBox.Show("Kode Admin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Nama tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi Email tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Email))
            {
                MessageBox.Show("Email harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi jabatan tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Jabatan))
            {
                MessageBox.Show("Jabatan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi hp tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Hp))
            {
                MessageBox.Show("No HP harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi username tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Username))
            {
                MessageBox.Show("Username harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi password tidak boleh NULL
            if (string.IsNullOrEmpty(admin.Password))
            {
                MessageBox.Show("password harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new AdminRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Update(admin);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Admin berhasil diperbaiki!", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("Data Admin gagal diperbaiki!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Admin adm)
        {
            int result = 0;

            // Validasi Kode admin tidak boleh NULL
            if (string.IsNullOrEmpty(adm.KdAdmin))
            {
                MessageBox.Show("Kode Admin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AdminRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(adm);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Admin berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Admin gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public List<Admin> ReadAllAdmin()
        {
            List<Admin> list = new List<Admin>();

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new AdminRepository(context);

                // panggil method Create class repository untuk menambahkan data
                list = _repository.ReadAllAdmin();
            }

            return list;
        }

        public List<Admin> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Admin> list = new List<Admin>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AdminRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama);
            }
            return list;
        }
    }
}
