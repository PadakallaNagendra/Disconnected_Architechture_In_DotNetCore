using Disconnected_Architechture_In_DotNetCore.Entities;
using Disconnected_Architechture_In_DotNetCore.ModelDTO;

namespace Disconnected_Architechture_In_DotNetCore.InterFace
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllCustomer();
        Task<CustomerDTO> GetCustomerById(int id);
        Task<bool> AddCustomer(CustomerDTO customerDto);
        Task<bool> UpdateCustomer(CustomerDTO customerDto);
        Task<bool> DeleteCustomerById(int id);
    }
}
