using CS420B_RestfulApi.Data;
using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Models.Table;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.VM;

namespace CS420B_RestfulApi.Repository.Services
{
    public class PaymentRepository : IPayment
    {
        private readonly ApiContext _context;
        public PaymentRepository(ApiContext context) { 
            _context = context;
        }
        public List<PaymentVM> GetAll()
        {
            var payments = _context.Payments.Select(opt => new PaymentVM
            {
                PaymentID = opt.PaymentID,
                BookingID = (Guid)opt.BookingID,
                Amount = opt.Amount,
                PaymentDate = opt.PaymentDate,
                PaymentMethod = opt.PaymentMethod,
            });
            return payments.ToList();
        }

        public PaymentVM GetById(int id)
        {
            var payments = _context.Payments.SingleOrDefault(opt => opt.PaymentID == id);
            if (payments != null)
            {
                return new PaymentVM
                {
                    PaymentID = payments.PaymentID,
                    BookingID = (Guid)payments.BookingID,
                    Amount = payments.Amount,
                    PaymentDate = payments.PaymentDate,
                    PaymentMethod = payments.PaymentMethod,
                };
            }
            return null;
        }

        public PaymentVM Add(PaymentModule paymentModule)
        {
            var payments = new Payment
            {
                BookingID = paymentModule.BookingID,
                Amount = paymentModule.Amount,
                PaymentDate = paymentModule.PaymentDate,
                PaymentMethod = paymentModule.PaymentMethod,
            };

            _context.Payments.Add(payments);
            _context.SaveChanges();

            return new PaymentVM
            {
                PaymentID = payments.PaymentID,
                BookingID = (Guid)payments.BookingID,
                Amount = payments.Amount,
                PaymentDate = payments.PaymentDate,
                PaymentMethod = payments.PaymentMethod,
            };
        }

        public void Delete(int id)
        {
            var payments = _context.Payments.SingleOrDefault(opt => opt.PaymentID == id);
            if (payments != null)
            {
                _context.Payments.Remove(payments);
                _context.SaveChanges();
            }
        }
               
        public void Update(PaymentVM paymentVM)
        {
            var payments = _context.Payments.SingleOrDefault(opt => opt.PaymentID == paymentVM.PaymentID);
            if (payments != null)
            {
                payments.PaymentID = paymentVM.PaymentID;
                payments.BookingID = paymentVM.BookingID;
                payments.Amount = paymentVM.Amount;
                payments.PaymentDate = paymentVM.PaymentDate;
                payments.PaymentMethod = paymentVM.PaymentMethod;
                _context.SaveChanges();
            }
        }
    }
}
