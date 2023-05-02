using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace MordaMod
{
    public partial class Form1 : Form
    {
        private DB databaseConnection;
        private object messageBox;

        public Form1()
        {
            InitializeComponent();
            label_reg.Text = "Вас нет в нашем королевстве?\nТак получите вольную(кликабельно)";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["login"]))
            {
                string login = ConfigurationManager.AppSettings["login"];
                string password = ConfigurationManager.AppSettings["password"];
                databaseConnection = new DB();
                databaseConnection.Connect();
                bool userFound = databaseConnection.CheckUser(login, password);
                if (userFound)
                {
                    profil profil = new profil();
                    profil.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Сессия была утеряна! Авторизуйтесь еще раз.!");
                    config.AppSettings.Settings.Remove("login");
                    config.AppSettings.Settings.Remove("password");
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                databaseConnection.Disconnect();

            }
            else
            {

            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void auth_Click(object sender, EventArgs e)
        {
            databaseConnection = new DB();
            databaseConnection.Connect();
            bool userFound = databaseConnection.CheckUser(logintextbox.Text, passwordtextbox.Text);
            if (userFound)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["login"].Value = logintextbox.Text;
                config.AppSettings.Settings["password"].Value = passwordtextbox.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                profil profil = new profil();
                profil.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Данный пользователь не найден!");
            }

            databaseConnection.Disconnect();
        }

        private void label_reg_Click(object sender, EventArgs e)
        {

        }
    }
}
