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
    public partial class FormListAdmin : Form
    {
        // deklarasi collection untuk menampung objek barang
        private List<Admin> listAdmin = new List<Admin>();

        // deklarasi objek controller barang
        private AdminController admController;

        public FormListAdmin()
        {
            InitializeComponent();

            admController = new AdminController();

            ListAdmin();
            LoadAdmin();

        }

        //List view 
        private void ListAdmin()
        {
            lvwListAdmin.View = System.Windows.Forms.View.Details;
            lvwListAdmin.FullRowSelect = true;
            lvwListAdmin.GridLines = true;

            lvwListAdmin.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwListAdmin.Columns.Add("Kode Admin", 80, HorizontalAlignment.Center);
            lvwListAdmin.Columns.Add("Nama", 81, HorizontalAlignment.Center);
            lvwListAdmin.Columns.Add("Email", 153, HorizontalAlignment.Center);
            lvwListAdmin.Columns.Add("Jabatan", 100, HorizontalAlignment.Center);
            lvwListAdmin.Columns.Add("No Telp", 100, HorizontalAlignment.Center);
            lvwListAdmin.Columns.Add("Username", 80, HorizontalAlignment.Center);
            lvwListAdmin.Columns.Add("Password", 80, HorizontalAlignment.Center);
        }
        //Memuat barang dari DB kelistview
        private void LoadAdmin()
        {
            // kosongkan listview
            lvwListAdmin.Items.Clear();

            // panggil method ReadAll dan tampung datanya ke dalam collection
            listAdmin = admController.ReadAllAdmin();

            // ekstrak objek mhs dari collection
            foreach (var adm in listAdmin)
            {
                var noUrut = lvwListAdmin.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(adm.KdAdmin);
                item.SubItems.Add(adm.Nama);
                item.SubItems.Add(adm.Email);
                item.SubItems.Add(adm.Jabatan);
                item.SubItems.Add(adm.Hp);
                item.SubItems.Add(adm.Username);
                item.SubItems.Add(adm.Password);

                // tampilkan data mhs ke listview
                lvwListAdmin.Items.Add(item);
            }
        }

        private void UpdateAdminEventHandler(Admin adm)
        {
            // ambil index data mhs yang edit
            int index = lvwListAdmin.SelectedIndices[0];

            // update informasi mhs di listview
            ListViewItem itemRow = lvwListAdmin.Items[index];
            itemRow.SubItems[1].Text = adm.KdAdmin;
            itemRow.SubItems[2].Text = adm.Nama;
            itemRow.SubItems[3].Text = adm.Email;
            itemRow.SubItems[4].Text = adm.Jabatan;
            itemRow.SubItems[5].Text = adm.Hp;
            itemRow.SubItems[6].Text = adm.Username;
            itemRow.SubItems[7].Text = adm.Password;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCariNamaAdmin_TextChanged(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwListAdmin.Items.Clear();

            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listAdmin = admController.ReadByNama(txtCariNamaAdmin.Text);

            // ekstrak objek mhs dari collection
            foreach (var admin in listAdmin)
            {
                var noUrut = lvwListAdmin.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(admin.KdAdmin);
                item.SubItems.Add(admin.Nama);
                item.SubItems.Add(admin.Email);
                item.SubItems.Add(admin.Jabatan);
                item.SubItems.Add(admin.Hp);
                item.SubItems.Add(admin.Username);
                item.SubItems.Add(admin.Password);

                // tampilkan data ke listview
                lvwListAdmin.Items.Add(item);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwListAdmin.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data admin ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Admin adm = listAdmin[lvwListAdmin.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = admController.Delete(adm);
                    if (result > 0) LoadAdmin();
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

        private void btnGantiPass_Click(object sender, EventArgs e)
        {
            if (lvwListAdmin.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Admin adm = listAdmin[lvwListAdmin.SelectedIndices[0]];

                // buat objek form entry data mahasiswa
                UbahPasswordAdmin frmUbahPass = new UbahPasswordAdmin("Ubah Password Admin", adm, admController);

                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmUbahPass.UpdateRegisAdm += UpdateAdminEventHandler;

                // tampilkan form entry mahasiswa
                frmUbahPass.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void btnPerbaiki_Click(object sender, EventArgs e)
        {
            if (lvwListAdmin.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Admin adm = listAdmin[lvwListAdmin.SelectedIndices[0]];

                // buat objek form entry data mahasiswa
                FormRegistrasiAdmin frmUbahAdmin = new FormRegistrasiAdmin("Perbaiki Data Admin", adm, admController);

                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmUbahAdmin.UpdateRegis += UpdateAdminEventHandler;

                // tampilkan form entry mahasiswa
                frmUbahAdmin.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }
    }
}
