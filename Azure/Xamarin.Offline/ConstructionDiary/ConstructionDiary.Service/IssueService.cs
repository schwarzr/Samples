using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Database.Entities;
using ConstructionDiary.Model;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Service
{
    public class IssueService : IIssueService
    {
        private readonly DiaryContext _context;

        public IssueService(DiaryContext context)
        {
            this._context = context;
        }

        public async Task CreateIssueAsync(IssueCreateItem item)
        {
            var issue = new Issue
            {
                Id = Guid.NewGuid(),
                AssignedToId = item.AssignedToId,
                AreaId = item.AreaId,
                CreationTime = new DateTime(),
                IssueDescripton = item.Descripton,
                Title = item.Title,
                IssueTypeId = item.IssueTypeId,
            };

            if (item.Attachments != null)
            {
                foreach (var attachment in item.Attachments)
                {
                    var ia = new IssueAttachment { Id = Guid.NewGuid(), IssueId = issue.Id, Content = attachment };
                    issue.Attachments.Add(ia);
                }
            }
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IssueListItem>> GetIssuesAsync(Guid projectId)
        {
            var query = _context.Issues
                            .Where(p => p.Area.ProjectId == projectId)
                            .Select(p => new IssueListItem
                            {
                                Id = p.Id,
                                Title = p.Title,
                                Description = p.IssueDescripton,
                                AssignedTo = p.AssignedTo.FirstName + " " + p.AssignedTo.LastName,
                                IssueType = p.IssueType.Title,
                                CreateTime = p.CreationTime
                            });

            var data = await query.ToListAsync();

            return data;
        }

        public async Task<IEnumerable<IssueTypeInfo>> GetIssueTypesAsync()
        {
            var data = await _context.IssueTypes.Select(p => new IssueTypeInfo { Id = p.Id, DisplayString = p.Title }).ToListAsync();

            return data;
        }
    }
}