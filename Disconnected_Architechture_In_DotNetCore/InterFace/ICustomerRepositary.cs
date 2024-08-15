using Disconnected_Architechture_In_DotNetCore.Entities;

namespace Disconnected_Architechture_In_DotNetCore.InterFace
{
    public interface ICustomerRepositary
    {
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(int id);
        Task<bool> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomerById(int id);
        
    }
}
