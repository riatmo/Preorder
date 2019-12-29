namespace Transaksi_PreOrder
{
    partial class FormListDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwDetailPesanan = new System.Windows.Forms.ListView();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCariDetail = new System.Windows.Forms.Button();
            this.lblCariDetail = new System.Windows.Forms.Label();
            this.txtCariDetail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwDetailPesanan
            // 
            this.lvwDetailPesanan.HideSelection = false;
            this.lvwDetailPesanan.Location = new System.Drawing.Point(21, 36);
            this.lvwDetailPesanan.Name = "lvwDetailPesanan";
            this.lvwDetailPesanan.Size = new System.Drawing.Size(611, 332);
            this.lvwDetailPesanan.TabIndex = 0;
            this.lvwDetailPesanan.UseCompatibleStateImageBehavior = false;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(21, 383);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 1;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(122, 383);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(220, 383);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 3;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // btnCariDetail
            // 
            this.btnCariDetail.Location = new System.Drawing.Point(557, 9);
            this.btnCariDetail.Name = "btnCariDetail";
            this.btnCariDetail.Size = new System.Drawing.Size(75, 23);
            this.btnCariDetail.TabIndex = 4;
            this.btnCariDetail.Text = "Cari";
            this.btnCariDetail.UseVisualStyleBackColor = true;
            // 
            // lblCariDetail
            // 
            this.lblCariDetail.AutoSize = true;
            this.lblCariDetail.Location = new System.Drawing.Point(18, 12);
            this.lblCariDetail.Name = "lblCariDetail";
            this.lblCariDetail.Size = new System.Drawing.Size(98, 13);
            this.lblCariDetail.TabIndex = 5;
            this.lblCariDetail.Text = "Cari Kode Pesanan";
            // 
            // txtCariDetail
            // 
            this.txtCariDetail.Location = new System.Drawing.Point(122, 9);
            this.txtCariDetail.Name = "txtCariDetail";
            this.txtCariDetail.Size = new System.Drawing.Size(429, 20);
            this.txtCariDetail.TabIndex = 6;
            // 
            // FormListDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.Controls.Add(this.txtCariDetail);
            this.Controls.Add(this.lblCariDetail);
            this.Controls.Add(this.btnCariDetail);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.lvwDetailPesanan);
            this.Name = "FormListDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail Pesanan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDetailPesanan;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnCariDetail;
        private System.Windows.Forms.Label lblCariDetail;
        private System.Windows.Forms.TextBox txtCariDetail;
    }
}