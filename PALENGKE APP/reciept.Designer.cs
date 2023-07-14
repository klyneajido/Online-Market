namespace PALENGKE_APP
{
    partial class reciept
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_bought = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.total_lbl = new System.Windows.Forms.Label();
            this.gradientPanel1 = new PALENGKE_APP.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bought)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridView_bought);
            this.panel1.Controls.Add(this.date);
            this.panel1.Controls.Add(this.total);
            this.panel1.Controls.Add(this.total_lbl);
            this.panel1.Controls.Add(this.gradientPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 464);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView_bought
            // 
            this.dataGridView_bought.AllowUserToAddRows = false;
            this.dataGridView_bought.AllowUserToDeleteRows = false;
            this.dataGridView_bought.AllowUserToResizeColumns = false;
            this.dataGridView_bought.AllowUserToResizeRows = false;
            this.dataGridView_bought.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_bought.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_bought.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_bought.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_bought.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_bought.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_bought.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_bought.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_bought.GridColor = System.Drawing.Color.White;
            this.dataGridView_bought.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView_bought.Location = new System.Drawing.Point(3, 98);
            this.dataGridView_bought.Name = "dataGridView_bought";
            this.dataGridView_bought.RowHeadersVisible = false;
            this.dataGridView_bought.Size = new System.Drawing.Size(348, 302);
            this.dataGridView_bought.TabIndex = 6;
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(9, 73);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(56, 22);
            this.date.TabIndex = 4;
            this.date.Text = "Date";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(80, 417);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(21, 23);
            this.total.TabIndex = 4;
            this.total.Text = "0";
            // 
            // total_lbl
            // 
            this.total_lbl.AutoSize = true;
            this.total_lbl.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_lbl.Location = new System.Drawing.Point(9, 417);
            this.total_lbl.Name = "total_lbl";
            this.total_lbl.Size = new System.Drawing.Size(76, 23);
            this.total_lbl.TabIndex = 3;
            this.total_lbl.Text = "Total: ₱";
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 0F;
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(80)))), ((int)(((byte)(82)))));
            this.gradientPanel1.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(354, 60);
            this.gradientPanel1.TabIndex = 0;
            this.gradientPanel1.TopColor = System.Drawing.Color.Empty;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "R e c i e p t";
            // 
            // reciept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 464);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "reciept";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reciept";
            this.Load += new System.EventHandler(this.reciept_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bought)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_bought;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label total_lbl;
    }
}