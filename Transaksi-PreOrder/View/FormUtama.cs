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
    public partial class FormUtama : Form
    {
        private List<Barang> listBarang = new List<Barang>();

        private BarangController controller;



        public FormUtama()
        {
            InitializeComponent();

            controller = new BarangController();


            InisialisasiListView();
        }

        private void lvwData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InisialisasiListView()
        {
            lvwData.View = View.Details;
            lvwData.FullRowSelect = true;
            lvwData.GridLines = true;

            lvwData.Columns.Add("No", 50, HorizontalAlignment.Center);
            lvwData.Columns.Add("Kode Pesanan", 140, HorizontalAlignment.Center);
            lvwData.Columns.Add("Tanggal Pesanan", 196, HorizontalAlignment.Center);
            lvwData.Columns.Add("Cara Bayar", 200, HorizontalAlignment.Center);
            lvwData.Columns.Add("Jatuh Tempo", 200, HorizontalAlignment.Center);
            lvwData.Columns.Add("Status Pesanan", 200, HorizontalAlignment.Center);
        }

        private void btnBuatPesanan_Click(object sender, EventArgs e)
        {

        }

        private void onCreateEventHandler(Barang brg)
        {
            // tambahkan objek mhs yang baru ke dalam collection

            // ENABLE BUAT DAFTAR PESANAN

           // listBarang.Add(brg);

           // int noUrut = lvwData.Items.Count + 1;

           // // tampilkan data mhs yg baru ke list view
           // ListViewItem item = new ListViewItem(noUrut.ToString());
           // item.SubItems.Add(brg.KdBarang);
           // item.SubItems.Add(brg.Nama);
           // item.SubItems.Add(Convert.ToString(brg.Harga));

           // lvwData.Items.Add(item);
        }

        private void btnEntryBarang_Click(object sender, EventArgs e)
        {

            EntryBarang entryBarang = new EntryBarang("tambah Barang", controller);

            entryBarang.onCreate += onCreateEventHandler;



            entryBarang.ShowDialog();
        }
    }
}
