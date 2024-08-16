using Disconnected_Architechture_In_DotNetCore.Entities;

namespace Disconnected_Architechture_In_DotNetCore.InterFace
{
    public interface IDashboardRepositary
    {
        Task<List<Dashboard>> GetAllDashboard();
        Task<Dashboard> GetDashboardbyId(int id);
        Task<bool> AddDashboardDetails(Dashboard  dashboard);
        Task<bool> UpdateDashBoardDetails(Dashboard  dashboard);
        Task<bool> RemoveDashboardDetailsById(int id);
    }
}
