namespace NEA
{
    partial class first_page
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
            this.Welcm_btn = new System.Windows.Forms.Button();
            this.Help_butn = new System.Windows.Forms.Button();
            this.Program_Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Welcm_btn
            // 
            this.Welcm_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Welcm_btn.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Welcm_btn.Location = new System.Drawing.Point(363, 313);
            this.Welcm_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Welcm_btn.Name = "Welcm_btn";
            this.Welcm_btn.Size = new System.Drawing.Size(325, 48);
            this.Welcm_btn.TabIndex = 0;
            this.Welcm_btn.Text = "Begin Processing";
            this.Welcm_btn.UseVisualStyleBackColor = false;
            this.Welcm_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Help_butn
            // 
            this.Help_butn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Help_butn.CausesValidation = false;
            this.Help_butn.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Help_butn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Help_butn.Location = new System.Drawing.Point(363, 240);
            this.Help_butn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Help_butn.Name = "Help_butn";
            this.Help_butn.Size = new System.Drawing.Size(325, 47);
            this.Help_butn.TabIndex = 1;
            this.Help_butn.Text = "Help";
            this.Help_butn.UseVisualStyleBackColor = false;
            this.Help_butn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Program_Name
            // 
            this.Program_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Program_Name.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Program_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Program_Name.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Program_Name.Font = new System.Drawing.Font("Lucida Calligraphy", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Program_Name.Location = new System.Drawing.Point(212, 107);
            this.Program_Name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Program_Name.Multiline = true;
            this.Program_Name.Name = "Program_Name";
            this.Program_Name.Size = new System.Drawing.Size(613, 60);
            this.Program_Name.TabIndex = 2;
            this.Program_Name.Text = " Visium";
            this.Program_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Program_Name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // first_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1064, 553);
            this.Controls.Add(this.Program_Name);
            this.Controls.Add(this.Help_butn);
            this.Controls.Add(this.Welcm_btn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "first_page";
            this.Text = " Visium";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Welcm_btn;
        private System.Windows.Forms.Button Help_butn;
        private System.Windows.Forms.TextBox Program_Name;
    }
}

