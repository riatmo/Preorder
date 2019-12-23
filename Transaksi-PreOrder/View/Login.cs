using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Transaksi_PreOrder.Controller;

namespace Transaksi_PreOrder
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        internal class AdminInfo
        {
            public static string CurrentLoggedInAdmin {
                get;
                set;
            }
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        public void btnLoginAppForm_Click(object sender, EventArgs e)
        {
            AdminController controller = new AdminController();

            string kodeAdmin = controller.KodeAdmin(txtUsername.Text, txtPassword.Text);
            AdminInfo.CurrentLoggedInAdmin = kodeAdmin;

            

            bool IsValidAdmin = controller.IsValidAdmin(txtUsername.Text, txtPassword.Text);
            if (IsValidAdmin)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
