namespace Transaksi_PreOrder
{
    partial class FormListAdmin
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPerbaiki = new System.Windows.Forms.Button();
            this.btnSelesai = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnGantiPass = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lvwListAdmin = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCariNamaAdmin = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.btnPerbaiki, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSelesai, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnHapus, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnGantiPass, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(12, 483);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(718, 38);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // btnPerbaiki
            // 
            this.btnPerbaiki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPerbaiki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(0)))));
            this.btnPerbaiki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerbaiki.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerbaiki.Location = new System.Drawing.Point(3, 7);
            this.btnPerbaiki.Name = "btnPerbaiki";
            this.btnPerbaiki.Size = new System.Drawing.Size(173, 23);
            this.btnPerbaiki.TabIndex = 3;
            this.btnPerbaiki.Text = "Perbaiki";
            this.btnPerbaiki.UseVisualStyleBackColor = false;
            this.btnPerbaiki.Click += new System.EventHandler(this.btnPerbaiki_Click);
            // 
            // btnSelesai
            // 
            this.btnSelesai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelesai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(0)))));
            this.btnSelesai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelesai.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelesai.Location = new System.Drawing.Point(540, 7);
            this.btnSelesai.Name = "btnSelesai";
            this.btnSelesai.Size = new System.Drawing.Size(175, 23);
            this.btnSelesai.TabIndex = 0;
            this.btnSelesai.Text = "Selesai";
            this.btnSelesai.UseVisualStyleBackColor = false;
            this.btnSelesai.Click += new System.EventHandler(this.btnSelesai_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHapus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(0)))));
            this.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapus.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Location = new System.Drawing.Point(361, 7);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(173, 23);
            this.btnHapus.TabIndex = 1;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnGantiPass
            // 
            this.btnGantiPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGantiPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(0)))));
            this.btnGantiPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGantiPass.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGantiPass.Location = new System.Drawing.Point(182, 7);
            this.btnGantiPass.Name = "btnGantiPass";
            this.btnGantiPass.Size = new System.Drawing.Size(173, 23);
            this.btnGantiPass.TabIndex = 2;
            this.btnGantiPass.Text = "Ganti Password";
            this.btnGantiPass.UseVisualStyleBackColor = false;
            this.btnGantiPass.Click += new System.EventHandler(this.btnGantiPass_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lvwListAdmin, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 100);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(718, 377);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // lvwListAdmin
            // 
            this.lvwListAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwListAdmin.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwListAdmin.Location = new System.Drawing.Point(3, 3);
            this.lvwListAdmin.Name = "lvwListAdmin";
            this.lvwListAdmin.Size = new System.Drawing.Size(712, 370);
            this.lvwListAdmin.TabIndex = 0;
            this.lvwListAdmin.UseCompatibleStateImageBehavior = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(718, 44);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.label12);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 36);
            this.panel1.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(306, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 23);
            this.label12.TabIndex = 26;
            this.label12.Text = "LIST ADMIN";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.14763F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.85237F));
            this.tableLayoutPanel1.Controls.Add(this.txtCariNamaAdmin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCari, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 62);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(718, 32);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // txtCariNamaAdmin
            // 
            this.txtCariNamaAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCariNamaAdmin.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCariNamaAdmin.Location = new System.Drawing.Point(3, 5);
            this.txtCariNamaAdmin.Name = "txtCariNamaAdmin";
            this.txtCariNamaAdmin.Size = new System.Drawing.Size(590, 21);
            this.txtCariNamaAdmin.TabIndex = 0;
            this.txtCariNamaAdmin.Text = "Ketik nama admin yang ingin di cari ...";
            // 
            // btnCari
            // 
            this.btnCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(0)))));
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(599, 4);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(116, 23);
            this.btnCari.TabIndex = 1;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = false;
            // 
            // FormListAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(743, 534);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormListAdmin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "List Admin";
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnGantiPass;
        private System.Windows.Forms.Button btnSelesai;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListView lvwListAdmin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtCariNamaAdmin;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnPerbaiki;
    }
}