using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class ExampleWithTapErrorMethod
    {
        public string TapError_non_async(int customerId, decimal moneyAmount)
        {
            var paymentGateway = new PaymentGateway();
            var database = new Database();

            return GetById(customerId)
                .ToResult("Customer with such Id is not found: " + customerId)
                .Tap(customer => customer.AddBalance(moneyAmount))
                .Check(customer => paymentGateway.ChargePayment(customer, moneyAmount))
                .Bind(
                    customer => database.Save(customer)
                        .TapError(() => paymentGateway.RollbackLastTransaction()))
                .Finally(result => result.IsSuccess ? "OK" : result.Error);
        }

        private Maybe<Customer> GetById(long id)
        {
            return new Customer();
        }

        private class Customer
        {
            public void AddBalance(decimal moneyAmount)
            {

            }
        }

        private class PaymentGateway
        {
            public Return ChargePayment(Customer customer, decimal moneyAmount)
            {
                return Return.Success();
            }

            public void RollbackLastTransaction()
            {

            }

            public Task RollbackLastTransactionAsync()
            {
                return Task.FromResult(1);
            }
        }

        private class Database
        {
            public Return Save(Customer customer)
            {
                return Return.Success();
            }
        }
    }
}
