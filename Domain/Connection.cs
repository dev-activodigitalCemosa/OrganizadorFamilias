using System.Runtime.Remoting.Channels;

namespace organizadorFamilia.Domain
{
    public class Connection
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string CreateConnectionString()
        {
            string connectionString = $"Server={this.Server};Port={this.Port};Database={this.Database};User Id={this.Username};Password={this.Password};";
            return connectionString;
        }

    }
}
