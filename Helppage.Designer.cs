namespace NEA
{
    partial class UserGuide
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
            this.hmbtn_ug = new System.Windows.Forms.Button();
            this.ug_txtb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // hmbtn_ug
            // 
            this.hmbtn_ug.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.hmbtn_ug.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hmbtn_ug.Location = new System.Drawing.Point(12, 24);
            this.hmbtn_ug.Name = "hmbtn_ug";
            this.hmbtn_ug.Size = new System.Drawing.Size(124, 28);
            this.hmbtn_ug.TabIndex = 0;
            this.hmbtn_ug.Text = "Home";
            this.hmbtn_ug.UseVisualStyleBackColor = false;
            // 
            // ug_txtb
            // 
            this.ug_txtb.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ug_txtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ug_txtb.Font = new System.Drawing.Font("Lucida Calligraphy", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ug_txtb.Location = new System.Drawing.Point(239, 24);
            this.ug_txtb.Name = "ug_txtb";
            this.ug_txtb.Size = new System.Drawing.Size(337, 48);
            this.ug_txtb.TabIndex = 1;
            this.ug_txtb.Text = "User Guide";
            this.ug_txtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ug_txtb);
            this.Controls.Add(this.hmbtn_ug);
            this.Name = "UserGuide";
            this.Text = " Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hmbtn_ug;
        private System.Windows.Forms.TextBox ug_txtb;
    }
}