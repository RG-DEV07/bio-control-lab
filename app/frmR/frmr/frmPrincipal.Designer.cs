namespace BioControlLab
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuUsuario = new FontAwesome.Sharp.IconMenuItem();
            this.verDetallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Medicos = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem6 = new FontAwesome.Sharp.IconMenuItem();
            this.verDetallesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CITAS = new FontAwesome.Sharp.IconMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem5 = new FontAwesome.Sharp.IconMenuItem();
            this.insumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Proveedores = new FontAwesome.Sharp.IconMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUsuario,
            this.Medicos,
            this.iconMenuItem6,
            this.CITAS,
            this.iconMenuItem2,
            this.iconMenuItem5,
            this.Proveedores});
            this.menuStrip1.Location = new System.Drawing.Point(0, 59);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1012, 60);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuUsuario
            // 
            this.MenuUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetallesToolStripMenuItem});
            this.MenuUsuario.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.MenuUsuario.IconColor = System.Drawing.Color.Black;
            this.MenuUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuUsuario.IconSize = 45;
            this.MenuUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuUsuario.Name = "MenuUsuario";
            this.MenuUsuario.Size = new System.Drawing.Size(77, 56);
            this.MenuUsuario.Text = "PACIENTES";
            this.MenuUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuUsuario.Click += new System.EventHandler(this.iconMenuItem11_Click);
            // 
            // verDetallesToolStripMenuItem
            // 
            this.verDetallesToolStripMenuItem.Name = "verDetallesToolStripMenuItem";
            this.verDetallesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.verDetallesToolStripMenuItem.Text = "Ver detalles";
            this.verDetallesToolStripMenuItem.Click += new System.EventHandler(this.verDetallesToolStripMenuItem_Click);
            // 
            // Medicos
            // 
            this.Medicos.IconChar = FontAwesome.Sharp.IconChar.UserMd;
            this.Medicos.IconColor = System.Drawing.Color.Black;
            this.Medicos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Medicos.IconSize = 45;
            this.Medicos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Medicos.Name = "Medicos";
            this.Medicos.Size = new System.Drawing.Size(70, 56);
            this.Medicos.Text = "MEDICOS";
            this.Medicos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Medicos.Click += new System.EventHandler(this.Medicos_Click);
            // 
            // iconMenuItem6
            // 
            this.iconMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetallesToolStripMenuItem1});
            this.iconMenuItem6.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            this.iconMenuItem6.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem6.IconSize = 45;
            this.iconMenuItem6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconMenuItem6.Name = "iconMenuItem6";
            this.iconMenuItem6.Size = new System.Drawing.Size(66, 56);
            this.iconMenuItem6.Text = "EXAMEN";
            this.iconMenuItem6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconMenuItem6.Click += new System.EventHandler(this.iconMenuItem6_Click);
            // 
            // verDetallesToolStripMenuItem1
            // 
            this.verDetallesToolStripMenuItem1.Name = "verDetallesToolStripMenuItem1";
            this.verDetallesToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.verDetallesToolStripMenuItem1.Text = "Ver detalles";
            this.verDetallesToolStripMenuItem1.Click += new System.EventHandler(this.verDetallesToolStripMenuItem1_Click);
            // 
            // CITAS
            // 
            this.CITAS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.CITAS.IconChar = FontAwesome.Sharp.IconChar.CalendarDay;
            this.CITAS.IconColor = System.Drawing.Color.Black;
            this.CITAS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CITAS.IconSize = 45;
            this.CITAS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CITAS.Name = "CITAS";
            this.CITAS.Size = new System.Drawing.Size(57, 56);
            this.CITAS.Text = "CITAS";
            this.CITAS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CITAS.Click += new System.EventHandler(this.CITAS_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem1.Text = "Ver detalles";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // iconMenuItem2
            // 
            this.iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.iconMenuItem2.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem2.IconSize = 45;
            this.iconMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconMenuItem2.Name = "iconMenuItem2";
            this.iconMenuItem2.Size = new System.Drawing.Size(72, 56);
            this.iconMenuItem2.Text = "REPORTES";
            this.iconMenuItem2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconMenuItem2.Click += new System.EventHandler(this.iconMenuItem2_Click);
            // 
            // iconMenuItem5
            // 
            this.iconMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insumosToolStripMenuItem});
            this.iconMenuItem5.IconChar = FontAwesome.Sharp.IconChar.Archive;
            this.iconMenuItem5.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem5.IconSize = 45;
            this.iconMenuItem5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconMenuItem5.Name = "iconMenuItem5";
            this.iconMenuItem5.Size = new System.Drawing.Size(85, 56);
            this.iconMenuItem5.Text = "INVENTARIO";
            this.iconMenuItem5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconMenuItem5.Click += new System.EventHandler(this.iconMenuItem5_Click);
            // 
            // insumosToolStripMenuItem
            // 
            this.insumosToolStripMenuItem.Name = "insumosToolStripMenuItem";
            this.insumosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.insumosToolStripMenuItem.Text = "insumos";
            this.insumosToolStripMenuItem.Click += new System.EventHandler(this.insumosToolStripMenuItem_Click);
            // 
            // Proveedores
            // 
            this.Proveedores.IconChar = FontAwesome.Sharp.IconChar.ContactBook;
            this.Proveedores.IconColor = System.Drawing.Color.Black;
            this.Proveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Proveedores.IconSize = 45;
            this.Proveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Proveedores.Name = "Proveedores";
            this.Proveedores.Size = new System.Drawing.Size(84, 56);
            this.Proveedores.Text = "Proveedores";
            this.Proveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Proveedores.Click += new System.EventHandler(this.Proveedores_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1012, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(1012, 59);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sistema Clinico";
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(32, 19);
            this.iconMenuItem1.Text = "iconMenuItem1";
            // 
            // Contenedor
            // 
            this.Contenedor.BackColor = System.Drawing.Color.White;
            this.Contenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Contenedor.Location = new System.Drawing.Point(0, 122);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Contenedor.Size = new System.Drawing.Size(1012, 519);
            this.Contenedor.TabIndex = 4;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(770, 25);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 17);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 652);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem6;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem MenuUsuario;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem Medicos;
        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem1;
        private System.Windows.Forms.Label lblUsuario;
        private FontAwesome.Sharp.IconMenuItem CITAS;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem insumosToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem Proveedores;
    }
}