using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Repository.VM;

namespace CS420B_RestfulApi.Repository.IRepository
{
    public interface IPayment
    {
        List<PaymentVM> GetAll();
        PaymentVM GetById(int id);
        PaymentVM Add(PaymentModule paymentModule);
        void Update(PaymentVM paymentVM);
        void Delete(int id);
    }
}
