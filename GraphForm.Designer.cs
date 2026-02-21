namespace NEA
{
    partial class GraphForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelEquation = new System.Windows.Forms.Label();
            this.comboEditOptions = new System.Windows.Forms.ComboBox();
            this.btnapplyedit = new System.Windows.Forms.Button();
            this.txtAxisName = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 94);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1043, 538);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // labelEquation
            // 
            this.labelEquation.AutoSize = true;
            this.labelEquation.Location = new System.Drawing.Point(941, 185);
            this.labelEquation.Name = "labelEquation";
            this.labelEquation.Size = new System.Drawing.Size(0, 20);
            this.labelEquation.TabIndex = 1;
            // 
            // comboEditOptions
            // 
            this.comboEditOptions.FormattingEnabled = true;
            this.comboEditOptions.Location = new System.Drawing.Point(38, 12);
            this.comboEditOptions.Name = "comboEditOptions";
            this.comboEditOptions.Size = new System.Drawing.Size(212, 24);
            this.comboEditOptions.TabIndex = 2;
            this.comboEditOptions.SelectedIndexChanged += new System.EventHandler(this.comboEditOptions_SelectedIndexChanged);
            // 
            // btnapplyedit
            // 
            this.btnapplyedit.Location = new System.Drawing.Point(875, 27);
            this.btnapplyedit.Name = "btnapplyedit";
            this.btnapplyedit.Size = new System.Drawing.Size(119, 30);
            this.btnapplyedit.TabIndex = 3;
            this.btnapplyedit.Text = "Apply Edit";
            this.btnapplyedit.UseVisualStyleBackColor = true;
            this.btnapplyedit.Click += new System.EventHandler(this.btnapplyedit_Click);
            // 
            // txtAxisName
            // 
            this.txtAxisName.Location = new System.Drawing.Point(354, 14);
            this.txtAxisName.Name = "txtAxisName";
            this.txtAxisName.Size = new System.Drawing.Size(136, 22);
            this.txtAxisName.TabIndex = 4;
            this.txtAxisName.Text = "Enter new axis title";
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1074, 644);
            this.Controls.Add(this.txtAxisName);
            this.Controls.Add(this.btnapplyedit);
            this.Controls.Add(this.comboEditOptions);
            this.Controls.Add(this.labelEquation);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GraphForm";
            this.Text = "GraphForm";
            this.Load += new System.EventHandler(this.GraphForm_Load);
            this.Resize += new System.EventHandler(this.GraphForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label labelEquation;
        private System.Windows.Forms.ComboBox comboEditOptions;
        private System.Windows.Forms.Button btnapplyedit;
        private System.Windows.Forms.TextBox txtAxisName;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}