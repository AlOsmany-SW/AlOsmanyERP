using AlOsmanyDataModel;
using AlOsmanyDataModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AlOsmany.Forms.Services
{
    public partial class ServiceList : Form
    {
        private string _imagePath;
        private readonly User _userLoggedIn;
        private List<RequestedService> _requestedServices;
        private readonly AlOsmanyDbContext _alOsmanyDbContext;

        public ServiceList(User userLoggedIn)
        {
            InitializeComponent();

            _imagePath = string.Empty;
            _userLoggedIn = userLoggedIn;
            _requestedServices = new List<RequestedService>();
            _alOsmanyDbContext = new AlOsmanyDbContext();

            dataGridView1.DataSource = _alOsmanyDbContext.Services.ToListAsync().Result;

            if (_userLoggedIn.Role == UserRole.Customer)
            {
                btnAddCart.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                cartToolStripMenuItem.Visible = true;

                txtName.ReadOnly = true;
                txtFees.ReadOnly = true;
                txtDiscount.ReadOnly = true;
                txtSurcharge.ReadOnly = true;
                txtNotes.ReadOnly = true;
                pictureBox1.Enabled = false;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await _alOsmanyDbContext.Services.Where(service => service.Name.Contains(txtSearchName.Text)).ToListAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                var selectedService = _alOsmanyDbContext.Services.Where(service => service.Id == id).FirstOrDefault();

                try
                {
                    selectedService.Name = txtName.Text;
                    selectedService.Fees = decimal.Parse(txtFees.Text);
                    selectedService.Discount = decimal.Parse(txtDiscount.Text);
                    selectedService.Surcharge = decimal.Parse(txtSurcharge.Text);
                    selectedService.Notes = string.IsNullOrEmpty(txtNotes.Text) ? null : txtNotes.Text;

                    if (!string.IsNullOrEmpty(_imagePath))
                    {
                        var newImageDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "Services");

                        if (!Directory.Exists(newImageDir))
                            Directory.CreateDirectory(newImageDir);

                        var newImagePath = Path.Combine(newImageDir, selectedService.Id + Path.GetExtension(_imagePath));

                        File.Copy(_imagePath, newImagePath);

                        selectedService.Image = newImagePath;
                    }

                    await _alOsmanyDbContext.SaveChangesAsync();

                    MessageBox.Show("Service Updated.", "Services");
                    Clear();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Fees, Discount, and Surcharge should be in digits.", "Update Service", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Service", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new Dashboard(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                var dlg = new OpenFileDialog();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _imagePath = dlg.FileName;
                    pictureBox1.ImageLocation = dlg.FileName;
                }
            }
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                var selectedService = _alOsmanyDbContext.Services.Where(service => service.Id == id).FirstOrDefault();

                var requestedService = new RequestedService(selectedService);
                requestedService.Id = _requestedServices.Count;

                _requestedServices.Add(requestedService);

                MessageBox.Show("Service added to cart.", "Cart");
                Clear();
            }
        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cart = new Cart(_userLoggedIn, _requestedServices);
            cart.Show();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                var selectedService = _alOsmanyDbContext.Services.Where(service => service.Id == id).FirstOrDefault();
                _alOsmanyDbContext.Services.Remove(selectedService);

                await _alOsmanyDbContext.SaveChangesAsync();

                MessageBox.Show("Service Deleted.", "Services");
                Clear();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                var selectedService = _alOsmanyDbContext.Services.Where(service => service.Id == id).FirstOrDefault();

                txtName.Text = selectedService.Name;
                txtFees.Text = selectedService.Fees.ToString();
                txtDiscount.Text = selectedService.Discount.ToString();
                txtSurcharge.Text = selectedService.Surcharge.ToString();
                txtNotes.Text = selectedService.Notes;
                pictureBox1.ImageLocation = selectedService.Image;
            }
        }

        private async void Clear()
        {
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = await _alOsmanyDbContext.Services.ToListAsync();

            txtSearchName.Text = string.Empty;
            txtName.Text = string.Empty;
            txtFees.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtSurcharge.Text = string.Empty;
            txtNotes.Text = string.Empty;
            pictureBox1.ImageLocation = string.Empty;
        }
    }
}