using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transaksi_PreOrder
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
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
    }
}
