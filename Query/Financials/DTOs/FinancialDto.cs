using Domain.Financials.Enums;
using Query.People.DTOs;
using Query.Utilities;

namespace Query.Financials.DTOs
{
    public class FinancialDto : BaseDto
    {
        public long PersonId { get; set; }
        public string Payment { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime? PaidDate { get; set; }
        public virtual PersonDto Person { get; set; }
    }
}
