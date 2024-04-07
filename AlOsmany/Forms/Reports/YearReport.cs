using AlOsmanyDataModel;
using AlOsmanyDataModel.Models;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AlOsmany.Forms.Reports
{
    public partial class YearReport : Form
    {
        private readonly User _userLoggedIn;
        private const int CompanyBirth = 2000;

        public YearReport(User userLoggedIn)
        {
            InitializeComponent();
            _userLoggedIn = userLoggedIn;
            txtYear.Text = DateTime.UtcNow.Year.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new Dashboard(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var year = 0;

            try
            {
                year = int.Parse(txtYear.Text);

                if (year < CompanyBirth || year > DateTime.UtcNow.Year)
                    throw new FormatException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Not valid year.", "Year Report", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Year Report", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

            var alOsmanyDbContext = new AlOsmanyDbContext();

            var requests = alOsmanyDbContext.Requests.Where(request => request.CreatedAt.Year == year);

            decimal januaryFees = default;
            var januaryRequests = 0;

            decimal februaryFees = default;
            var februaryRequests = 0;

            decimal marchFees = default;
            var marchRequests = 0;

            decimal aprilFees = default;
            var aprilRequests = 0;

            decimal mayFees = default;
            var mayRequests = 0;

            decimal juneFees = default;
            var juneRequests = 0;

            decimal julyFees = default;
            var julyRequests = 0;

            decimal augustFees = default;
            var augustRequests = 0;

            decimal septemberFees = default;
            var septemberRequests = 0;

            decimal octoberFees = default;
            var octoberRequests = 0;

            decimal novemberFees = default;
            var novemberRequests = 0;

            decimal decemberFees = default;
            var decemberRequests = 0;

            foreach (var request in requests)
            {
                switch (request.CreatedAt.Month)
                {
                    case 1:
                        januaryRequests++;
                        januaryFees += request.TotalFees;
                        break;
                    case 2:
                        februaryRequests++;
                        februaryFees += request.TotalFees;
                        break;
                    case 3:
                        marchRequests++;
                        marchFees += request.TotalFees;
                        break;
                    case 4:
                        aprilRequests++;
                        aprilFees += request.TotalFees;
                        break;
                    case 5:
                        mayRequests++;
                        mayFees += request.TotalFees;
                        break;
                    case 6:
                        juneRequests++;
                        juneFees += request.TotalFees;
                        break;
                    case 7:
                        julyRequests++;
                        julyFees += request.TotalFees;
                        break;
                    case 8:
                        augustRequests++;
                        augustFees += request.TotalFees;
                        break;
                    case 9:
                        septemberRequests++;
                        septemberFees += request.TotalFees;
                        break;
                    case 10:
                        octoberRequests++;
                        octoberFees += request.TotalFees;
                        break;
                    case 11:
                        novemberRequests++;
                        novemberFees += request.TotalFees;
                        break;
                    default:
                        decemberRequests++;
                        decemberFees += request.TotalFees;
                        break;
                }
            }

            txtJanuaryFees.Text = januaryFees + " Total Fees";
            txtJanuaryRequests.Text = januaryRequests + (januaryRequests > 1 ? " Requests" : " Request");

            txtFebruaryFees.Text = februaryFees + " Total Fees";
            txtFebruaryRequests.Text = februaryRequests + (februaryRequests > 1 ? " Requests" : " Request");

            txtMarchFees.Text = marchFees + " Total Fees";
            txtMarchRequests.Text = marchRequests + (marchRequests > 1 ? " Requests" : " Request");

            txtAprilFees.Text = aprilFees + " Total Fees";
            txtAprilRequests.Text = aprilRequests + (aprilRequests > 1 ? " Requests" : " Request");

            txtMayFees.Text = mayFees + " Total Fees";
            txtMayRequests.Text = mayRequests + (mayRequests > 1 ? " Requests" : " Request");

            txtJuneFees.Text = juneFees + " Total Fees";
            txtJuneRequests.Text = juneRequests + (juneRequests > 1 ? " Requests" : " Request");

            txtJulyFees.Text = julyFees + " Total Fees";
            txtJulyRequests.Text = julyRequests + (julyRequests > 1 ? " Requests" : " Request");

            txtAugustFees.Text = augustFees + " Total Fees";
            txtAugustRequests.Text = augustRequests + (augustRequests > 1 ? " Requests" : " Request");

            txtSeptemberFees.Text = septemberFees + " Total Fees";
            txtSeptemberRequests.Text = septemberRequests + (septemberRequests > 1 ? " Requests" : " Request");

            txtOctoberFees.Text = octoberFees + " Total Fees";
            txtOctoberRequests.Text = octoberRequests + (octoberRequests > 1 ? " Requests" : " Request");

            txtNovemberFees.Text = novemberFees + " Total Fees";
            txtNovemberRequests.Text = novemberRequests + (novemberRequests > 1 ? " Requests" : " Request");

            txtDecemberFees.Text = decemberFees + " Total Fees";
            txtDecemberRequests.Text = decemberRequests + (decemberRequests > 1 ? " Requests" : " Request");
        }
    }
}
