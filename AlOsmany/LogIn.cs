using AlOsmany.Forms;
using AlOsmany.Forms.Users;
using AlOsmanyDataModel;
using AlOsmanyDataModel.Models;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AlOsmany
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var password = txtPassword.Text;

            var alOsmanyDbContext = new AlOsmanyDbContext();

            var userLoggedIn = alOsmanyDbContext.Users.Where(user => user.UserName == userName && user.Password == password).FirstOrDefault();

            if (userLoggedIn == null)
                MessageBox.Show("Wrong username or password.", "Log In", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            else
            {
                Close();

                var thread = new Thread(() => Application.Run(new Dashboard(userLoggedIn)));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new NewUser(null, UserRole.Customer)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
