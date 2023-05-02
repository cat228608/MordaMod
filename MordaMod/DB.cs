using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace MordaMod
{
    internal class DB
    {
        private MySqlConnection connection;

        public void Connect()
        {
            string connectionString = "Server=localhost;Database=mordamod;Uid=root;Pwd=root;";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public void Disconnect()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        public static string HashPassword(string text_coding)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text_coding));
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }

                return text_coding = stringBuilder.ToString();
            }
        }

        public string[,] GetData(string login, string password)
        {
            string password_md5 = HashPassword(password);
            string query = $"SELECT * FROM Users WHERE login = '{login}' AND password = '{password_md5}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            int rowCount = 0;
            while (reader.Read())
            {
                rowCount++;
            }

            if (rowCount == 0)
            {
                return null;
            }

            string[,] data_massiv = new string[rowCount, 3];
            int rowIndex = 0;

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string username = reader.GetString("username");
                string avatar = reader.GetString("avatar");

                data_massiv[rowIndex, 0] = id.ToString();
                data_massiv[rowIndex, 1] = username;
                data_massiv[rowIndex, 2] = avatar;

                rowIndex++;
            }

            reader.Close();
            MessageBox.Show(data_massiv[0,2]);
            return data_massiv;
        }

        public bool CheckUser(string login, string password)
        {
            string password_md5 = HashPassword(password);
            MessageBox.Show(password_md5);
            bool userFound = false;
            string query = $"SELECT * FROM Users WHERE login = '{login}' AND password = '{password_md5}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                userFound = true;
            }

            reader.Close();
            return userFound;
        }

        public bool Registers(string login, string password, string username)
        {
            string password_md5 = HashPassword(password);
            MessageBox.Show(password_md5);
            string query = $"INSERT INTO users(login, password, username) VALUES ('{login}', '{password_md5}', '{username}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            int affectedRows = command.ExecuteNonQuery();

            return affectedRows > 0 ? true : false;
        }

    }
}
