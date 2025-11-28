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
            this.DinputHbutton = new System.Windows.Forms.Button();
            this.Independent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dependent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtPageHeader = new System.Windows.Forms.TextBox();
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
            this.dataInputGrid.Location = new System.Drawing.Point(69, 148);
            this.dataInputGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataInputGrid.Name = "dataInputGrid";
            this.dataInputGrid.RowHeadersWidth = 51;
            this.dataInputGrid.RowTemplate.Height = 24;
            this.dataInputGrid.ShowEditingIcon = false;
            this.dataInputGrid.Size = new System.Drawing.Size(457, 471);
            this.dataInputGrid.TabIndex = 0;
            // 
            // DinputHbutton
            // 
            this.DinputHbutton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DinputHbutton.Location = new System.Drawing.Point(46, 29);
            this.DinputHbutton.Name = "DinputHbutton";
            this.DinputHbutton.Size = new System.Drawing.Size(182, 49);
            this.DinputHbutton.TabIndex = 1;
            this.DinputHbutton.Text = "Home";
            this.DinputHbutton.UseVisualStyleBackColor = true;
            this.DinputHbutton.Click += new System.EventHandler(this.DinputHbutton_Click);
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
            // DtPageHeader
            // 
            this.DtPageHeader.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DtPageHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DtPageHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtPageHeader.Location = new System.Drawing.Point(476, 41);
            this.DtPageHeader.Name = "DtPageHeader";
            this.DtPageHeader.Size = new System.Drawing.Size(331, 35);
            this.DtPageHeader.TabIndex = 2;
            this.DtPageHeader.Text = "Input Your Data";
            this.DtPageHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DataInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.DtPageHeader);
            this.Controls.Add(this.DinputHbutton);
            this.Controls.Add(this.dataInputGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}