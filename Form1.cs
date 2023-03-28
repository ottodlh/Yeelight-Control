using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            try
            {
                Color averageColor = GetAverageColor.GetColor();
                Encender("192.168.0.4", averageColor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Encender(string strIP, Color color)
        {
            YeelightControl yeelight = new YeelightControl(strIP);
            yeelight.TurnOn();
            yeelight.SetBrightness(tbBrillo.Value);
            yeelight.SetRGBColor(color.R, color.G, color.B);
            yeelight.DisposeClient();
            MuestraColor(color);
        }
        private void Apagar(string strIP)
        {
            YeelightControl yeelight = new YeelightControl(strIP);
            yeelight.TurnOff();
        }
        private void btnApagar_Click(object sender, EventArgs e)
        {

            try
            {
                Apagar("192.168.0.4");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (cdialog.ShowDialog() == DialogResult.OK)
                {
                    Encender("192.168.0.4", cdialog.Color);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbBrillo_Scroll(object sender, EventArgs e)
        {
            lblBrillo.Text = "Brillo " + tbBrillo.Value.ToString() + "%";
        }


        private void bwSinc_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker w = (BackgroundWorker)sender;
            while (!w.CancellationPending)
            {
                Color color = GetAverageColor.GetColor();
                Encender("192.168.0.4", color);
                System.Threading.Thread.Sleep(100);
            }
            e.Cancel = true;
        }

        private void bwSinc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //lblstatus.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void bwSinc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblstatus.Text = "Cancelado!";
            }
            else if (e.Error != null)
            {
                lblstatus.Text = "Error: " + e.Error.Message;
            }
            else
            {
                lblstatus.Text = "Correcto!";
            }
        }

        private void btn_Encender_Click(object sender, EventArgs e)
        {
            try
            {
                Color averageColor = GetAverageColor.GetColor();
                Encender("192.168.0.4", averageColor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Apagar_Click(object sender, EventArgs e)
        {
            try
            {
                Apagar("192.168.0.4");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Color_Click(object sender, EventArgs e)
        {
            try
            {
                if (cdialog.ShowDialog() == DialogResult.OK)
                {
                    Encender("192.168.0.4", cdialog.Color);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bwSinc.CancelAsync();
            if (bwSinc.IsBusy)
            {
                // Indicar que se debe cancelar el trabajo en el objeto BackgroundWorker
                bwSinc.CancelAsync();

                // Esperar a que el objeto BackgroundWorker termine de ejecutarse
                while (bwSinc.IsBusy)
                {
                    Application.DoEvents();
                }
            }
            Apagar("192.168.0.4");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            bwSinc.CancelAsync();
        }

        private void tbtnSinc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbtnSinc.Checked && !bwSinc.IsBusy)
                {
                    bwSinc.RunWorkerAsync();
                }
                else
                {
                    tbtnSinc.Checked = false;
                }

                if (!tbtnSinc.Checked)
                {
                    bwSinc.CancelAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void MuestraColor(Color color)
        {
            btnColor1.BackColor = color;
            btnColor2.BackColor = color;
        }
    }
}
