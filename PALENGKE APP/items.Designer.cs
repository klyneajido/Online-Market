namespace PALENGKE_APP
{
    partial class items
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(items));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.item_name = new System.Windows.Forms.Label();
            this.item_price = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.item_seller = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.item_qty = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 75);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // item_name
            // 
            this.item_name.AutoSize = true;
            this.item_name.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name.Location = new System.Drawing.Point(87, 13);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(40, 18);
            this.item_name.TabIndex = 9;
            this.item_name.Text = "Item";
            // 
            // item_price
            // 
            this.item_price.AutoSize = true;
            this.item_price.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_price.Location = new System.Drawing.Point(119, 56);
            this.item_price.Name = "item_price";
            this.item_price.Size = new System.Drawing.Size(54, 22);
            this.item_price.TabIndex = 10;
            this.item_price.Text = "Price";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(90, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 30);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.item_seller);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.item_qty);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.item_price);
            this.panel1.Controls.Add(this.item_name);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(4, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 123);
            this.panel1.TabIndex = 0;
            // 
            // item_seller
            // 
            this.item_seller.AutoSize = true;
            this.item_seller.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_seller.Location = new System.Drawing.Point(51, 97);
            this.item_seller.Name = "item_seller";
            this.item_seller.Size = new System.Drawing.Size(15, 17);
            this.item_seller.TabIndex = 15;
            this.item_seller.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Seller";
            // 
            // item_qty
            // 
            this.item_qty.AutoSize = true;
            this.item_qty.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_qty.Location = new System.Drawing.Point(51, 81);
            this.item_qty.Name = "item_qty";
            this.item_qty.Size = new System.Drawing.Size(15, 17);
            this.item_qty.TabIndex = 13;
            this.item_qty.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Stock:";
            // 
            // items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.panel1);
            this.Name = "items";
            this.Size = new System.Drawing.Size(206, 132);
            this.Load += new System.EventHandler(this.items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label item_name;
        private System.Windows.Forms.Label item_price;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label item_seller;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label item_qty;
        private System.Windows.Forms.Label label1;
    }
}
