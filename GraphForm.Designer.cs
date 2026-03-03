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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelEquation = new System.Windows.Forms.Label();
            this.comboEditOptions = new System.Windows.Forms.ComboBox();
            this.btnapplyedit = new System.Windows.Forms.Button();
            this.txtAxisName = new System.Windows.Forms.TextBox();
            this.colourChange = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            this.SuspendLayout();
            // 
            // graph
            // 
            chartArea1.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graph.Legends.Add(legend1);
            this.graph.Location = new System.Drawing.Point(12, 80);
            this.graph.Name = "graph";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graph.Series.Add(series1);
            this.graph.Size = new System.Drawing.Size(1043, 552);
            this.graph.TabIndex = 0;
            this.graph.Text = "chart1";
            // 
            // labelEquation
            // 
            this.labelEquation.AutoSize = true;
            this.labelEquation.Location = new System.Drawing.Point(941, 185);
            this.labelEquation.Name = "labelEquation";
            this.labelEquation.Size = new System.Drawing.Size(0, 16);
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
            this.Controls.Add(this.graph);
            this.Controls.Add(this.txtAxisName);
            this.Controls.Add(this.btnapplyedit);
            this.Controls.Add(this.comboEditOptions);
            this.Controls.Add(this.labelEquation);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GraphForm";
            this.Text = "GraphForm";
            this.Load += new System.EventHandler(this.GraphForm_Load);
            this.Resize += new System.EventHandler(this.GraphForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graph;
        private System.Windows.Forms.Label labelEquation;
        private System.Windows.Forms.ComboBox comboEditOptions;
        private System.Windows.Forms.Button btnapplyedit;
        private System.Windows.Forms.TextBox txtAxisName;
        private System.Windows.Forms.ColorDialog colourChange;
    }
}