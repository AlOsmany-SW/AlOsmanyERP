﻿using System;
using AlOsmanyDataModel;
using System.Windows.Forms;
using AlOsmanyDataModel.Models;
using System.IO;
using System.Linq;
using System.Threading;

namespace AlOsmany.Forms.Users
{
    public partial class NewUser : Form
    {
        private string _imagePath;
        private readonly User _userLoggedIn;

        public NewUser(User userLoggedIn)
        {
            InitializeComponent();

            _imagePath = string.Empty;
            _userLoggedIn = userLoggedIn;

            comboBox1.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var fullName = txtFullName.Text;
                var userName = txtUserName.Text;
                var password = txtPassword.Text;
                var phoneNumber = txtPhoneNumber.Text;
                Enum.TryParse(comboBox1.Text, out UserRole role);

                if (!fullName.All(ch => char.IsLetter(ch) || ch == ' '))
                    throw new FormatException("Not valid name. Full name shouldn't have other than letters.");

                if (!phoneNumber.All(char.IsDigit))
                    throw new FormatException("Not valid phone number. Phone number shouldn't have other than digits.");

                var user = new User()
                {
                    FullName = fullName,
                    UserName = userName,
                    Password = password,
                    PhoneNumber = phoneNumber == "0" ? null : phoneNumber,
                    Role = role,
                    Image = _imagePath
                };

                var alOsmanyDbContext = new AlOsmanyDbContext();
                alOsmanyDbContext.Users.Add(user);
                await alOsmanyDbContext.SaveChangesAsync();

                if (!string.IsNullOrEmpty(_imagePath))
                {
                    var newImageDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "Users");

                    if (!Directory.Exists(newImageDir))
                        Directory.CreateDirectory(newImageDir);

                    var newImagePath = Path.Combine(newImageDir, user.Id + Path.GetExtension(_imagePath));

                    File.Copy(_imagePath, newImagePath);

                    user.Image = newImagePath;
                }

                await alOsmanyDbContext.SaveChangesAsync();

                MessageBox.Show("User Saved.", "New User");

                Close();

                var thread = new Thread(() => Application.Run(new LogIn()));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "New User", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _imagePath = dlg.FileName;
                pictureBox1.ImageLocation = dlg.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            Thread thread;

            if (_userLoggedIn is null)
                thread = new Thread(() => Application.Run(new LogIn()));
            else
                thread = new Thread(() => Application.Run(new Dashboard(_userLoggedIn)));
            
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}