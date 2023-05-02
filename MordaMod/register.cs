using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MordaMod
{
    public partial class register : Form
    {
        private DB databaseConnection;
        public register()
        {
            InitializeComponent();
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            string login = login_in.Text;
            string password = password_in.Text;
            string username = username_in.Text;
            if (login == null || password == null || username == null)
            {
                MessageBox.Show("Охрана замка сказала что вы жулик, нужно заполнить все поля!");
            }
            else
            {
                databaseConnection = new DB();
                databaseConnection.Connect();
                bool get_reg = databaseConnection.Registers(login, password, username);
                if (get_reg)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["login"].Value = login;
                    config.AppSettings.Settings["password"].Value = password;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    profil profil = new profil();
                    profil.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Охрана королевства не допустила вам к воротам. Придумайте нового лорда и повторите попытку.");
                }
                databaseConnection.Disconnect();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
