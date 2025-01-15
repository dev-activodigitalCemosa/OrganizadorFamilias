using organizadorFamilia.Domain;
using System.Windows.Forms;

namespace organizadorFamilia.Forms
{
    public partial class FamConnect : Form
    {
        private readonly Connection _connection;
        public FamConnect(Connection connection, string configFilePath)
        {
            _connection = connection;
            Connection connectionConfig = ConfigReader.LoadConnectionConfig(configFilePath,_connection);
            _connection = connectionConfig;
            InitializeComponent();
            cmbServer.Text = _connection.Server;
            cmbPort.Text = _connection.Port;
            cmbDatabase.Text = _connection.Database;
            txtUser.Text = _connection.Username;
            txtPassword.Text = _connection.Password;
        }

        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            _connection.Server = cmbServer.Text;
            _connection.Database = cmbDatabase.Text;
            _connection.Port = cmbPort.Text;
            _connection.Username = txtUser.Text;
            _connection.Password = txtPassword.Text;

            this.Close();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
