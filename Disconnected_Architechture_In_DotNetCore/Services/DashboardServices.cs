using Disconnected_Architechture_In_DotNetCore.Entities;
using Disconnected_Architechture_In_DotNetCore.InterFace;
using Disconnected_Architechture_In_DotNetCore.ModelDTO;
using Disconnected_Architechture_In_DotNetCore.Repositary;

namespace Disconnected_Architechture_In_DotNetCore.Services
{
    public class DashboardServices : IDashboardService
    {
        IDashboardRepositary _dashboardRepositary;
        public DashboardServices(IDashboardRepositary dashboardRepositary)
        {
            _dashboardRepositary = dashboardRepositary;
        }

        public async Task<bool> AddDashboardDetails(DashboardDTO dashboard)
        {
            Dashboard obj = new Dashboard();
            obj.position = dashboard.position;
            obj.name = dashboard.name;
            obj.weight = dashboard.weight;
            obj.symbol = dashboard.symbol;
            obj.location = dashboard.location;
            await _dashboardRepositary.AddDashboardDetails(obj);
            return true;
        }

        public async Task<List<Dashboard>> GetAllDashboard()
        {
            List<Dashboard> objBookingDto = new List<Dashboard>();
            var result = await _dashboardRepositary.GetAllDashboard();
            foreach (Dashboard bookingobj in result)
            {
                Dashboard obj = new Dashboard();
                obj.position = bookingobj.position;
                obj.name = bookingobj.name;
                obj.weight = bookingobj.weight;
                obj.symbol = bookingobj.symbol;
                obj.location = bookingobj.location;
                objBookingDto.Add(obj);
            }
            return objBookingDto;
        }

        public async Task<Dashboard> GetDashboardbyId(int id)
        {
            var bookingobj = await _dashboardRepositary.GetDashboardbyId(id);

            DashboardDTO bookingdtoobj = new DashboardDTO();
            bookingdtoobj.position = bookingobj.position;
            bookingdtoobj.name = bookingobj.name;
            bookingdtoobj.weight = bookingobj.weight;
            bookingdtoobj.symbol = bookingobj.symbol;
            bookingdtoobj.location = bookingobj.location;

            return bookingobj;
        }

        public async Task<bool> RemoveDashboardDetailsById(int id)
        {
            await _dashboardRepositary.RemoveDashboardDetailsById(id);
            return true;
        }

      

        public async Task<bool> UpdateDashBoardDetails(DashboardDTO dashboarddto)
        {
            Dashboard  dashboard1 = new Dashboard();
            dashboard1.position = dashboarddto.position;
            dashboard1.name = dashboarddto.name;
            dashboard1.weight = dashboarddto.weight;
            dashboard1.symbol = dashboarddto.symbol;
            dashboard1.location = dashboarddto.location;

            await _dashboardRepositary.UpdateDashBoardDetails(dashboard1);
            return true;
        }
    }
}
