using BulkinaAnnaKT_31_20.Database;
using BulkinaAnnaKT_31_20.Models;
using BulkinaAnnaKT_31_20.Filters.StudentFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BulkinaAnnaKT_31_20.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
       public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);

       public class StudentService: IStudentService
        {
            private StudentDbContext _dbContext;
            public StudentService(StudentDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default) 
            {
                var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
                return students;
            }
        }
    }
}
