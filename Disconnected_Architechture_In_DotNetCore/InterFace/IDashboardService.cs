using Disconnected_Architechture_In_DotNetCore.Entities;
using Disconnected_Architechture_In_DotNetCore.ModelDTO;

namespace Disconnected_Architechture_In_DotNetCore.InterFace
{
    public interface IDashboardService
    {
        Task<List<DashboardDTO>> GetAllDashboard();
        Task<DashboardDTO> GetDashboardbyId(int id);
        Task<bool> AddDashboardDetails(DashboardDTO dashboard);
        Task<bool> UpdateDashBoardDetails(DashboardDTO dashboarddto);
        Task<bool> RemoveDashboardDetailsById(int id);
    }
}
