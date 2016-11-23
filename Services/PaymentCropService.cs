using Backend.Model;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface IPaymentCropService
    {
        ICollection<PaymentCropModel> List();
        PaymentCropFullModel GetByIdFullModel(int id);
        PaymentCropModel GetByIdShort(int id);
        PaymentCropElementaryAreaItem GetPaymentCropElementaryArea(int id);
    }

    public class PaymentCropService : IPaymentCropService
    {
        public ICollection<PaymentCropModel> List()
        {
            return new[]
            {
                new PaymentCropModel {Id = 1, Name = "test"},
                new PaymentCropModel {Id = 2, Name = "test2"}
            };
        }

        public PaymentCropFullModel GetByIdFullModel(int id)
        {
            return new PaymentCropFullModel
            {
                Id = id,
                Name = "testt"
            };
        }

        public PaymentCropModel GetByIdShort(int id)
        {
            return new PaymentCropModel
            {
                Id = id,
                Name = "testt"
            };
        }

        public PaymentCropElementaryAreaItem GetPaymentCropElementaryArea(int id)
        {
            return new PaymentCropElementaryAreaItem
            {
                Id = id
            };
        }

    }
}
