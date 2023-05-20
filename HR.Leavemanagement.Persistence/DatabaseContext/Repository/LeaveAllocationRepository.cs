using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.Leavemanagement.Persistence.DatabaseContext.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            var isPresent = await _context.LeaveAllocations.AnyAsync(a => a.EmployeeId == userId
                            && a.LeaveTypeId == leaveTypeId && a.Period == period);
            return isPresent;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            return await _context.LeaveAllocations 
                .Include(a => a.LeaveType)
                .ToListAsync();            
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            return await _context.LeaveAllocations
                .Where(a => a.EmployeeId == userId)
                .Include(a => a.LeaveType)
                .ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            return await _context.LeaveAllocations
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int laveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(a => a.EmployeeId == userId && a.LeaveTypeId==laveTypeId);
        }
    }
}
