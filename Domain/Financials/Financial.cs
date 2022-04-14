using Domain.Financials.Enums;
using Domain.People;
using Domain.Utilities;

namespace Domain.Financials
{
    public class Financial : BaseEntity
    {
        internal Financial()
        {

        }

        public Financial(string payment, decimal paymentAmount)
        {
            Payment = payment;
            PaymentAmount = paymentAmount;
            PaidAmount = 0;
            Status = PaymentStatus.Pending;
            Person = new Person();
        }

        public long PersonId { get; internal set; }
        public string Payment { get; private set; }
        public decimal PaymentAmount { get; private set; }
        public decimal PaidAmount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime? PaidDate { get; private set; }
        public virtual Person Person { get; internal set; }

        public void Pay(decimal payAmount)
        {
            PaidAmount += payAmount;
            if (PaidAmount > PaymentAmount)
                throw new InvalidDataException($"{nameof(PaidAmount)} is more than {nameof(PaymentAmount)}.");
            else if (PaidAmount < PaymentAmount)
                return;

            Status = PaymentStatus.Paid;
            PaidDate = DateTime.Now;
        }

        public void Cancel()
        {
            Status = PaymentStatus.Canceled;
        }

        public void AssignPerson(Person person)
        {
            PersonId = person.Id;
            Person = person;
        }
    }
}
