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
    public partial class FormPesanan : Form
    {

        //tampil kode admin yg login
        public string currentAdmin = Login.AdminInfo.CurrentLoggedInAdmin;

        //deklarasi untuk event tambah data & update
        public delegate void CreatePesananHandler(Pesanan psn);

        //event tambah data
        public event CreatePesananHandler PesananCreate;

        //event update data
        public event CreatePesananHandler PesananUpdate;

        //objek kontraoller
        private PesananController controller1;
        //private AdminController controllerAdmin;

        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;

        // deklarasi field untuk meyimpan objek mahasiswa
        private Pesanan psn;


        public FormPesanan()
        {
            InitializeComponent();
            
        }

        

        // constructor untuk inisialisasi data ketika entri data baru
        public FormPesanan(string title, PesananController controller1)
            : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller1 = controller1;
        }

        // constructor untuk inisialisasi data ketika mengedit data
        public FormPesanan(string title, Pesanan obj1, PesananController controller1)
            : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller1 = controller1;

            isNewData = false; // set status edit data
            psn = obj1; // set objek mhs yang akan diedit

            // untuk edit data, tampilkan data lama
            
            txtKdPesanan.Text = psn.KdPesanan;
           
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            if (isNewData) psn = new Pesanan();

            // set nilai property objek mahasiswa yg diambil dari TextBox

            psn.KdPesanan = txtKdPesanan.Text;


            int result1 = 0;

            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result1 = controller1.Create(psn);

                if (result1 > 0) // tambah data berhasil
                {
                    PesananCreate(psn); // panggil event OnCreate

                    // reset form input, utk persiapan input data berikutnya
                    txtKdPesanan.Clear();
                    
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result1 = controller1.Update(psn);

                if (result1 > 0)
                {
                    PesananUpdate(psn); // panggil event OnUpdate
                    this.Close();
                }
            }
        }

        private void FormPesanan_Load(object sender, EventArgs e)
        {
            //tampil kode admin yg login
            txtAdmin.Text = currentAdmin;
        }
    }
}
