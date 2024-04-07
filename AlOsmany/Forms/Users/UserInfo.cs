using System;
using AlOsmanyDataModel;
using System.Windows.Forms;
using AlOsmanyDataModel.Models;
using System.IO;
using System.Linq;
using System.Threading;

namespace AlOsmany.Forms.Users
{
    public partial class UserInfo : Form
    {
        private string _imagePath;
        private readonly User _userLoggedIn;

        public UserInfo(User userLoggedIn)
        {
            InitializeComponent();

            _imagePath = string.Empty;
            _userLoggedIn = userLoggedIn;

            Text = _userLoggedIn.Role.ToString() + ": " + _userLoggedIn.FullName;

            txtFullName.Text = _userLoggedIn.FullName;

            txtUserName.Text = _userLoggedIn.UserName;
            txtUserName.ReadOnly = true;

            txtPassword.Text = _userLoggedIn.Password;

            txtRole.Text = _userLoggedIn.Role.ToString();
            txtRole.ReadOnly = true;

            pictureBox1.ImageLocation = _userLoggedIn.Image;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var fullName = txtFullName.Text;
                var password = txtPassword.Text;
                var phoneNumber = txtPhoneNumber.Text;

                if (!fullName.All(ch => char.IsLetter(ch) || ch == ' '))
                    throw new FormatException("Not valid name. Full name shouldn't have other than letters.");

                if (!phoneNumber.All(char.IsDigit))
                    throw new FormatException("Not valid phone number. Phone number shouldn't have other than digits.");

                _userLoggedIn.FullName = fullName;
                _userLoggedIn.Password = password;
                _userLoggedIn.PhoneNumber = phoneNumber == "0" ? null : phoneNumber;

                var alOsmanyDbContext = new AlOsmanyDbContext();
                await alOsmanyDbContext.SaveChangesAsync();

                if (!string.IsNullOrEmpty(_imagePath))
                {
                    var newImagePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Resources", "Users", _userLoggedIn.Id + Path.GetExtension(_imagePath));
                    File.Copy(_imagePath, newImagePath);

                    _userLoggedIn.Image = newImagePath;
                    await alOsmanyDbContext.SaveChangesAsync();
                }

                MessageBox.Show("User Updated.", "User Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "User Info", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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

            var thread = new Thread(() => Application.Run(new Dashboard(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}