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
using Transaksi_PreOrder.View;

namespace Transaksi_PreOrder
{
    public partial class FormUtama : Form
    {
        private List<Barang> listBarang = new List<Barang>();
        private List<DetailPesanan> detailPesanan = new List<DetailPesanan>();
        private List<Pesanan> listPesanan = new List<Pesanan>();
        private List<Produsen> listProdusen = new List<Produsen>();
        private List<Pembelian> listPembelian = new List<Pembelian>();

        //tampil kode admin yg login
        public string currentAdmin = Login.AdminInfo.CurrentLoggedInAdmin;

        private BarangController brgController;
        private PesananController psnController;
        private ProdusenController prodController;
        private PembelianController pblController;

        public FormUtama()
        {
            InitializeComponent();

            brgController = new BarangController();
            psnController = new PesananController();
            prodController = new ProdusenController();
            pblController = new PembelianController();

            InisialisasiListView();
            loadPesanan();
        }
      
        private void InisialisasiListView()
        {
            lvwData.View = System.Windows.Forms.View.Details;
            lvwData.FullRowSelect = true;
            lvwData.GridLines = true;

            lvwData.Columns.Add("No", 50, HorizontalAlignment.Center);
            lvwData.Columns.Add("Kode Pesanan", 140, HorizontalAlignment.Center);
            lvwData.Columns.Add("Tanggal Pesanan", 196, HorizontalAlignment.Center);
            lvwData.Columns.Add("Cara Bayar", 200, HorizontalAlignment.Center);
            lvwData.Columns.Add("Jatuh Tempo", 200, HorizontalAlignment.Center);
            lvwData.Columns.Add("Status Pesanan", 200, HorizontalAlignment.Center);
        }


        private void loadPesanan()
        {
            lvwData.Items.Clear();

            listPesanan = psnController.ReadAllPesanan();

            foreach(var psn in listPesanan)
            {
                var noUrut = lvwData.Items.Count + 1;
                
                // // tampilkan data mhs yg baru ke list view
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(psn.KdPesanan);
                item.SubItems.Add(psn.TglPesan);
                item.SubItems.Add(psn.CaraBayar);
                item.SubItems.Add(psn.JatuhTempo);
                item.SubItems.Add(psn.StatusPesanan);

                lvwData.Items.Add(item);
            }
        }       

        private void PesananCreateEventHandler(Pesanan psn)
        {
            // tambahkan objek psn yang baru ke dalam collection
            // ENABLE BUAT DAFTAR PESANAN
            listPesanan.Add(psn);

            int noUrut = lvwData.Items.Count + 1;

            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(psn.KdPesanan);
            item.SubItems.Add(psn.TglPesan);
            item.SubItems.Add(psn.CaraBayar);
            item.SubItems.Add(psn.JatuhTempo);
            item.SubItems.Add(psn.StatusPesanan);

            lvwData.Items.Add(item);           
        }

        private void PesananUpdateEventHandler(Pesanan psn)
        {
            int index = lvwData.SelectedIndices[0];

            ListViewItem itemRow = lvwData.Items[index];
            itemRow.SubItems[1].Text = psn.KdPesanan; 
            itemRow.SubItems[2].Text = psn.TglPesan;
            itemRow.SubItems[3].Text = psn.CaraBayar;
            itemRow.SubItems[4].Text = psn.JatuhTempo;
            itemRow.SubItems[5].Text = psn.StatusPesanan;

            loadPesanan();
        }

        private void btnEntryBarang_Click(object sender, EventArgs e)
        {
            EntryBarang entryBarang = new EntryBarang("Tambah Barang", brgController);

            entryBarang.ShowDialog();
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
           //tampil kode admin yg login
           txtAdmin.Text = currentAdmin;          
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Pesanan psn = listPesanan[lvwData.SelectedIndices[0]];

                // buat objek form entry data mahasiswa
                FormPesanan frmPesanan = new FormPesanan("Update Pesanan", psn, psnController);

                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmPesanan.PesananUpdate += PesananUpdateEventHandler;

                // tampilkan form entry mahasiswa
                frmPesanan.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Pesanan ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Pesanan pesanan = listPesanan[lvwData.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = psnController.Delete(pesanan);
                    if (result > 0) loadPesanan();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data pesanan belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }       

        private void btnBuatPesanan_Click_1(object sender, EventArgs e)
        {
            FormPesanan formPesanan = new FormPesanan("Buat Pesanan", psnController);

            formPesanan.PesananCreate += PesananCreateEventHandler;
    
            formPesanan.ShowDialog();
        }

        private void btnPembayaran_Click(object sender, EventArgs e)
        {           
            if (lvwData.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Pesanan psn = listPesanan[lvwData.SelectedIndices[0]];

                // buat objek form entry data mahasiswa
                FormPembayaran frmByr = new FormPembayaran("Buat Pembayaran", psn, psnController);

                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmByr.PesananUpdate += PesananUpdateEventHandler;

                // tampilkan form entry mahasiswa
                frmByr.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void lstBarang_Click(object sender, EventArgs e)
        {
            FormListBarang frm = new FormListBarang();
            frm.ShowDialog();
        }

        private void btnDetailPesanan_Click(object sender, EventArgs e)
        {
            FormListDetail frm = new FormListDetail();
            frm.ShowDialog();
        }

        private void btnSegarkan_Click(object sender, EventArgs e)
        {
            loadPesanan();
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            FormListPelanggan frm = new FormListPelanggan();
            frm.ShowDialog();
        }

        private void btnProdusen_Click(object sender, EventArgs e)
        {
            FormProdusen frmProd = new FormProdusen("Tambah Data Produsen", prodController);            

            frmProd.ShowDialog();
        }

        private void lstSupplier_Click(object sender, EventArgs e)
        {
            FormListProdusen frmLstProd = new FormListProdusen();
            frmLstProd.ShowDialog();
        }

        

        private void btnPembelian_Click(object sender, EventArgs e)
        {
            FormPembelian frmPbl = new FormPembelian("Pembelian", pblController);
            frmPbl.ShowDialog();
        }

        private void lstPembelian_Click(object sender, EventArgs e)
        {
            FormListPembelian frmLstPbl = new FormListPembelian();
            frmLstPbl.ShowDialog();
        }
    }
}