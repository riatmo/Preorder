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
        //deklarasi untuk event tambah data & update
        public delegate void CreatePembelianUpdateHandler(Pembelian pbl);

        //event tambah data
        //public event CreatePembelianUpdateHandler PembelianCreate;

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
        public FormPembelian(string title, PembelianController pblController) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.pblController = pblController;
        }

        // constructor untuk inisialisasi data ketika mengedit data
        public FormPembelian(string title, Pembelian pblDit, PembelianController pblController) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.pblController = pblController;

            isNewData = false; // set status edit data
            pbl = pblDit; // set objek mhs yang akan diedit

            // untuk edit data, tampilkan data lama        
            pbl.KdPembelian = txtKdPembelian.Text;
            pbl.NamaBarang = txtNamaBrg.Text;
            pbl.TglPembelian = datePesananPbl.Text;
            pbl.HargaBeli = Convert.ToInt32(txtHargaPbl.Text);
            pbl.KdPesanan = txtKdPesanan.Text;
            pbl.KdBarang = txtKdBarang.Text;
            pbl.KdProdusen = txtKDprodusen.Text;
            pbl.KdAdmin = txtADMIN.Text;
            pbl.Jumlah = txtQtyPbl.Text;
            pbl.SubTotal = txtSubPbl.Text;
        }

        private void btnTambahPbl_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            if (isNewData) pbl = new Pembelian();

            datePesananPbl.Format = DateTimePickerFormat.Custom;
            datePesananPbl.CustomFormat = "yyyy-MM-dd";

            // set nilai property objek mahasiswa yg diambil dari TextBox          
            pbl.KdPembelian = txtKdPembelian.Text;
            pbl.NamaBarang = txtNamaBrg.Text;
            pbl.TglPembelian = datePesananPbl.Text;
            pbl.HargaBeli = Convert.ToInt16(txtHargaPbl.Text);
            pbl.KdPesanan = txtKdPesanan.Text;
            pbl.KdBarang = txtKdBarang.Text;
            pbl.KdProdusen = txtKDprodusen.Text;
            pbl.KdAdmin = txtADMIN.Text;
            pbl.Jumlah = txtQtyPbl.Text;
            pbl.SubTotal = txtSubPbl.Text;

            

            int result = 0;

            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = pblController.Create(pbl);

                if (result > 0) // tambah data berhasil
                {
                    //PembelianCreate(pbl); // panggil event OnCreate

                    // reset form input, utk persiapan input data berikutnya
                    txtKdPembelian.Clear();
                    txtNamaBrg.Clear();
                    txtKDprodusen.Clear();
                    txtKdBarang.Clear();
                    txtKdPesanan.Clear();
                    txtHargaPbl.Clear();
                    txtQtyPbl.Clear();
                    txtSubPbl.Clear();

                    //datePesananPbl.Clear;
                    //txtADMIN.Clear();

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

        private void btnSelesaiPbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}