using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using YControl.classes;
using Timer = System.Windows.Forms.Timer;

namespace YControl
{
    public partial class Form1 : Form
    {
        private List<Device> devices;
        private DeviceControl deviceControl;
        private LocalDiscovery localDiscovery;
        private Device device;
        private string strNuevaIp;
        private List<ScreenProperties> screenProperties;
        private FormSettings formSettings = new FormSettings();

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Obtener Ajustes
            iniciarAutomaticamenteToolStripMenuItem.Checked = RegistryKeyExists();
            iniciarSincronizarciónAutomaticamenteToolStripMenuItem.Checked = formSettings.SyncAuto;
            tbBrillo.Value = formSettings.Brightness;
            tbTemperatura.Value = formSettings.Temperature;
            tbSuavidad.Value = formSettings.Smoothness;
            tbSinc.Value = formSettings.Syncronization;
            UpdateValues();
            tbtnSinc.Checked = iniciarSincronizarciónAutomaticamenteToolStripMenuItem.Checked;
        }
        private void UpdateValues()
        {
            GetBulbs();
            GetScreenProperties();
        }
        private void GetScreenProperties()
        {
            screenProperties = new List<ScreenProperties>();
            Screen[] allScreens = Screen.AllScreens;
            int count = 0;
            foreach (Screen screen in allScreens)
            {
                String name = screen.DeviceFriendlyName();
                if (String.IsNullOrEmpty(name))
                    name = "Unknown";
                screenProperties.Add(new ScreenProperties(count, name));
                count++;
            }

            cmbbxScreen.DisplayMember = "name";
            cmbbxScreen.ValueMember = "id";
            cmbbxScreen.DataSource = screenProperties;
            cmbbxScreen.SelectedIndex = 0;
        }
        private void GetBulbs()
        {
            deviceControl = new DeviceControl();
            localDiscovery = new LocalDiscovery();
            Cursor.Current = Cursors.WaitCursor;
            lstDevices.Enabled = false;
            localDiscovery.StartListening();
            localDiscovery.SendDiscoveryMessage();
            devices = new List<Device>();
            if (formSettings.Devices != null)
            {
                StringEnumerator enumerator = formSettings.Devices.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        string current = enumerator.Current;
                        devices.Add(new Device(current, "0", state: false, 100, "", current, "", 16777215, 6500));
                    }
                }
                finally
                {
                    if (enumerator is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                }
            }
            Thread.Sleep(350);
            devices = localDiscovery.DiscoveredDevices.Concat(devices).ToList();
            lstDevices.DataSource = devices;
            lstDevices.DisplayMember = "Name";
            lstDevices.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        private void OnSyncDevices(Color color)
        {
            foreach (Device _device in devices)
            {
                if (!_device.State)
                {
                    if (deviceControl.Connect(_device))
                    {
                        deviceControl.SetPower(power: true, tbSuavidad.Value);
                    }
                }
                if (deviceControl.Connect(_device))
                {
                    deviceControl.SetColor(color.R, color.G, color.B, tbSuavidad.Value);
                    if (_device.Brightness != tbBrillo.Value)
                        deviceControl.SetBrightness(tbBrillo.Value, tbSuavidad.Value);
                    if (_device.Temperature != tbTemperatura.Value)
                        deviceControl.SetTemperature(tbTemperatura.Value, tbSuavidad.Value);

                    MuestraDeColor(color);
                }
            }
        }
        private void tbBrillo_Scroll(object sender, EventArgs e)
        {
            lblBrillo.Text = "Brillo " + tbBrillo.Value.ToString() + "%";
            formSettings.Brightness = tbBrillo.Value;
            formSettings.Save();

        }
        private void tbTemperatura_Scroll(object sender, EventArgs e)
        {
            lblTemperatura.Text = "Temperatura " + tbTemperatura.Value.ToString();
            formSettings.Temperature = tbTemperatura.Value;
            formSettings.Save();
        }
        private void tbSuavidad_Scroll(object sender, EventArgs e)
        {
            lblSuavidad.Text = "Suavidad " + tbSuavidad.Value.ToString();
            formSettings.Smoothness = tbSuavidad.Value;
            formSettings.Save();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Frecuencia 5
            lblSinc.Text = "Frecuencia " + tbSinc.Value.ToString();
            formSettings.Syncronization = tbSinc.Value;
            formSettings.Save();
        }
        private void bwSinc_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker w = (BackgroundWorker)sender;
                while (!w.CancellationPending)
                {
                    Color color = ScreenColor.GetAverageColor(cmbbxScreen.SelectedIndex);
                    OnSyncDevices(color);
                    Thread.Sleep(tbSinc.Value);
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message,"Yeelight Control",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { e.Cancel = true; }

        }
        private void bwSinc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bwSinc.IsBusy)
                bwSinc.CancelAsync();
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
        private void txtNuevaIp_Enter(object sender, EventArgs e)
        {
            if (txtNuevaIp.Text == "Nuevo Dispositivo")
            {
                strNuevaIp = "";
                txtNuevaIp.Text = "";
                this.txtNuevaIp.ForeColor = Color.Black;
            }
        }
        private void AgregarDispositivo(string strIp)
        {
            formSettings.Devices.Add(strIp);
            formSettings.Save();
            UpdateValues();
        }
        private void txtNuevaIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    btnAgregar.Focus();
                    btnAgregar.PerformClick();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void txtNuevaIp_Leave(object sender, EventArgs e)
        {
            strNuevaIp = txtNuevaIp.Text;
            txtNuevaIp.Text = "Nuevo Dispositivo";
            txtNuevaIp.ForeColor = SystemColors.InactiveCaption;
        }
        private void lstDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = devices[lstDevices.SelectedIndex];
        }
        private void lstDevices_DoubleClick(object sender, EventArgs e)
        {
            device = devices[lstDevices.SelectedIndex];
            txtNuevaIp.Text = device.Ip;
            formSettings.Devices.Remove(device.Ip);
            txtNuevaIp.Focus();
            UpdateValues();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show($"¿Desea Guardar dispositivo: {strNuevaIp}?", "Guardar dispositivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    if (Utils.isValidIp(strNuevaIp.Trim()))
                    {
                        AgregarDispositivo(strNuevaIp);
                    }
                    else
                        MessageBox.Show("Ip no aceptada", "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void MuestraDeColor(Color color)
        {
            pColor.BackColor = color;

        }
        public bool RegistryKeyExists()
        {
            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true))
            {
                if (registryKey != null)
                {
                    try
                    {
                        string text = (string)registryKey.GetValue("YeelightControl");
                        if (text == null)
                        {
                            return false;
                        }
                        if (text == Application.ExecutablePath + " -silent")
                        {
                            return true;
                        }
                        return false;
                    }
                    catch
                    {
                        return false;
                    }
                }
                return false;
            }
        }
        private void iniciarAutomaticamenteToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            RegisterInStartup(iniciarAutomaticamenteToolStripMenuItem.Checked);
        }
        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
            if (isChecked)
            {
                registryKey.SetValue("YeelightControl", Application.ExecutablePath + " -silent");
            }
            else
            {
                registryKey.DeleteValue("YeelightControl");
            }
        }
        private void iniciarSincronizarciónAutomaticamenteToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            formSettings.SyncAuto = iniciarSincronizarciónAutomaticamenteToolStripMenuItem.Checked;
            formSettings.Save();
        }
    }
}
