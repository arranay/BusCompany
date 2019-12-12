using System.Data.SqlClient;
using log4net;

namespace BusCompany.DAO
{
    public class ClassDAO
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;

        protected static readonly ILog log = LogManager.GetLogger(typeof(ClassDAO));
        protected SqlConnection Connection { get; set; }

        public void Connect()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Соединение открыто");
        }

        public void Disconnect()
        {
            Connection.Close();
            log.Info("Соединение закрыто");
        }

        private string connectionStringUsers = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void ConnectUsers()
        {
            Connection = new SqlConnection(connectionStringUsers);
            Connection.Open();
            log.Info("Соединение открыто");
        }

        public void DisconnectUsers()
        {
            Connection.Close();
            log.Info("Соединение закрыто");
        }

    }
}