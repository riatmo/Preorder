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

namespace Transaksi_PreOrder
{
    public partial class EntryBarang : Form
    {

        //deklarasi untuk event tambah data & update
        public delegate void CreateUpdateHandler(Barang brg);

        //event tambah data
        public event CreateUpdateHandler onCreate;

        //event update data
        public event CreateUpdateHandler onUpdate;

        //objek kontraoller
        private BarangController controller;

        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;

        // deklarasi field untuk meyimpan objek mahasiswa
        private Barang brg;


        public EntryBarang()
        {
            InitializeComponent();
        }

        // constructor untuk inisialisasi data ketika entri data baru
        public EntryBarang(string title, BarangController controller)
            : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
        }

        // constructor untuk inisialisasi data ketika mengedit data
        public EntryBarang(string title, Barang obj, BarangController controller)
            : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;

            isNewData = false; // set status edit data
            brg = obj; // set objek mhs yang akan diedit

            // untuk edit data, tampilkan data lama
             int harga = Convert.ToInt32(txtHarga.Text);
             harga = brg.Harga;
           // txtHarga.Text = brg.Harga;
            txtKdBarang.Text = brg.KdBarang;
            txtNmBarang.Text = brg.Nama;
            txtUkuran.Text = brg.Ukuran;
            txtWarna.Text = brg.Warna;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            if (isNewData) brg = new Barang();

            // set nilai property objek mahasiswa yg diambil dari TextBox
            brg.Harga = Convert.ToInt32(txtHarga.Text);
            //brg.Harga = txtHarga.Text;
            brg.KdBarang = txtKdBarang.Text;
            brg.Nama = txtNmBarang.Text;
            brg.Ukuran = txtUkuran.Text;
            brg.Warna = txtWarna.Text;

            int result = 0;

            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(brg);

                if (result > 0) // tambah data berhasil
                {
                    onCreate(brg); // panggil event OnCreate

                    // reset form input, utk persiapan input data berikutnya
                    txtHarga.Clear();
                    txtKdBarang.Clear();
                    txtNmBarang.Clear();
                    txtUkuran.Clear();
                    txtWarna.Clear();

                    txtKdBarang.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(brg);

                if (result > 0)
                {
                    onUpdate(brg); // panggil event OnUpdate
                    this.Close();
                }
            }

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
