using EventPlannerProject.Application.Contracts;
using EventPlannerProject.Domain.Models;
using EventPlannerProject.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Persistence.Repositories
{
    internal sealed class AssignmentRepository : RepositoryBase<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateAssignment(Assignment assignment)
        {
            CreateAssignment(assignment);
        }

        public void DeleteAssignment(Assignment assignment)
        {
            DeleteAssignment(assignment);
        }

        public async Task<IEnumerable<Assignment>> FindAllAssignmentsAsync(bool trackChanges)
        {
            return await FindAllAsync(trackChanges)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Assignment?> FindAssignmentByAssigneePhoneNumber(string AssigneePhoneNumber, bool trackChanges)
        {
            var assignment = await FindByConditionAsync(x => x.AssigneePhoneNumber == AssigneePhoneNumber, trackChanges).ToListAsync();
            return assignment.FirstOrDefault();
        }

        public void UpdateAssignment(Assignment assignment)
        {
            UpdateAssignment(assignment);
        }
    }
}
