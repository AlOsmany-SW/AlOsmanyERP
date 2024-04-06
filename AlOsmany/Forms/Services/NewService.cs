using System;
using AlOsmanyDataModel;
using System.Windows.Forms;
using AlOsmanyDataModel.Models;
using System.IO;
using System.Threading;

namespace AlOsmany.Forms.Services
{
    public partial class NewService : Form
    {
        private string _imagePath;
        private readonly User _userLoggedIn;

        public NewService(User userLoggedIn)
        {
            InitializeComponent();
            _imagePath = string.Empty;
            _userLoggedIn = userLoggedIn;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new Service()
                {
                    Name = txtName.Text,
                    Fees = decimal.Parse(txtFees.Text),
                    Discount = decimal.Parse(txtDiscount.Text),
                    Surcharge = decimal.Parse(txtSurcharge.Text),
                    Notes = string.IsNullOrEmpty(txtNotes.Text) ? null : txtNotes.Text
                };

                var alOsmanyDbContext = new AlOsmanyDbContext();
                alOsmanyDbContext.Services.Add(service);

                if (!string.IsNullOrEmpty(_imagePath))
                {
                    var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Services", service.Id + Path.GetExtension(_imagePath));
                    File.Copy(_imagePath, newImagePath);
                    service.Image = newImagePath;
                }

                await alOsmanyDbContext.SaveChangesAsync();

                MessageBox.Show("Service Saved.", "New Service");

                Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Fees, Discount, and Surcharge should be in digits.", "New Service", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "New Service", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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

        private void Clear()
        {
            txtName.Text = string.Empty;
            txtFees.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtSurcharge.Text = string.Empty;
            txtNotes.Text = string.Empty;
            pictureBox1.ImageLocation = string.Empty;
        }
    }
}