using WorkScheduler.Data;

namespace WorkScheduler.Database;

public static class WorkDbInitializer
{
    public static void Initialize(WorkDbContext context)
    {
        context.Database.EnsureCreated();
        if (context.Works.Any())
        {
            return;
        }

        var works = new Work[]
        {
            //BUG Seeding requires manual setting of created and updated
            new()
            {
                Assignee = "Tom",
                Description = "Fix the bug",
                Name = "Bug needs working",
                DeadLine = DateTime.Today.Add(TimeSpan.FromDays(3)),
                Created = DateTime.Now,
                Updated = DateTime.Now
            }
        };

        foreach (var work in works)
        {
            context.Works.Add(work);
        }
        
        context.SaveChanges();
    }
}