using BulkinaAnnaKT_31_20.Database;
using BulkinaAnnaKT_31_20.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulkinaAnnaKT_31_20.Interfaces.StudentsInterfaces.IStudentService;

namespace BulkinaAnnaKT_31_20.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {

            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>().UseInMemoryDatabase(databaseName: "prpr2").Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT3120_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "КТ-31-20"
                },
                new Group
                {
                    GroupName = "КТ-41-20"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    Name = "qwerty",
                    Surname = "asdf",
                    Patronym = "zxc",
                    GroupId = 1,
                },
                new Student
                {
                    Name = "qwerty2",
                    Surname = "asdf2",
                    Patronym = "zxc2",
                    GroupId = 2,
                },
                new Student
                {
                    Name = "qwerty3",
                    Surname = "asdf3",
                    Patronym = "zxc3",
                    GroupId = 1,
                },
                new Student
                {
                    Name = "qwerty4",
                    Surname = "asdf4",
                    Patronym = "zxc4",
                    GroupId = 1,
                }

            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.StudentFilters.StudentGroupFilter
            {
                GroupName = "КТ-41-20"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, studentsResult.Length);


        }
    }
}