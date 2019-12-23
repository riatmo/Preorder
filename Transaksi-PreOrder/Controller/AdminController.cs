using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Transaksi_PreOrder.Model.Repository;
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


    }
}
