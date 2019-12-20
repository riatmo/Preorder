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
        //public delegate void CreateUpdateHandler(Barang brg);

        //event tambah data
       // public event CreateUpdateHandler Create;

        //event update data
        //public event CreateUpdateHandler Update;

        //objek kontraoller
        //private BarangController 



        public EntryBarang()
        {
            InitializeComponent();
        }
    }
}
