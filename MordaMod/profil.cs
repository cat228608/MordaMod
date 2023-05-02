using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MordaMod
{
    public partial class profil : Form
    {
        private DB databaseConnection;
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public profil()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["login"]))
            {
                string login = ConfigurationManager.AppSettings["login"];
                string password = ConfigurationManager.AppSettings["password"];
                databaseConnection = new DB();
                databaseConnection.Connect();
                bool userFound = databaseConnection.CheckUser(login, password);
                if (userFound)
                {
                    string[,] getdata = databaseConnection.GetData(login, password);
                    if (getdata != null)
                    {
                        using (WebClient client = new WebClient())
                        {
                            byte[] imageBytes = client.DownloadData(getdata[0,2]);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                user_avatar.Image = Image.FromStream(ms);
                            }
                            loads.Text= getdata[0,1];
                            number.Text = getdata[0, 0];
                        }
                    }
                    else
                    {
                        loads.Text = "Ошибка загрузки с базы данных!";
                    }
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
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
