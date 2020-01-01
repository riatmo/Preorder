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
    public class DetailPesananController
    {
        //objek CRUD
        private DetailPesananRepository _repository;


        public int Create(DetailPesanan psn)
        {
            int result1 = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(psn.KdDetail))
            {
                MessageBox.Show("Kode barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result1 = _repository.Create(psn);
            }

            if (result1 > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result1;
        }

        public int Update(DetailPesanan detail)
        {
            int result = 0;


            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(detail);
            }

            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public List<DetailPesanan> ReadAllDetail()
        {
            List<DetailPesanan> list = new List<DetailPesanan>();

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Create class repository untuk menambahkan data
                list = _repository.ReadAll();
            }

            return list;

        }

        public int Delete(DetailPesanan detail)
        {
            int result = 0;


            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(detail);
            }

            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int noDetail(string kdpesanan)
        {
            int no;
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Create class repository untuk menambahkan data
                no = _repository.NoDetail(kdpesanan);
            }

            return no;
        }

        public int Subtotal(string kddet)
        {
            int no;
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Create class repository untuk menambahkan data
                no = _repository.BacaSUb(kddet);
            }

            return no;
        }

    }
}
