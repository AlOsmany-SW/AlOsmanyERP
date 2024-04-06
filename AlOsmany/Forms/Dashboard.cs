using AlOsmany.Forms.Reports;
using AlOsmany.Forms.Services;
using AlOsmany.Forms.Users;
using AlOsmanyDataModel.Models;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AlOsmany.Forms
{
    public partial class Dashboard : Form
    {
        private readonly User _userLoggedIn;

        public Dashboard(User userLoggedIn)
        {
            InitializeComponent();

            _userLoggedIn = userLoggedIn;

            Text = _userLoggedIn.Role.ToString() + ": " + _userLoggedIn.FullName;

            if (_userLoggedIn.Role != UserRole.Admin)
                userListToolStripMenuItem.Visible = false;

            if (_userLoggedIn.Role == UserRole.Customer)
            {
                newServiceToolStripMenuItem.Visible = false;
                yearReportToolStripMenuItem.Visible = false;
                serviceReportToolStripMenuItem.Visible = false;
                customerReportToolStripMenuItem.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new LogIn()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser newUser;

            if (_userLoggedIn.Role == UserRole.Admin)
                newUser = new NewUser(_userLoggedIn, UserRole.Admin, UserRole.Manager, UserRole.Worker, UserRole.Customer);
            else if (_userLoggedIn.Role == UserRole.Manager)
                newUser = new NewUser(_userLoggedIn, UserRole.Worker, UserRole.Customer);
            else
                newUser = new NewUser(_userLoggedIn, UserRole.Customer);

            Close();

            var thread = new Thread(() => Application.Run(newUser));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void newServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new NewService(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void requestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new Requests(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void yearReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new YearReport(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void serviceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new ServiceReport(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new CustomerReport(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new UserList(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new UserInfo(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new ServiceList(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}