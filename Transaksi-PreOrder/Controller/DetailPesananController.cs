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

        public int Create(DetailPesanan dtlpsn)
        {
            int result1 = 0;

            // Validasi kode detail tidak boleh NULL
            if (string.IsNullOrEmpty(dtlpsn.KdDetail))
            {
                MessageBox.Show("Kode Detail harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kode barang tidak boleh NULL
            if (string.IsNullOrEmpty(dtlpsn.KdBarang))
            {
                MessageBox.Show("Kode Barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kode pesanan tidak boleh NULL
            if (string.IsNullOrEmpty(dtlpsn.KdPesanan))
            {
                MessageBox.Show("Kode Pesanan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kuantitas tidak boleh NULL
            if (string.IsNullOrEmpty(dtlpsn.Qty.ToString()))
            {
                MessageBox.Show("Kuantitas harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result1 = _repository.Create(dtlpsn);
            }

            if (result1 > 0)
            {
                MessageBox.Show("Data Detail Pesanan berhasil ditambah !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Detail Pesanana gagal ditambah !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result1;
        }

        public int Update(DetailPesanan dtlpsn)
        {
            int result = 0;

            // Validasi kode detail tidak boleh NULL
            if (string.IsNullOrEmpty(dtlpsn.KdDetail))
            {
                MessageBox.Show("Kode Detail harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kode barang tidak boleh NULL
            if (string.IsNullOrEmpty(dtlpsn.KdBarang))
            {
                MessageBox.Show("Kode Barang harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kode pesanan tidak boleh NULL
            if (string.IsNullOrEmpty(dtlpsn.KdPesanan))
            {
                MessageBox.Show("Kode Pesanan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi kuantitas tidak boleh NULL
            if (string.IsNullOrEmpty(dtlpsn.Qty.ToString()))
            {
                MessageBox.Show("Kuantitas harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(dtlpsn);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Detail Pesanan berhasil diperbaiki !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Detail Pesanan gagal diperbaiki !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(DetailPesanan dtlpsn)
        {
            int result = 0;

            // Validasi kode barang tidak boleh NULL
            if (string.IsNullOrEmpty(dtlpsn.KdDetail))
            {
                MessageBox.Show("Kode detail harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(dtlpsn);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Detail Pesanan berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Detail Pesanan gagal dihapus !!!", "Peringatan",
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

        public List<DetailPesanan> ReadBy(string kddet)
        {
            List<DetailPesanan> list = new List<DetailPesanan>();

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new DetailPesananRepository(context);

                // panggil method Create class repository untuk menambahkan data
                list = _repository.ReadBy(kddet);
            }

            return list;

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
