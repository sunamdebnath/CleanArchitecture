using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.Leavemanagement.Persistence.DatabaseContext.Repository
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var requests = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(a => a.Id == id);

            return requests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var requests = await _context.LeaveRequests                      
                .Include(q => q.LeaveType)
                .ToListAsync();

            return requests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            var requests = await _context.LeaveRequests
                .Where(a => a.RequestingEmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();

            return requests;
        }
    }
}
