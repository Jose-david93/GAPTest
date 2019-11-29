using Insight.Database;
using Ninject;
using System.Data.SqlClient;

namespace GAP.AccessData.Insight
{
    //ORM Insight
    class ADInsight
    {
        private static string DefaultConnection = "Data Source=.;Initial Catalog=Clinic_db;Integrated Security=True";// ConfigurationHelper.GetConfig()["ConnectionStringBol"];

        [Inject]
        public static SqlConnection DefaultCnn
        {
            get
            {
                SqlInsightDbProvider.RegisterProvider();
                return new SqlConnection(DefaultConnection);
            }
        }
    }
}
