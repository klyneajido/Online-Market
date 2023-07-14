namespace PALENGKE_APP
{
    partial class login_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_form));
            this.gradientPanel1 = new PALENGKE_APP.GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.combobox_log = new System.Windows.Forms.ComboBox();
            this.signup_lbl = new System.Windows.Forms.Label();
            this.showPassword_cb = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.password_lbl = new System.Windows.Forms.Label();
            this.username_tb = new System.Windows.Forms.TextBox();
            this.username_lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.login_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 50F;
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(69)))), ((int)(((byte)(62)))));
            this.gradientPanel1.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.pictureBox1);
            this.gradientPanel1.Controls.Add(this.combobox_log);
            this.gradientPanel1.Controls.Add(this.signup_lbl);
            this.gradientPanel1.Controls.Add(this.showPassword_cb);
            this.gradientPanel1.Controls.Add(this.button1);
            this.gradientPanel1.Controls.Add(this.password_tb);
            this.gradientPanel1.Controls.Add(this.password_lbl);
            this.gradientPanel1.Controls.Add(this.username_tb);
            this.gradientPanel1.Controls.Add(this.username_lbl);
            this.gradientPanel1.Controls.Add(this.panel1);
            this.gradientPanel1.Controls.Add(this.login_lbl);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(790, 488);
            this.gradientPanel1.TabIndex = 0;
            this.gradientPanel1.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(254)))), ((int)(((byte)(189)))));
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(753, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 35);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // combobox_log
            // 
            this.combobox_log.AutoCompleteCustomSource.AddRange(new string[] {
            "Buyer",
            "Seller",
            "Admin"});
            this.combobox_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combobox_log.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_log.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.combobox_log.FormattingEnabled = true;
            this.combobox_log.Items.AddRange(new object[] {
            "Customer",
            "Seller",
            "Admin"});
            this.combobox_log.Location = new System.Drawing.Point(576, 125);
            this.combobox_log.Name = "combobox_log";
            this.combobox_log.Size = new System.Drawing.Size(110, 29);
            this.combobox_log.TabIndex = 0;
            this.combobox_log.Text = "Select Role";
            // 
            // signup_lbl
            // 
            this.signup_lbl.AutoSize = true;
            this.signup_lbl.BackColor = System.Drawing.Color.Transparent;
            this.signup_lbl.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_lbl.Location = new System.Drawing.Point(434, 422);
            this.signup_lbl.Name = "signup_lbl";
            this.signup_lbl.Size = new System.Drawing.Size(191, 17);
            this.signup_lbl.TabIndex = 8;
            this.signup_lbl.Text = "Don\'t have an account yet?";
            this.signup_lbl.Click += new System.EventHandler(this.signup_lbl_Click);
            this.signup_lbl.MouseLeave += new System.EventHandler(this.signup_lbl_MouseLeave);
            this.signup_lbl.MouseHover += new System.EventHandler(this.signup_lbl_MouseHover);
            // 
            // showPassword_cb
            // 
            this.showPassword_cb.AutoSize = true;
            this.showPassword_cb.BackColor = System.Drawing.Color.Transparent;
            this.showPassword_cb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword_cb.Location = new System.Drawing.Point(360, 297);
            this.showPassword_cb.Name = "showPassword_cb";
            this.showPassword_cb.Size = new System.Drawing.Size(128, 21);
            this.showPassword_cb.TabIndex = 7;
            this.showPassword_cb.Text = "Show password";
            this.showPassword_cb.UseVisualStyleBackColor = false;
            this.showPassword_cb.CheckedChanged += new System.EventHandler(this.showPassword_cb_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(600, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // password_tb
            // 
            this.password_tb.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_tb.Location = new System.Drawing.Point(360, 260);
            this.password_tb.Name = "password_tb";
            this.password_tb.Size = new System.Drawing.Size(326, 31);
            this.password_tb.TabIndex = 5;
            // 
            // password_lbl
            // 
            this.password_lbl.AutoSize = true;
            this.password_lbl.BackColor = System.Drawing.Color.Transparent;
            this.password_lbl.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_lbl.ForeColor = System.Drawing.Color.White;
            this.password_lbl.Location = new System.Drawing.Point(356, 224);
            this.password_lbl.Name = "password_lbl";
            this.password_lbl.Size = new System.Drawing.Size(104, 24);
            this.password_lbl.TabIndex = 4;
            this.password_lbl.Text = "Password";
            // 
            // username_tb
            // 
            this.username_tb.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_tb.Location = new System.Drawing.Point(360, 166);
            this.username_tb.Name = "username_tb";
            this.username_tb.Size = new System.Drawing.Size(326, 31);
            this.username_tb.TabIndex = 3;
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.BackColor = System.Drawing.Color.Transparent;
            this.username_lbl.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_lbl.ForeColor = System.Drawing.Color.White;
            this.username_lbl.Location = new System.Drawing.Point(356, 130);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(113, 24);
            this.username_lbl.TabIndex = 2;
            this.username_lbl.Text = "Username";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(69)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 488);
            this.panel1.TabIndex = 1;
            // 
            // login_lbl
            // 
            this.login_lbl.AutoSize = true;
            this.login_lbl.BackColor = System.Drawing.Color.Transparent;
            this.login_lbl.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.login_lbl.ForeColor = System.Drawing.Color.White;
            this.login_lbl.Location = new System.Drawing.Point(456, 60);
            this.login_lbl.Name = "login_lbl";
            this.login_lbl.Size = new System.Drawing.Size(135, 47);
            this.login_lbl.TabIndex = 0;
            this.login_lbl.Text = "Log in";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 77);
            this.label1.TabIndex = 1;
            this.label1.Text = "FRESH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 77);
            this.label2.TabIndex = 2;
            this.label2.Text = "CART";
            // 
            // login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 488);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "login_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.login_form_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label login_lbl;
        private System.Windows.Forms.TextBox password_tb;
        private System.Windows.Forms.Label password_lbl;
        private System.Windows.Forms.TextBox username_tb;
        private System.Windows.Forms.Label username_lbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox showPassword_cb;
        private System.Windows.Forms.Label signup_lbl;
        private System.Windows.Forms.ComboBox combobox_log;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

