using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaksi_PreOrder.Model.Entity
{
    public class Barang
    {
        public string KdBarang { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
        public string Ukuran { get; set; }
        public string Warna { get; set; }
    }
}
