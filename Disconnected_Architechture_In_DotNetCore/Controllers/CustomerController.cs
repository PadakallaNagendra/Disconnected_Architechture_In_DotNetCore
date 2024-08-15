using Disconnected_Architechture_In_DotNetCore.InterFace;
using Disconnected_Architechture_In_DotNetCore.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using Disconnected_Architechture_In_DotNetCore.Entities;

namespace Disconnected_Architechture_In_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet(Name = "GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var bookingData = await _customerService.GetAllCustomer();
                if (bookingData != null)
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> Post([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var customer12 = await _customerService.AddCustomer(customerDTO);
                return StatusCode(StatusCodes.Status201Created, "customer  Added Succesfully");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpDelete]
        [Route("DeleteCustomerById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var countryData = await _customerService.DeleteCustomerById(id);
                if (countryData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "customer Id not found");
                }
                else
                {
                    // var Data = await _bookingservice.DeleteBookingDetilsById(id);
                    return StatusCode(StatusCodes.Status204NoContent, "customer details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> PUT([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _customerService.UpdateCustomer(customerDTO);
                return StatusCode(StatusCodes.Status201Created, "Customer Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var bookingData = await _customerService.GetCustomerById(id);
                if (bookingData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Customer Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        } //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id < 0)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
        //    }

        //    try
        //    {
        //        var countryData = await _customerService.DeleteCustomerById(id);
        //        if (countryData == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, "customer Id not found");
        //        }
        //        else
        //        {
        //            // var Data = await _bookingservice.DeleteBookingDetilsById(id);
        //            return StatusCode(StatusCodes.Status204NoContent, "customer details deleted successfully");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
        //    }
        //}


    }



}
