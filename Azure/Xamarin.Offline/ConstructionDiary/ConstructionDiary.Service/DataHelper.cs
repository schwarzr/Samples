using System;
using System.Linq;
using ConstructionDiary.Database;
using ConstructionDiary.Database.Entities;

namespace ConstructionDiary.Web
{
    public class DataHelper
    {
        private static readonly string[] _areas = new[]
        {
            "main entrance",
            "caffeteria",
            "storage area",
            "building 1",
            "building 2",
            "building 3",
            "mine entry area",
            "mine sublevel 1",
            "mine sublevel 2",
            "mine sublevel 3",
        };

        public static void InsertData(DiaryContext ctx)
        {
            var brazil = new Country { Id = Guid.NewGuid(), Name = "Brazil", TwoLetterIso = "BR" };
            var austria = new Country { Id = Guid.NewGuid(), Name = "Austria", TwoLetterIso = "AT" };
            var indonesia = new Country { Id = Guid.NewGuid(), Name = "Indonesia", TwoLetterIso = "ID" };

            var project1 = new Project { Id = Guid.NewGuid(), ProjectName = "Fortaleza", Longitude = -3.7844296m, Latitude = -38.6557987m, CountryId = brazil.Id };
            var project2 = new Project { Id = Guid.NewGuid(), ProjectName = "Gerlos", Longitude = 47.2206366m, Latitude = 12.0264733m, CountryId = austria.Id };
            var project3 = new Project { Id = Guid.NewGuid(), ProjectName = "Walai", Longitude = -3.7627406m, Latitude = 121.9409223m, CountryId = indonesia.Id };

            var projects = new[] { project1, project2, project3 };

            ctx.Countries.AddRange(brazil, austria, indonesia);
            ctx.Projects.AddRange(projects);

            foreach (var project in projects)
            {
                for (int i = 0; i < 10; i++)
                {
                    var employee = new Employee { Id = Guid.NewGuid(), Created = DateTime.Now, FirstName = "Employee", LastName = $"Name {i}", ProjectId = project.Id };
                    var area = new Area { Id = Guid.NewGuid(), AreaName = _areas[i], ProjectId = project.Id };
                    ctx.Areas.Add(area);
                    ctx.Employees.Add(employee);
                }
            }

            var issueTypes = new[] {
                new IssueType { Id = new Guid(), Title = "structural damage"},
                new IssueType { Id = new Guid(), Title = "electrical issues"},
                new IssueType { Id = new Guid(), Title = "material damage"},
                new IssueType { Id = new Guid(), Title = "broken tool"},
                new IssueType { Id = new Guid(), Title = "vehicle issue"},
            };

            ctx.IssueTypes.AddRange(issueTypes);

            for (int i = 0; i < 10000; i++)
            {
                var issue = new Issue { Id = Guid.NewGuid(), Title = $"Issue Nr {i}", IssueTypeId = issueTypes[i % issueTypes.Length].Id, AreaId = project1.Areas.ElementAt(i % 10).Id, CreationTime = DateTime.Now };

                if (i % 13 < 10)
                {
                    issue.AssignedToId = project1.Employees.ElementAt(i % 13).Id;
                }

                ctx.Issues.Add(issue);
            }

            ctx.SaveChanges();
        }
    }
}