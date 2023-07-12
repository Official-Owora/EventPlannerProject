using EventPlannerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.Contracts
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> FindAllAssignmentsAsync(bool trackChanges);
        Task<Assignment> FindAssignmentByIdAsync(int Id, bool trackChanges);
        void CreateAssignment(Assignment assignment);
        void DeleteAssignment(Assignment assignment);
        void UpdateAssignment(Assignment assignment);
    }
}
