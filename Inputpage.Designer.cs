namespace NEA
{
    partial class DataInput
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
            this.dataInputGrid = new System.Windows.Forms.DataGridView();
            this.Independent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dependent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinputHbutton = new System.Windows.Forms.Button();
            this.DtPageHeader = new System.Windows.Forms.TextBox();
            this.restartbtn = new System.Windows.Forms.Button();
            this.genstatsButton = new System.Windows.Forms.Button();
            this.GGraphButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataInputGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataInputGrid
            // 
            this.dataInputGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataInputGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataInputGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataInputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInputGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Independent,
            this.Dependent});
            this.dataInputGrid.GridColor = System.Drawing.Color.Black;
            this.dataInputGrid.Location = new System.Drawing.Point(61, 118);
            this.dataInputGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataInputGrid.Name = "dataInputGrid";
            this.dataInputGrid.RowHeadersWidth = 51;
            this.dataInputGrid.RowTemplate.Height = 24;
            this.dataInputGrid.ShowEditingIcon = false;
            this.dataInputGrid.Size = new System.Drawing.Size(403, 377);
            this.dataInputGrid.TabIndex = 0;
            this.dataInputGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataInputGrid_CellValidating);
            // 
            // Independent
            // 
            this.Independent.HeaderText = "Independent(X)";
            this.Independent.MinimumWidth = 6;
            this.Independent.Name = "Independent";
            this.Independent.Width = 125;
            // 
            // Dependent
            // 
            this.Dependent.HeaderText = "Dependent(Y)";
            this.Dependent.MinimumWidth = 6;
            this.Dependent.Name = "Dependent";
            this.Dependent.Width = 125;
            // 
            // DinputHbutton
            // 
            this.DinputHbutton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DinputHbutton.Location = new System.Drawing.Point(41, 23);
            this.DinputHbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DinputHbutton.Name = "DinputHbutton";
            this.DinputHbutton.Size = new System.Drawing.Size(161, 39);
            this.DinputHbutton.TabIndex = 1;
            this.DinputHbutton.Text = "Home";
            this.DinputHbutton.UseVisualStyleBackColor = true;
            this.DinputHbutton.Click += new System.EventHandler(this.DinputHbutton_Click);
            // 
            // DtPageHeader
            // 
            this.DtPageHeader.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DtPageHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DtPageHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtPageHeader.Location = new System.Drawing.Point(423, 33);
            this.DtPageHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtPageHeader.Name = "DtPageHeader";
            this.DtPageHeader.Size = new System.Drawing.Size(295, 35);
            this.DtPageHeader.TabIndex = 2;
            this.DtPageHeader.Text = "Input Your Data";
            this.DtPageHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // restartbtn
            // 
            this.restartbtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartbtn.Location = new System.Drawing.Point(101, 502);
            this.restartbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.restartbtn.Name = "restartbtn";
            this.restartbtn.Size = new System.Drawing.Size(312, 37);
            this.restartbtn.TabIndex = 3;
            this.restartbtn.Text = "Restart Table";
            this.restartbtn.UseVisualStyleBackColor = true;
            this.restartbtn.Click += new System.EventHandler(this.restartbtn_Click);
            // 
            // genstatsButton
            // 
            this.genstatsButton.Location = new System.Drawing.Point(708, 118);
            this.genstatsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.genstatsButton.Name = "genstatsButton";
            this.genstatsButton.Size = new System.Drawing.Size(176, 28);
            this.genstatsButton.TabIndex = 4;
            this.genstatsButton.Text = "Generate Statistics";
            this.genstatsButton.UseVisualStyleBackColor = true;
            this.genstatsButton.Click += new System.EventHandler(this.genstatsButton_Click);
            // 
            // GGraphButton
            // 
            this.GGraphButton.Location = new System.Drawing.Point(809, 472);
            this.GGraphButton.Name = "GGraphButton";
            this.GGraphButton.Size = new System.Drawing.Size(116, 23);
            this.GGraphButton.TabIndex = 5;
            this.GGraphButton.Text = "Generate Graph";
            this.GGraphButton.UseVisualStyleBackColor = true;
            // 
            // DataInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.GGraphButton);
            this.Controls.Add(this.genstatsButton);
            this.Controls.Add(this.restartbtn);
            this.Controls.Add(this.DtPageHeader);
            this.Controls.Add(this.DinputHbutton);
            this.Controls.Add(this.dataInputGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DataInput";
            this.Text = "DataInput";
            this.Load += new System.EventHandler(this.DataInput_Load);
            this.Resize += new System.EventHandler(this.DataInput_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataInputGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.DataGridView dataInputGrid;
        private System.Windows.Forms.Button DinputHbutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Independent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dependent;
        private System.Windows.Forms.TextBox DtPageHeader;
        private System.Windows.Forms.Button restartbtn;
        private System.Windows.Forms.Button genstatsButton;
        private System.Windows.Forms.Button GGraphButton;
    }
}