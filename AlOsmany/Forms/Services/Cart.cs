using AlOsmanyDataModel;
using AlOsmanyDataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AlOsmany.Forms.Services
{
    public partial class Cart : Form
    {
        private readonly User _userLoggedIn;
        private readonly List<RequestedService> _requestedServices;

        public Cart(User userLoggedIn, List<RequestedService> requestedServices)
        {
            InitializeComponent();

            _userLoggedIn = userLoggedIn;
            _requestedServices = requestedServices;
            dataGridView1.DataSource = _requestedServices.ToList();

            var totalMoney = default(decimal);

            for (var i = 0; i < _requestedServices.Count; i++)
            {
                totalMoney += _requestedServices[i].Fees;
                totalMoney -= _requestedServices[i].Discount;
                totalMoney += _requestedServices[i].Surcharge;
            }

            txtTotalMoney.Text = totalMoney.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
                return;

            var request = new Request
            {
                CreatedBy = _userLoggedIn.Id,
                TotalFees = decimal.Parse(txtTotalMoney.Text),
                CreatedAt = DateTime.UtcNow
            };

            var alOsmanyDbContext = new AlOsmanyDbContext();
            alOsmanyDbContext.Requests.Add(request);
            await alOsmanyDbContext.SaveChangesAsync();

            while (_requestedServices.Count > 0)
            {
                var requestedService = _requestedServices.First();
                requestedService.RequestId = request.Id;

                alOsmanyDbContext.RequestedServices.Add(requestedService);

                _requestedServices.Remove(requestedService);
            }

            await alOsmanyDbContext.SaveChangesAsync();

            MessageBox.Show("Services requested.", "Cart");
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
                return;

            var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

            var selectedService = _requestedServices.Where(service => service.Id == id).FirstOrDefault();
            _requestedServices.Remove(selectedService);

            MessageBox.Show("Service removed from cart.", "Cart");
            Clear();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                var selectedService = _requestedServices.Where(service => service.Id == id).FirstOrDefault();

                txtName.Text = selectedService.Name;
                txtFees.Text = selectedService.Fees.ToString();
                txtDiscount.Text = selectedService.Discount.ToString();
                txtSurcharge.Text = selectedService.Surcharge.ToString();
                txtNotes.Text = selectedService.Notes;
                pictureBox1.ImageLocation = selectedService.Image;
            }
        }

        private void Clear()
        {
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = _requestedServices.ToList();

            var totalMoney = default(decimal);

            for (var i = 0; i < _requestedServices.Count; i++)
            {
                totalMoney += _requestedServices[i].Fees;
                totalMoney -= _requestedServices[i].Discount;
                totalMoney += _requestedServices[i].Surcharge;
            }

            txtTotalMoney.Text = totalMoney.ToString();

            if (dataGridView1.SelectedCells.Count != 0)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                var selectedService = _requestedServices.Where(service => service.Id == id).FirstOrDefault();

                txtName.Text = selectedService.Name;
                txtFees.Text = selectedService.Fees.ToString();
                txtDiscount.Text = selectedService.Discount.ToString();
                txtSurcharge.Text = selectedService.Surcharge.ToString();
                txtNotes.Text = selectedService.Notes;
                pictureBox1.ImageLocation = selectedService.Image;

                return;
            }

            txtName.Text = string.Empty;
            txtFees.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtSurcharge.Text = string.Empty;
            txtNotes.Text = string.Empty;
            pictureBox1.ImageLocation = string.Empty;
        }
    }
}