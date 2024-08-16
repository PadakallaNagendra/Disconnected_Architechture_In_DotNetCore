using Disconnected_Architechture_In_DotNetCore.InterFace;
using Disconnected_Architechture_In_DotNetCore.ModelDTO;
using Disconnected_Architechture_In_DotNetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disconnected_Architechture_In_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet(Name = "GetAllDashboard")]
        public async Task<IActionResult> get()
        {
            try
            {
                var dashboardData = await _dashboardService.GetAllDashboard();
                if (dashboardData != null)
                {
                    return StatusCode(StatusCodes.Status200OK, dashboardData);
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
        [Route("AddDashboardDetails")]
        public async Task<IActionResult> Post([FromBody] DashboardDTO dashboardDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var dashboard = await _dashboardService.AddDashboardDetails(dashboardDTO);
                return StatusCode(StatusCodes.Status201Created, "dashboard  Added Succesfully");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpDelete]
        [Route("RemoveDashboardDetailsById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var dashboarddata = await _dashboardService.RemoveDashboardDetailsById(id);
                if (dashboarddata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Dashboard position not found");
                }
                else
                {
                    // var Data = await _bookingservice.DeleteBookingDetilsById(id);
                    return StatusCode(StatusCodes.Status204NoContent, "databoard details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPut]
        [Route("UpdateDashBoardDetails")]
        public async Task<IActionResult> PUT([FromBody] DashboardDTO dashboardDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var dashboard = await _dashboardService.UpdateDashBoardDetails(dashboardDTO);
                return StatusCode(StatusCodes.Status201Created, "dashboard Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpGet]
        [Route("GetDashboardbyId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var dashboard = await _dashboardService.GetDashboardbyId(id);
                if (dashboard == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "dashboard Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, dashboard);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
