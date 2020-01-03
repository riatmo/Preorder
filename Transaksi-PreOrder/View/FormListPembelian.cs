using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Transaksi_PreOrder.View;
using Transaksi_PreOrder.Model.Entity;
using Transaksi_PreOrder.Controller;

namespace Transaksi_PreOrder
{
    public partial class FormListPembelian : Form
    {
        // deklarasi objek collection untuk menampung objek mahasiswa
        private List<Pembelian> listPembelian = new List<Pembelian>();

        // deklarasi objek controller
        private PembelianController pblController;

        public FormListPembelian()
        {
            InitializeComponent();
            pblController = new PembelianController();

            ListPembelian();
            LoadPembelian();
        }

        private void ListPembelian()
        {
            lvwListPembelian.View = System.Windows.Forms.View.Details;
            lvwListPembelian.FullRowSelect = true;
            lvwListPembelian.GridLines = true;

            lvwListPembelian.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwListPembelian.Columns.Add("Kode Pembelian", 90, HorizontalAlignment.Center);
            lvwListPembelian.Columns.Add("NamaBarang", 350, HorizontalAlignment.Center);
            lvwListPembelian.Columns.Add("Tanggal Pembelian", 100, HorizontalAlignment.Center);
            lvwListPembelian.Columns.Add("Harga Beli", 100, HorizontalAlignment.Center);
            lvwListPembelian.Columns.Add("Kode Pesanan", 100, HorizontalAlignment.Center);
            lvwListPembelian.Columns.Add("Kode Barang", 100, HorizontalAlignment.Center);
            lvwListPembelian.Columns.Add("Kode Produsen", 100, HorizontalAlignment.Center);           
            lvwListPembelian.Columns.Add("Kode Admin", 100, HorizontalAlignment.Center);
            lvwListPembelian.Columns.Add("Jumlah", 100, HorizontalAlignment.Center);
            lvwListPembelian.Columns.Add("Sub Total", 100, HorizontalAlignment.Center);
        }

        private void LoadPembelian()
        {
            lvwListPembelian.Items.Clear();

            listPembelian = pblController.ReadAllPembelian();

            foreach (var pbl in listPembelian)
            {
                var noUrut = lvwListPembelian.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pbl.KdPembelian);
                item.SubItems.Add(pbl.NamaBarang);
                item.SubItems.Add(pbl.TglPembelian);
                item.SubItems.Add(pbl.HargaBeli.ToString());
                item.SubItems.Add(pbl.KdProdusen);
                item.SubItems.Add(pbl.KdBarang);
                item.SubItems.Add(pbl.KdPesanan);
                item.SubItems.Add(pbl.KdAdmin);
                item.SubItems.Add(pbl.Jumlah.ToString());
                item.SubItems.Add(pbl.SubTotal.ToString());

                lvwListPembelian.Items.Add(item);
            }
        }

        private void UpdatePembelianEventHandler(Pembelian pbl)
        {
            // ambil index data mhs yang edit
            int index = lvwListPembelian.SelectedIndices[0];

            // update informasi mhs di listview
            ListViewItem itemRow = lvwListPembelian.Items[index];
            itemRow.SubItems[1].Text = pbl.KdProdusen;
            itemRow.SubItems[2].Text = pbl.NamaBarang;
            itemRow.SubItems[3].Text = pbl.TglPembelian;
            itemRow.SubItems[4].Text = pbl.HargaBeli.ToString();
            itemRow.SubItems[5].Text = pbl.KdProdusen;
            itemRow.SubItems[6].Text = pbl.KdBarang;
            itemRow.SubItems[7].Text = pbl.KdPesanan;
            itemRow.SubItems[8].Text = pbl.KdAdmin;
            itemRow.SubItems[9].Text = pbl.Jumlah.ToString();
            itemRow.SubItems[10].Text = pbl.SubTotal.ToString();
        }

        private void btnPerbaiki_Click(object sender, EventArgs e)
        {
            if (lvwListPembelian.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Pembelian pbl = listPembelian[lvwListPembelian.SelectedIndices[0]];

                // buat objek form entry data mahasiswa
                FormPembelian frmPbl = new FormPembelian( pbl, pblController, "Edit Data Produsen");

                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmPbl.PembelianUpdate += UpdatePembelianEventHandler;

                // tampilkan form entry mahasiswa
                frmPbl.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwListPembelian.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data barang ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Pembelian pbl = listPembelian[lvwListPembelian.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = pblController.Delete(pbl);
                    if (result > 0)
                        LoadPembelian();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCariBarang_TextChanged(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwListPembelian.Items.Clear();

            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listPembelian = pblController.ReadByNama(txtCariBarang.Text);

            // ekstrak objek mhs dari collection
            foreach (var pbl in listPembelian)
            {
                var noUrut = lvwListPembelian.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pbl.KdPembelian);
                item.SubItems.Add(pbl.NamaBarang);
                item.SubItems.Add(pbl.TglPembelian);
                item.SubItems.Add(pbl.HargaBeli.ToString());
                item.SubItems.Add(pbl.KdProdusen);
                item.SubItems.Add(pbl.KdBarang);
                item.SubItems.Add(pbl.KdPesanan);
                item.SubItems.Add(pbl.KdAdmin);
                item.SubItems.Add(pbl.Jumlah.ToString());
                item.SubItems.Add(pbl.SubTotal.ToString());

                // tampilkan data mhs ke listview
                lvwListPembelian.Items.Add(item);
            }
        }
    }
}
