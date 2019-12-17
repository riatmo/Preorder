using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaksi_PreOrder.Model.Entity
{
    public class DetailPesanan
    {
        public string KdDetail { get; set; }
        public string KdBarang { get; set; }
        public string KdPesanan { get; set; }
        public int Qty { get; set; }
        public int Subtotal { get; set; }
    }
}
