using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Transaksi_PreOrder.Model.Entity;
using Transaksi_PreOrder.Model.Repository;
using Transaksi_PreOrder.Model.Context;

namespace Transaksi_PreOrder.Controller
{
    public class BarangController
    {
        //objek CRUD
        private BarangRepository _repository;

        //tampil semua
        public List<Barang> ReadAll()
        {
            //collection barang
            List<Barang> list = new List<Barang>();


            //nambah blok context
            using (DbContext context = new DbContext())
            {
                _repository = new BarangRepository(context);

                list = _repository.ReadAll();
            }

            return list;
        
        }
    }
}
