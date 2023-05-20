using HR.Leavemanagement.Persistence.DatabaseContext;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using Xunit;

namespace HR.LeaveManagement.Persisitence.IntegrationTests
{
    public class HrDatabaseContextTests
    {
        private readonly HrDatabaseContext _hrDatabaseContext;

        public HrDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _hrDatabaseContext = new HrDatabaseContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            // Act 
            _hrDatabaseContext.LeaveTypes.Add(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            //Assert

            leaveType.DateCreated.ShouldNotBeNull();

        }
        [Fact]
        public void Save_SetDateModifiedValue()
        {
            

        }
    }
 }