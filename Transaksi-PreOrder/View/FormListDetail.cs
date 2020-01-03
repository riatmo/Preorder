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
    public partial class FormListDetail : Form
    {
        // deklarasi collection untuk menampung objek detail
        private List<DetailPesanan> detailPesanan = new List<DetailPesanan>();

        // deklarasi objek controller
        private DetailPesananController controller;
        private PembelianController controllerBeli;

        public FormListDetail()
        {
            InitializeComponent();

            //objek kontroller
            controller = new DetailPesananController();
            controllerBeli = new PembelianController();
            ListDetail();
            LoadDetail();

        }

        // atur kolom listview
        private void ListDetail()
        {
            lvwDetailPesanan.View = System.Windows.Forms.View.Details;
            lvwDetailPesanan.FullRowSelect = true;
            lvwDetailPesanan.GridLines = true;

            lvwDetailPesanan.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwDetailPesanan.Columns.Add("KD Detail", 120, HorizontalAlignment.Center);
            lvwDetailPesanan.Columns.Add("KD Pesanan", 120, HorizontalAlignment.Center);
            lvwDetailPesanan.Columns.Add("KD Barang", 120, HorizontalAlignment.Left);
            lvwDetailPesanan.Columns.Add("Qty", 100, HorizontalAlignment.Center);
            lvwDetailPesanan.Columns.Add("Sub Total", 200, HorizontalAlignment.Center);
        }

        private void LoadDetail()
        {
            // kosongkan listview
            lvwDetailPesanan.Items.Clear();

            // panggil method ReadAll dan tampung datanya ke dalam collection
            detailPesanan = controller.ReadAllDetail();

            // ekstrak objek mhs dari collection
            foreach (var detail in detailPesanan)
            {
                var noUrut = lvwDetailPesanan.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(detail.KdDetail);
                item.SubItems.Add(detail.KdPesanan);
                item.SubItems.Add(detail.KdBarang);
                item.SubItems.Add(Convert.ToString(detail.Qty));
                item.SubItems.Add(Convert.ToString(detail.Subtotal));

                // tampilkan data mhs ke listview
                lvwDetailPesanan.Items.Add(item);
            }
        }

        private void CreateDetailHandler(DetailPesanan detail)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            detailPesanan.Add(detail);


            int noUrut = lvwDetailPesanan.Items.Count + 1;

            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(detail.KdDetail);
            item.SubItems.Add(detail.KdPesanan);
            item.SubItems.Add(detail.KdBarang);
            item.SubItems.Add(Convert.ToString(detail.Qty));
            item.SubItems.Add(Convert.ToString(controller.Subtotal(detail.KdDetail)));


            lvwDetailPesanan.Items.Add(item);
        }

        private void UpdateDetailHandler(DetailPesanan detail)
        {
            // ambil index data mhs yang edit
            int index = lvwDetailPesanan.SelectedIndices[0];

            // update informasi mhs di listview
            ListViewItem itemRow = lvwDetailPesanan.Items[index];
            itemRow.SubItems[1].Text = detail.KdDetail;
            itemRow.SubItems[2].Text = detail.KdPesanan;
            itemRow.SubItems[3].Text = detail.KdBarang;
            itemRow.SubItems[4].Text = Convert.ToString(detail.Qty);
            itemRow.SubItems[5].Text = Convert.ToString(controller.Subtotal(detail.KdDetail));

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (lvwDetailPesanan.SelectedItems.Count > 0)
            {
                DetailPesanan tambah = detailPesanan[lvwDetailPesanan.SelectedIndices[0]];

                FormDetailPesanan formDetail = new FormDetailPesanan(tambah, controller, "Tambah Detail Pesanan");

                formDetail.DetailPesananCreate += CreateDetailHandler;

                formDetail.ShowDialog();
            }

            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(lvwDetailPesanan.SelectedItems.Count > 0)
            { 

            // ambil objek mhs yang mau diedit dari collection
            DetailPesanan detail = detailPesanan[lvwDetailPesanan.SelectedIndices[0]];

            // buat objek form entry data mahasiswa
            FormDetailPesanan formDetail = new FormDetailPesanan("Edit Data Mahasiswa", detail, controller);

            // mendaftarkan method event handler untuk merespon event OnUpdate
            formDetail.DetailPesananUpdate += UpdateDetailHandler;

            // tampilkan form entry mahasiswa
            formDetail.ShowDialog();
        }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void txtCariDetail_TextChanged(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwDetailPesanan.Items.Clear();

            // panggil method ReadAll dan tampung datanya ke dalam collection
            detailPesanan = controller.ReadBy(txtCariDetail.Text);

            // ekstrak objek mhs dari collection
            foreach (var detail in detailPesanan)
            {
                var noUrut = lvwDetailPesanan.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(detail.KdDetail);
                item.SubItems.Add(detail.KdPesanan);
                item.SubItems.Add(detail.KdBarang);
                item.SubItems.Add(Convert.ToString(detail.Qty));
                item.SubItems.Add(Convert.ToString(detail.Subtotal));

                // tampilkan data mhs ke listview
                lvwDetailPesanan.Items.Add(item);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwDetailPesanan.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    DetailPesanan pesanan = detailPesanan[lvwDetailPesanan.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(pesanan);
                    if (result > 0) LoadDetail();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBeli_Click(object sender, EventArgs e)
        {
            if (lvwDetailPesanan.SelectedItems.Count > 0)
            {

                // ambil objek mhs yang mau diedit dari collection
                DetailPesanan detail = detailPesanan[lvwDetailPesanan.SelectedIndices[0]];

                // buat objek form entry data mahasiswa
                 FormPembelian frmBeli = new FormPembelian("Edit Data Mahasiswa", controllerBeli, detail);

                // mendaftarkan method event handler untuk merespon event OnUpdate
                //formDetail.DetailPesananUpdate += UpdateDetailHandler;

                // tampilkan form entry mahasiswa
                frmBeli.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
