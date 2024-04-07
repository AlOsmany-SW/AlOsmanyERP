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
    public partial class ServiceReport : Form
    {
        private const int CompanyBirth = 2000;
        private readonly User _userLoggedIn;
        private readonly AlOsmanyDbContext _alOsmanyDbContext;

        public ServiceReport(User userLoggedIn)
        {
            InitializeComponent();

            _userLoggedIn = userLoggedIn;
            _alOsmanyDbContext = new AlOsmanyDbContext();
            dataGridView1.DataSource = _alOsmanyDbContext.Services.ToListAsync().Result;

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

                var selectedService = _alOsmanyDbContext.Services.Where(service => service.Id == id).FirstOrDefault();

                txtId.Text = selectedService.Id.ToString();
                txtName.Text = selectedService.Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                var selectedService = _alOsmanyDbContext.Services.Where(service => service.Id == id).FirstOrDefault();

                txtId.Text = selectedService.Id.ToString();
                txtName.Text = selectedService.Name;

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
                    MessageBox.Show("Not valid year.", "Service Report", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Service Report", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    return;
                }

                var totalFees = default(decimal);
                var totalRequests = 0;

                foreach (var service in _alOsmanyDbContext.RequestedServices)
                    if (service.CreatedAt.Year == year && service.CreatedAt.Month == month)
                    {
                        totalFees += service.Fees;
                        totalFees -= service.Discount;
                        totalFees += service.Surcharge;

                        ++totalRequests;
                    }

                txtFees.Text = totalFees.ToString();
                txtRequests.Text = totalRequests.ToString();

                return;
            }

            MessageBox.Show("Please select service!", "Service Report");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = await _alOsmanyDbContext.Services.ToListAsync();

            txtId.Text = string.Empty;
            txtName.Text = string.Empty;

            txtYear.Text = DateTime.UtcNow.Year.ToString();
            txtMonth.Text = DateTime.UtcNow.Month.ToString();

            txtFees.Text = string.Empty;
            txtRequests.Text = string.Empty;
        }
    }
}