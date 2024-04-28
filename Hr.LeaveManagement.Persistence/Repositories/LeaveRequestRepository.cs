using Hr.LeaveManagement.Persistence.DatabseContext;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hr.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HRDatabaseContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();

            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaverequestWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests.Where(q => q.RequestingEmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveRequest;
        }

        

 
    }
}
