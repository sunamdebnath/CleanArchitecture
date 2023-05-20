using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTest.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypesMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType()
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name =  "Test Vacation"
                },
                new LeaveType()
                {
                    Id = 2,
                    DefaultDays = 5,
                    Name = "Test Sick"
                },
                new LeaveType()
                {
                    Id = 3,
                    DefaultDays = 180,
                    Name = "Test Maternity"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(x => x.GetAsync()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(x => x.CreateAsync(It.IsAny<LeaveType>()))
                .Returns((LeaveType leaveType) => {
                    leaveTypes.Add(leaveType);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
