using System;

namespace DH.Lending.Borrower.Business.Repository
{
    [Serializable]
    public class BorrowerCollectionCriteria
    {
        public IdType QueryIdType { get; set; }
        public Guid QueryId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        [Serializable]
        public enum IdType
        {
            Undefined = 0,
            Partner = 1,
            Cobrander = 2,
            SiteProfile = 3,
            Account = 4
        }
    }
}
