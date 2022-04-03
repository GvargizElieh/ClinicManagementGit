using Domain.Financials;
using Query.Financials.DTOs;
using Query.People;

namespace Query.Financials
{
    public static class FinancialMapper
    {
        public static FinancialDto Map(this Financial? financial)
        {
            if(financial == null)
                return new FinancialDto();

            return new FinancialDto()
            {
                Id = financial.Id,
                CreationDate = financial.CreationDate,
                PersonId = financial.PersonId,
                Payment = financial.Payment,
                PaymentAmount = financial.PaymentAmount,
                PaidAmount = financial.PaidAmount,
                Status = financial.Status,
                PaidDate = financial.PaidDate,
                Person = financial.Person.Map(),
            };
        }

        public static ICollection<FinancialDto> Map(this ICollection<Financial> financials)
        {
            var model = new List<FinancialDto>();

            foreach (Financial financial in financials)
            {
                model.Add(Map(financial));
            }

            return model;
        }
    }
}
