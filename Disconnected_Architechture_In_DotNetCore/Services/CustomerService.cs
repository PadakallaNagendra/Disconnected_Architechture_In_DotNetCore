using Disconnected_Architechture_In_DotNetCore.Entities;
using Disconnected_Architechture_In_DotNetCore.InterFace;
using Disconnected_Architechture_In_DotNetCore.ModelDTO;

namespace Disconnected_Architechture_In_DotNetCore.Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepositary _customerRepositary;
        public CustomerService(ICustomerRepositary customerRepositary)
        {
            _customerRepositary = customerRepositary;
        }

        public async Task<bool> AddCustomer(CustomerDTO customerDto)
        {
            Customer obj = new Customer();
            
            // obj.id = bookingDetail.id;
            obj.CustomerName = customerDto.CustomerName;
            obj.Country = customerDto.Country;
            obj.City = customerDto.City;
            obj.Email = customerDto.Email;


            await _customerRepositary.AddCustomer(obj);
            return true;
        }

        public async Task<bool> DeleteCustomerById(int id)
        {
            await _customerRepositary.DeleteCustomerById(id);
            return true;
        }

        public async Task<List<CustomerDTO>> GetAllCustomer()
        {
            
                List<CustomerDTO> objBookingDto = new List<CustomerDTO>();
                var result = await _customerRepositary.GetAllCustomer();
                foreach (Customer bookingobj in result)
                {
                    CustomerDTO obj = new CustomerDTO();
                    obj.id = bookingobj.id;
                    obj.CustomerName = bookingobj.CustomerName;
                    obj.Country = bookingobj.Country;
                    obj.City = bookingobj.City;
                    obj.Email = bookingobj.Email;
                    objBookingDto.Add(obj);
                }
                return objBookingDto;
        }


        //GetCustomerById
        //public async Task<Customer> GetCustomerById(int id)
        //{
           
        //}

        public async Task<bool> UpdateCustomer(CustomerDTO customerDto)
        {
           Customer customer = new Customer();
            customer.id = customerDto.id;
            customer.CustomerName = customerDto.CustomerName;
            customer.Country = customerDto.Country;
            customer.City = customerDto.City;
            customer.Email = customerDto.Email;

            await _customerRepositary.UpdateCustomer(customer);
            return true;
        }

       public async Task <CustomerDTO> GetCustomerById(int id)
        {
            var bookingobj = await _customerRepositary.GetCustomerById(id);

            CustomerDTO bookingdtoobj = new CustomerDTO();
            bookingdtoobj.id = bookingobj.id;
            bookingdtoobj.CustomerName = bookingobj.CustomerName;
            bookingdtoobj.Email = bookingobj.Email;
            bookingdtoobj.City = bookingobj.City;
            bookingdtoobj.Country = bookingobj.Country;

            return bookingdtoobj;
        }
    }
}
