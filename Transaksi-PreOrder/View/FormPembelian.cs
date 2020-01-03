using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Transaksi_PreOrder.Model.Entity;
using Transaksi_PreOrder.Controller;

namespace Transaksi_PreOrder.View
{
    public partial class FormPembelian : Form
    {
        //tampil kode admin yg login
        public string currentAdmin = Login.AdminInfo.CurrentLoggedInAdmin;

        //deklarasi untuk event tambah data & update
        public delegate void CreatePembelianUpdateHandler(Pembelian pbl);
        
        //event update data
        public event CreatePembelianUpdateHandler PembelianUpdate;

        //objek kontraoller
        private PembelianController pblController;

        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;

        // deklarasi field untuk meyimpan objek mahasiswa
        private Pembelian pbl;

        public FormPembelian()
        {
            InitializeComponent();
        }

        // constructor untuk inisialisasi data ketika entri data baru
        public FormPembelian(string title, PembelianController pblController, DetailPesanan detpsn) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.pblController = pblController;

            txtKdPesanan.Text = detpsn.KdDetail;
            txtADMIN.Text = currentAdmin;
            txtKdBarang.Text = detpsn.KdBarang;
            txtKdPembelian.Text = detpsn.KdDetail;
            txtQtyPbl.Text = Convert.ToString(detpsn.Qty);
            txtNamaBrg.Text = pblController.Barang(detpsn.KdBarang).Nama;
            txtJual.Text = Convert.ToString(pblController.Barang(detpsn.KdBarang).Harga);
            txtHargaPbl.Text = pblController.Barang(detpsn.KdBarang).Beli.ToString();
            txtSubPbl.Text = (detpsn.Qty* pblController.Barang(detpsn.KdBarang).Beli).ToString();
        }

        // constructor untuk inisialisasi data ketika mengedit data
        public FormPembelian( Pembelian pblDit, PembelianController pblController, string title) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.pblController = pblController;

            isNewData = false; // set status edit data
            pbl = pblDit; // set objek mhs yang akan diedit

            // untuk edit data, tampilkan data lama        
            txtKdPembelian.Text = pbl.KdPembelian.ToString();
            datePesananPbl.Text = pbl.TglPembelian.ToString();
            txtNamaBrg.Text=pbl.NamaBarang.ToString();
            txtQtyPbl.Text = pbl.Jumlah.ToString();
            txtHargaPbl.Text=pbl.HargaBeli.ToString();
            txtKDprodusen.Text = pbl.KdProdusen.ToString();
            txtKdBarang.Text = pbl.KdBarang.ToString();
            txtKdPesanan.Text=pbl.KdPesanan.ToString();                              
            txtADMIN.Text=pbl.KdAdmin.ToString();           
            txtSubPbl.Text=pbl.SubTotal.ToString();
        }

        private void btnSelesaiPbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTambahPbl_Click_1(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            if (isNewData) pbl = new Pembelian();

            datePesananPbl.Format = DateTimePickerFormat.Custom;
            datePesananPbl.CustomFormat = "yyyy-MM-dd";

            // set nilai property objek mahasiswa yg diambil dari TextBox          
            pbl.KdPembelian = txtKdPembelian.Text;
            pbl.NamaBarang = txtNamaBrg.Text;
            pbl.TglPembelian = datePesananPbl.Text;
            pbl.HargaBeli = Convert.ToInt32(txtHargaPbl.Text);
            pbl.KdPesanan = txtKdPesanan.Text;
            pbl.KdBarang = txtKdBarang.Text;
            pbl.KdProdusen = txtKDprodusen.Text;
            pbl.KdAdmin = txtADMIN.Text;
            pbl.Jumlah = Convert.ToInt32(txtQtyPbl.Text);
            pbl.SubTotal = Convert.ToInt32(txtSubPbl.Text);

            int result = 0;

            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = pblController.Create(pbl);

                if (result > 0) // tambah data berhasil
                {
                    // reset form input, utk persiapan input data berikutnya
                    txtKdPembelian.Clear();
                    txtNamaBrg.Clear();
                    txtKDprodusen.Clear();
                    txtKdBarang.Clear();
                    txtKdPesanan.Clear();
                    txtHargaPbl.Clear();
                    txtQtyPbl.Clear();
                    txtSubPbl.Clear();

                    txtKdPembelian.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = pblController.Update(pbl);

                if (result > 0)
                {
                    PembelianUpdate(pbl); // panggil event OnUpdate
                    this.Close();
                }
            }
        }
    }
}