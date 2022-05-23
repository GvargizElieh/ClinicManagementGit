using ClinicManagement.Data.Financials.Enums;
using ClinicManagement.Data.People;

namespace ClinicManagement.Data.Financials
{
    public class Financial : BaseData
    {
        public long PersonId { get; set; }
        public string Payment { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime? PaidDate { get; set; }
        public virtual Person? Person { get; set; }
    }
}
