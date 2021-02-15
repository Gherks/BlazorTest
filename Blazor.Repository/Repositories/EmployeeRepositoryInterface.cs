using Blazor.Domain;
using System;
using System.Collections.Generic;

namespace Blazor.Persistence.Repositories
{
    public interface EmployeeRepositoryInterface
    {
        Employee CreateEmployee(string name, int age);
        bool DeleteEmployee(Guid id);
        Employee GetEmployee(Guid id);
        Employee GetEmployee(string name);
        IEnumerable<Employee> GetEmployees();
        void Save();
    }
}
