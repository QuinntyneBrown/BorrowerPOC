using System.Configuration;

namespace DH.Lending.Borrower.Data.DataAccess
{
    internal static class ModelSettings
    {
        public static string BorrowerConnectionString => ConfigurationManager.ConnectionStrings["Borrower"].ConnectionString;
    }
}
