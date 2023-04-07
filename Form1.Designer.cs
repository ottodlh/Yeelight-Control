namespace YControl
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbBrillo = new System.Windows.Forms.TrackBar();
            this.cdialog = new System.Windows.Forms.ColorDialog();
            this.lblBrillo = new System.Windows.Forms.Label();
            this.bwSinc = new System.ComponentModel.BackgroundWorker();
            this.lblstatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDevices = new System.Windows.Forms.ListBox();
            this.txtNuevaIp = new System.Windows.Forms.TextBox();
            this.tbTemperatura = new System.Windows.Forms.TrackBar();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.lblSuavidad = new System.Windows.Forms.Label();
            this.tbSuavidad = new System.Windows.Forms.TrackBar();
            this.tbSinc = new System.Windows.Forms.TrackBar();
            this.lblSinc = new System.Windows.Forms.Label();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.pColor = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yeelightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarAutomaticamenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbbxScreen = new YControl.tools.Cmbbx();
            this.btnAgregar = new YControl.btn();
            this.tbtnSinc = new YControl.tools.ToogleButton();
            this.iniciarSincronizarciónAutomaticamenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrillo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSuavidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSinc)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBrillo
            // 
            this.tbBrillo.Location = new System.Drawing.Point(11, 192);
            this.tbBrillo.Maximum = 100;
            this.tbBrillo.Minimum = 10;
            this.tbBrillo.Name = "tbBrillo";
            this.tbBrillo.Size = new System.Drawing.Size(380, 45);
            this.tbBrillo.SmallChange = 5;
            this.tbBrillo.TabIndex = 5;
            this.tbBrillo.TickFrequency = 5;
            this.tbBrillo.Value = 100;
            this.tbBrillo.Scroll += new System.EventHandler(this.tbBrillo_Scroll);
            // 
            // lblBrillo
            // 
            this.lblBrillo.AutoSize = true;
            this.lblBrillo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrillo.Location = new System.Drawing.Point(13, 165);
            this.lblBrillo.Name = "lblBrillo";
            this.lblBrillo.Size = new System.Drawing.Size(101, 24);
            this.lblBrillo.TabIndex = 6;
            this.lblBrillo.Text = "Brillo 100%";
            // 
            // bwSinc
            // 
            this.bwSinc.WorkerReportsProgress = true;
            this.bwSinc.WorkerSupportsCancellation = true;
            this.bwSinc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSinc_DoWork);
            this.bwSinc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSinc_ProgressChanged);
            this.bwSinc.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSinc_RunWorkerCompleted);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(114, 499);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(0, 13);
            this.lblstatus.TabIndex = 7;
            this.lblstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sincronizar pantalla";
            // 
            // lstDevices
            // 
            this.lstDevices.FormattingEnabled = true;
            this.lstDevices.Location = new System.Drawing.Point(399, 97);
            this.lstDevices.Name = "lstDevices";
            this.lstDevices.Size = new System.Drawing.Size(170, 121);
            this.lstDevices.TabIndex = 19;
            this.lstDevices.SelectedIndexChanged += new System.EventHandler(this.lstDevices_SelectedIndexChanged);
            this.lstDevices.DoubleClick += new System.EventHandler(this.lstDevices_DoubleClick);
            // 
            // txtNuevaIp
            // 
            this.txtNuevaIp.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNuevaIp.Location = new System.Drawing.Point(399, 71);
            this.txtNuevaIp.Name = "txtNuevaIp";
            this.txtNuevaIp.Size = new System.Drawing.Size(105, 20);
            this.txtNuevaIp.TabIndex = 20;
            this.txtNuevaIp.Text = "Nuevo Dispositivo";
            this.txtNuevaIp.Enter += new System.EventHandler(this.txtNuevaIp_Enter);
            this.txtNuevaIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuevaIp_KeyPress);
            this.txtNuevaIp.Leave += new System.EventHandler(this.txtNuevaIp_Leave);
            // 
            // tbTemperatura
            // 
            this.tbTemperatura.LargeChange = 10;
            this.tbTemperatura.Location = new System.Drawing.Point(11, 267);
            this.tbTemperatura.Maximum = 6500;
            this.tbTemperatura.Minimum = 1700;
            this.tbTemperatura.Name = "tbTemperatura";
            this.tbTemperatura.Size = new System.Drawing.Size(380, 45);
            this.tbTemperatura.SmallChange = 10;
            this.tbTemperatura.TabIndex = 22;
            this.tbTemperatura.TickFrequency = 10;
            this.tbTemperatura.Value = 6500;
            this.tbTemperatura.Scroll += new System.EventHandler(this.tbTemperatura_Scroll);
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperatura.Location = new System.Drawing.Point(13, 236);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(163, 24);
            this.lblTemperatura.TabIndex = 23;
            this.lblTemperatura.Text = "Temperatura 6500";
            // 
            // lblSuavidad
            // 
            this.lblSuavidad.AutoSize = true;
            this.lblSuavidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuavidad.Location = new System.Drawing.Point(13, 315);
            this.lblSuavidad.Name = "lblSuavidad";
            this.lblSuavidad.Size = new System.Drawing.Size(123, 24);
            this.lblSuavidad.TabIndex = 27;
            this.lblSuavidad.Text = "Suavidad 500";
            // 
            // tbSuavidad
            // 
            this.tbSuavidad.Location = new System.Drawing.Point(11, 342);
            this.tbSuavidad.Maximum = 1000;
            this.tbSuavidad.Minimum = 20;
            this.tbSuavidad.Name = "tbSuavidad";
            this.tbSuavidad.Size = new System.Drawing.Size(380, 45);
            this.tbSuavidad.SmallChange = 10;
            this.tbSuavidad.TabIndex = 26;
            this.tbSuavidad.TickFrequency = 10;
            this.tbSuavidad.Value = 500;
            this.tbSuavidad.Scroll += new System.EventHandler(this.tbSuavidad_Scroll);
            // 
            // tbSinc
            // 
            this.tbSinc.LargeChange = 10;
            this.tbSinc.Location = new System.Drawing.Point(11, 417);
            this.tbSinc.Maximum = 1000;
            this.tbSinc.Minimum = 50;
            this.tbSinc.Name = "tbSinc";
            this.tbSinc.Size = new System.Drawing.Size(380, 45);
            this.tbSinc.SmallChange = 10;
            this.tbSinc.TabIndex = 28;
            this.tbSinc.TickFrequency = 10;
            this.tbSinc.Value = 50;
            this.tbSinc.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblSinc
            // 
            this.lblSinc.AutoSize = true;
            this.lblSinc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinc.Location = new System.Drawing.Point(13, 390);
            this.lblSinc.Name = "lblSinc";
            this.lblSinc.Size = new System.Drawing.Size(131, 24);
            this.lblSinc.TabIndex = 29;
            this.lblSinc.Text = "Frecuencia 50";
            // 
            // lblMonitor
            // 
            this.lblMonitor.AutoSize = true;
            this.lblMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonitor.Location = new System.Drawing.Point(13, 89);
            this.lblMonitor.Name = "lblMonitor";
            this.lblMonitor.Size = new System.Drawing.Size(73, 24);
            this.lblMonitor.TabIndex = 33;
            this.lblMonitor.Text = "Monitor";
            // 
            // pColor
            // 
            this.pColor.Location = new System.Drawing.Point(17, 455);
            this.pColor.Name = "pColor";
            this.pColor.Size = new System.Drawing.Size(559, 30);
            this.pColor.TabIndex = 34;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeelightToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // yeelightToolStripMenuItem
            // 
            this.yeelightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarAutomaticamenteToolStripMenuItem,
            this.iniciarSincronizarciónAutomaticamenteToolStripMenuItem});
            this.yeelightToolStripMenuItem.Name = "yeelightToolStripMenuItem";
            this.yeelightToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.yeelightToolStripMenuItem.Text = "Yeelight";
            // 
            // iniciarAutomaticamenteToolStripMenuItem
            // 
            this.iniciarAutomaticamenteToolStripMenuItem.CheckOnClick = true;
            this.iniciarAutomaticamenteToolStripMenuItem.Name = "iniciarAutomaticamenteToolStripMenuItem";
            this.iniciarAutomaticamenteToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.iniciarAutomaticamenteToolStripMenuItem.Text = "Iniciar con Windows";
            this.iniciarAutomaticamenteToolStripMenuItem.CheckedChanged += new System.EventHandler(this.iniciarAutomaticamenteToolStripMenuItem_CheckedChanged);
            // 
            // cmbbxScreen
            // 
            this.cmbbxScreen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbbxScreen.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cmbbxScreen.BorderSize = 1;
            this.cmbbxScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbbxScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbbxScreen.ForeColor = System.Drawing.Color.DimGray;
            this.cmbbxScreen.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cmbbxScreen.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cmbbxScreen.ListTextColor = System.Drawing.Color.DimGray;
            this.cmbbxScreen.Location = new System.Drawing.Point(11, 121);
            this.cmbbxScreen.MinimumSize = new System.Drawing.Size(200, 30);
            this.cmbbxScreen.Name = "cmbbxScreen";
            this.cmbbxScreen.Padding = new System.Windows.Forms.Padding(1);
            this.cmbbxScreen.Size = new System.Drawing.Size(380, 30);
            this.cmbbxScreen.TabIndex = 32;
            this.cmbbxScreen.Texts = "";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.BackgroundColor = System.Drawing.Color.Green;
            this.btnAgregar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAgregar.BorderRadius = 10;
            this.btnAgregar.BorderSize = 0;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(510, 66);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(59, 29);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // tbtnSinc
            // 
            this.tbtnSinc.AutoSize = true;
            this.tbtnSinc.Location = new System.Drawing.Point(11, 42);
            this.tbtnSinc.MinimumSize = new System.Drawing.Size(45, 22);
            this.tbtnSinc.Name = "tbtnSinc";
            this.tbtnSinc.OffBackColor = System.Drawing.Color.LightGray;
            this.tbtnSinc.OffToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tbtnSinc.OnBackColor = System.Drawing.SystemColors.Highlight;
            this.tbtnSinc.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tbtnSinc.Size = new System.Drawing.Size(45, 22);
            this.tbtnSinc.TabIndex = 12;
            this.tbtnSinc.UseVisualStyleBackColor = true;
            this.tbtnSinc.CheckedChanged += new System.EventHandler(this.tbtnSinc_CheckedChanged);
            // 
            // iniciarSincronizarciónAutomaticamenteToolStripMenuItem
            // 
            this.iniciarSincronizarciónAutomaticamenteToolStripMenuItem.CheckOnClick = true;
            this.iniciarSincronizarciónAutomaticamenteToolStripMenuItem.Name = "iniciarSincronizarciónAutomaticamenteToolStripMenuItem";
            this.iniciarSincronizarciónAutomaticamenteToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.iniciarSincronizarciónAutomaticamenteToolStripMenuItem.Text = "Iniciar sincronizarción Automaticamente";
            this.iniciarSincronizarciónAutomaticamenteToolStripMenuItem.CheckedChanged += new System.EventHandler(this.iniciarSincronizarciónAutomaticamenteToolStripMenuItem_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(591, 497);
            this.Controls.Add(this.pColor);
            this.Controls.Add(this.lblMonitor);
            this.Controls.Add(this.cmbbxScreen);
            this.Controls.Add(this.lblSinc);
            this.Controls.Add(this.tbSinc);
            this.Controls.Add(this.lblSuavidad);
            this.Controls.Add(this.tbSuavidad);
            this.Controls.Add(this.lblTemperatura);
            this.Controls.Add(this.tbTemperatura);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNuevaIp);
            this.Controls.Add(this.lstDevices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbtnSinc);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.lblBrillo);
            this.Controls.Add(this.tbBrillo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeelight Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbBrillo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSuavidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSinc)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar tbBrillo;
        private System.Windows.Forms.ColorDialog cdialog;
        private System.Windows.Forms.Label lblBrillo;
        private System.ComponentModel.BackgroundWorker bwSinc;
        private System.Windows.Forms.Label lblstatus;
        private tools.ToogleButton tbtnSinc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstDevices;
        private System.Windows.Forms.TextBox txtNuevaIp;
        private btn btnAgregar;
        private System.Windows.Forms.TrackBar tbTemperatura;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.Label lblSuavidad;
        private System.Windows.Forms.TrackBar tbSuavidad;
        private System.Windows.Forms.TrackBar tbSinc;
        private System.Windows.Forms.Label lblSinc;
        private tools.Cmbbx cmbbxScreen;
        private System.Windows.Forms.Label lblMonitor;
        private System.Windows.Forms.Panel pColor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeelightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarAutomaticamenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSincronizarciónAutomaticamenteToolStripMenuItem;
    }
}

