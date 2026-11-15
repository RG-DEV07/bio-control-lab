namespace BioControlLab.frmR.frmr
{
    partial class frmReportes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportes));
            this.btnActualizar = new FontAwesome.Sharp.IconButton();
            this.lblTotalPacientes = new System.Windows.Forms.Label();
            this.lblTotalCitas = new System.Windows.Forms.Label();
            this.lblTotalExamenes = new System.Windows.Forms.Label();
            this.lblTotalInsumos = new System.Windows.Forms.Label();
            this.chartExamenes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCitas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlPacientes = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartExamenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCitas)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlPacientes.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.btnActualizar.IconColor = System.Drawing.Color.White;
            this.btnActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizar.IconSize = 20;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(1071, 172);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(229, 40);
            this.btnActualizar.TabIndex = 22;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblTotalPacientes
            // 
            this.lblTotalPacientes.AutoSize = true;
            this.lblTotalPacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPacientes.Location = new System.Drawing.Point(122, 43);
            this.lblTotalPacientes.Name = "lblTotalPacientes";
            this.lblTotalPacientes.Size = new System.Drawing.Size(20, 29);
            this.lblTotalPacientes.TabIndex = 23;
            this.lblTotalPacientes.Text = ".";
            this.lblTotalPacientes.Click += new System.EventHandler(this.lblTotalPacientes_Click);
            // 
            // lblTotalCitas
            // 
            this.lblTotalCitas.AutoSize = true;
            this.lblTotalCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCitas.Location = new System.Drawing.Point(127, 43);
            this.lblTotalCitas.Name = "lblTotalCitas";
            this.lblTotalCitas.Size = new System.Drawing.Size(20, 29);
            this.lblTotalCitas.TabIndex = 24;
            this.lblTotalCitas.Text = ".";
            this.lblTotalCitas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalCitas.Click += new System.EventHandler(this.lblTotalCitas_Click);
            // 
            // lblTotalExamenes
            // 
            this.lblTotalExamenes.AutoSize = true;
            this.lblTotalExamenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExamenes.Location = new System.Drawing.Point(124, 43);
            this.lblTotalExamenes.Name = "lblTotalExamenes";
            this.lblTotalExamenes.Size = new System.Drawing.Size(20, 29);
            this.lblTotalExamenes.TabIndex = 25;
            this.lblTotalExamenes.Text = ".";
            this.lblTotalExamenes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalInsumos
            // 
            this.lblTotalInsumos.AutoSize = true;
            this.lblTotalInsumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInsumos.Location = new System.Drawing.Point(131, 43);
            this.lblTotalInsumos.Name = "lblTotalInsumos";
            this.lblTotalInsumos.Size = new System.Drawing.Size(20, 29);
            this.lblTotalInsumos.TabIndex = 26;
            this.lblTotalInsumos.Text = ".";
            this.lblTotalInsumos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartExamenes
            // 
            chartArea3.Name = "ChartArea1";
            this.chartExamenes.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartExamenes.Legends.Add(legend3);
            this.chartExamenes.Location = new System.Drawing.Point(82, 41);
            this.chartExamenes.Name = "chartExamenes";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartExamenes.Series.Add(series3);
            this.chartExamenes.Size = new System.Drawing.Size(618, 312);
            this.chartExamenes.TabIndex = 27;
            this.chartExamenes.Text = "chart1";
            this.chartExamenes.Click += new System.EventHandler(this.chartExamenes_Click);
            // 
            // chartCitas
            // 
            chartArea4.Name = "ChartArea1";
            this.chartCitas.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartCitas.Legends.Add(legend4);
            this.chartCitas.Location = new System.Drawing.Point(741, 41);
            this.chartCitas.Name = "chartCitas";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartCitas.Series.Add(series4);
            this.chartCitas.Size = new System.Drawing.Size(613, 312);
            this.chartCitas.TabIndex = 28;
            this.chartCitas.Text = "chart2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.chartExamenes);
            this.panel1.Controls.Add(this.chartCitas);
            this.panel1.Location = new System.Drawing.Point(-43, 232);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1374, 391);
            this.panel1.TabIndex = 29;
            // 
            // pnlPacientes
            // 
            this.pnlPacientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlPacientes.Controls.Add(this.label1);
            this.pnlPacientes.Controls.Add(this.lblTotalPacientes);
            this.pnlPacientes.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPacientes.ForeColor = System.Drawing.Color.White;
            this.pnlPacientes.Location = new System.Drawing.Point(12, 12);
            this.pnlPacientes.Name = "pnlPacientes";
            this.pnlPacientes.Size = new System.Drawing.Size(280, 100);
            this.pnlPacientes.TabIndex = 30;
            this.pnlPacientes.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPacientes_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Pacientes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Examenes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "Citas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 30;
            this.label4.Text = "Insumos:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblTotalExamenes);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(300, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 100);
            this.panel3.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lblTotalCitas);
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(602, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(280, 100);
            this.panel4.TabIndex = 32;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Navy;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.lblTotalInsumos);
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(905, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(280, 100);
            this.panel5.TabIndex = 32;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 622);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlPacientes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnActualizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartExamenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCitas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlPacientes.ResumeLayout(false);
            this.pnlPacientes.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnActualizar;
        private System.Windows.Forms.Label lblTotalPacientes;
        private System.Windows.Forms.Label lblTotalCitas;
        private System.Windows.Forms.Label lblTotalExamenes;
        private System.Windows.Forms.Label lblTotalInsumos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartExamenes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCitas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlPacientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}