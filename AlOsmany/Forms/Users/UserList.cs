using AlOsmanyDataModel;
using AlOsmanyDataModel.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AlOsmany.Forms.Users
{
    public partial class UserList : Form
    {
        private readonly User _userLoggedIn;

        public UserList(User userLoggedIn)
        {
            InitializeComponent();

            _userLoggedIn = userLoggedIn;

            var _alOsmanyDbContext = new AlOsmanyDbContext();

            dataGridView1.DataSource = _alOsmanyDbContext.Users.Select(user => new
            {
                user.Id,
                user.UserName,
                user.FullName,
                user.Role,
                user.PhoneNumber
            }).ToListAsync().Result;
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();

            var thread = new Thread(() => Application.Run(new Dashboard(_userLoggedIn)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
