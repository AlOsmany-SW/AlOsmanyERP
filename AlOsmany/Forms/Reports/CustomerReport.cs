using AlOsmanyDataModel;
using AlOsmanyDataModel.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AlOsmany.Forms.Reports
{
    public partial class CustomerReport : Form
    {
        private const int CompanyBirth = 2000;
        private readonly User _userLoggedIn;
        private readonly AlOsmanyDbContext _alOsmanyDbContext;

        public CustomerReport(User userLoggedIn)
        {
            InitializeComponent();

            _userLoggedIn = userLoggedIn;
            _alOsmanyDbContext = new AlOsmanyDbContext();
            dataGridView1.DataSource = _alOsmanyDbContext.Users.Where(user => user.Role == UserRole.Customer).Select(user => new
            {
                user.Id,
                user.UserName,
                user.FullName,
                user.Role,
                user.PhoneNumber
            }).ToListAsync().Result;

            txtYear.Text = DateTime.UtcNow.Year.ToString();
            txtMonth.Text = DateTime.UtcNow.Month.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new Dashboard(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                var selectedUser = _alOsmanyDbContext.Users.Where(user => user.Id == id).FirstOrDefault();

                txtFullName.Text = selectedUser.FullName;
                txtUserName.Text = selectedUser.UserName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                var selectedUser = _alOsmanyDbContext.Users.Where(user => user.Id == id).FirstOrDefault();

                txtFullName.Text = selectedUser.FullName;
                txtUserName.Text = selectedUser.UserName;

                var year = 0;
                var month = 0;

                try
                {
                    year = int.Parse(txtYear.Text);
                    month = int.Parse(txtMonth.Text);

                    if (year < CompanyBirth || year > DateTime.UtcNow.Year)
                        throw new FormatException();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Not valid year.", "Customer Report", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Customer Report", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    return;
                }

                var totalFees = default(decimal);
                var totalRequests = 0;

                foreach (var request in _alOsmanyDbContext.Requests)
                    if (request.Date.Year == year && request.Date.Month == month && request.CustomerId == selectedUser.Id)
                    {
                        totalFees += request.TotalFees;
                        ++totalRequests;
                    }

                txtFees.Text = totalFees.ToString();
                txtRequests.Text = totalRequests.ToString();

                return;
            }

            MessageBox.Show("Please select customer!", "Customer Report");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = await _alOsmanyDbContext.Users.Where(user => user.Role == UserRole.Customer).Select(user => new
            {
                user.Id,
                user.UserName,
                user.FullName,
                user.Role,
                user.PhoneNumber
            }).ToListAsync();

            txtFullName.Text = string.Empty;
            txtUserName.Text = string.Empty;

            txtYear.Text = DateTime.UtcNow.Year.ToString();
            txtMonth.Text = DateTime.UtcNow.Month.ToString();

            txtFees.Text = string.Empty;
            txtRequests.Text = string.Empty;
        }
    }
}