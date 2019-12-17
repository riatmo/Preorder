using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaksi_PreOrder.Model.Entity
{
    public class Pelanggan
    {
        public string KdPembeli { get; set; }
        public string Nama { get; set; }
        public string Hp { get; set; }
        public string Alamat { get; set; }
        public string Kecamatan { get; set; }
        public string Kabupaten { get; set; }
        public string Provinsi { get; set; }
        public string KodePos { get; set; }
    }
}
