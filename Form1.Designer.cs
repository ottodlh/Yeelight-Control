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
            this.pColor = new System.Windows.Forms.Panel();
            this.btn_Color = new YControl.btn();
            this.btn_Apagar = new YControl.btn();
            this.btn_Encender = new YControl.btn();
            this.tbtnSinc = new YControl.tools.ToogleButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrillo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbBrillo
            // 
            this.tbBrillo.Location = new System.Drawing.Point(13, 49);
            this.tbBrillo.Maximum = 100;
            this.tbBrillo.Name = "tbBrillo";
            this.tbBrillo.Size = new System.Drawing.Size(380, 45);
            this.tbBrillo.TabIndex = 5;
            this.tbBrillo.Value = 100;
            this.tbBrillo.Scroll += new System.EventHandler(this.tbBrillo_Scroll);
            // 
            // lblBrillo
            // 
            this.lblBrillo.AutoSize = true;
            this.lblBrillo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrillo.Location = new System.Drawing.Point(292, 9);
            this.lblBrillo.Name = "lblBrillo";
            this.lblBrillo.Size = new System.Drawing.Size(101, 24);
            this.lblBrillo.TabIndex = 6;
            this.lblBrillo.Text = "Brillo 100%";
            this.lblBrillo.Click += new System.EventHandler(this.lblBrillo_Click);
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
            this.lblstatus.Location = new System.Drawing.Point(268, 103);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(0, 13);
            this.lblstatus.TabIndex = 7;
            this.lblstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pColor
            // 
            this.pColor.Location = new System.Drawing.Point(13, 81);
            this.pColor.Name = "pColor";
            this.pColor.Size = new System.Drawing.Size(380, 13);
            this.pColor.TabIndex = 8;
            // 
            // btn_Color
            // 
            this.btn_Color.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Color.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_Color.BorderRadius = 10;
            this.btn_Color.BorderSize = 0;
            this.btn_Color.FlatAppearance.BorderSize = 0;
            this.btn_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Color.ForeColor = System.Drawing.Color.White;
            this.btn_Color.Location = new System.Drawing.Point(186, 100);
            this.btn_Color.Name = "btn_Color";
            this.btn_Color.Size = new System.Drawing.Size(82, 29);
            this.btn_Color.TabIndex = 11;
            this.btn_Color.Text = "Color";
            this.btn_Color.UseVisualStyleBackColor = false;
            this.btn_Color.Click += new System.EventHandler(this.btn_Color_Click);
            // 
            // btn_Apagar
            // 
            this.btn_Apagar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Apagar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_Apagar.BorderRadius = 10;
            this.btn_Apagar.BorderSize = 0;
            this.btn_Apagar.FlatAppearance.BorderSize = 0;
            this.btn_Apagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Apagar.ForeColor = System.Drawing.Color.White;
            this.btn_Apagar.Location = new System.Drawing.Point(101, 100);
            this.btn_Apagar.Name = "btn_Apagar";
            this.btn_Apagar.Size = new System.Drawing.Size(82, 29);
            this.btn_Apagar.TabIndex = 10;
            this.btn_Apagar.Text = "Apagar";
            this.btn_Apagar.UseVisualStyleBackColor = false;
            this.btn_Apagar.Click += new System.EventHandler(this.btn_Apagar_Click);
            // 
            // btn_Encender
            // 
            this.btn_Encender.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Encender.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_Encender.BorderRadius = 10;
            this.btn_Encender.BorderSize = 0;
            this.btn_Encender.FlatAppearance.BorderSize = 0;
            this.btn_Encender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Encender.ForeColor = System.Drawing.Color.White;
            this.btn_Encender.Location = new System.Drawing.Point(13, 100);
            this.btn_Encender.Name = "btn_Encender";
            this.btn_Encender.Size = new System.Drawing.Size(82, 29);
            this.btn_Encender.TabIndex = 9;
            this.btn_Encender.Text = "Encender";
            this.btn_Encender.UseVisualStyleBackColor = false;
            this.btn_Encender.Click += new System.EventHandler(this.btn_Encender_Click);
            // 
            // tbtnSinc
            // 
            this.tbtnSinc.AutoSize = true;
            this.tbtnSinc.Location = new System.Drawing.Point(13, 21);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sincronizar pantalla";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(405, 139);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbtnSinc);
            this.Controls.Add(this.btn_Color);
            this.Controls.Add(this.btn_Apagar);
            this.Controls.Add(this.btn_Encender);
            this.Controls.Add(this.pColor);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.lblBrillo);
            this.Controls.Add(this.tbBrillo);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeelight Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tbBrillo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar tbBrillo;
        private System.Windows.Forms.ColorDialog cdialog;
        private System.Windows.Forms.Label lblBrillo;
        private System.ComponentModel.BackgroundWorker bwSinc;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Panel pColor;
        private btn btn_Encender;
        private btn btn_Apagar;
        private btn btn_Color;
        private tools.ToogleButton tbtnSinc;
        private System.Windows.Forms.Label label1;
    }
}

