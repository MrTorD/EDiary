using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TeacherRepository(AppDbContext dbContext) : ITeacherRepository
{
    public Teacher? GetTeacher(Guid id)
    {
        return dbContext.Teachers
            .AsNoTracking()
            .FirstOrDefault(t => t.Id == id);
    }

    public void CreateTeacher(Teacher teacher)
    {
        dbContext.Teachers.Add(teacher);
        dbContext.SaveChanges();
    }
}