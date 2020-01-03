﻿using System;
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
    public partial class UbahPasswordAdmin : Form
    {
        //deklarasi untuk event tambah data & update
        public delegate void CreateRegisUpdateHandler(Admin admin);

        //event tambah data
        //public event CreateRegisUpdateHandler CreateRegis;

        //event update data
        public event CreateRegisUpdateHandler UpdateRegisAdm;

        //event
        //public event CreateRegisUpdateHandler onDelete;

        //objek controller
        private AdminController controller;

        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;

        // deklarasi field untuk meyimpan objek 
        private Admin admin;

        public UbahPasswordAdmin()
        {
            InitializeComponent();
        }

        public UbahPasswordAdmin(string title, AdminController controller) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
        }

        // constructor untuk inisialisasi data ketika mengedit data
        public UbahPasswordAdmin(string title, Admin obj, AdminController controller) : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;

            isNewData = false; // set status edit data
            admin = obj; // set objek yang akan diedit

            txtUbahPass.Text = admin.Password;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            if (isNewData) admin = new Admin();

            // set nilai property objek mahasiswa yg diambil dari TextBox
            admin.Password = txtUbahPass.Text;

            int result = 0;

            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(admin);

                if (result > 0) // tambah data berhasil
                {
                    //onCreate(brg); // panggil event OnCreate

                    // reset form input, utk persiapan input data berikutnya
                    //txtPassword.Clear();

                    //txtKdAdmin.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(admin);

                if (result > 0)
                {
                    UpdateRegisAdm(admin); // panggil event OnUpdate
                    this.Close();
                }
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}