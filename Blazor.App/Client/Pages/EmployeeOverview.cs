using Blazor.Client.Services;
using Blazor.Dto;
using Blazor.Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Client.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; private set; } = new List<Employee>();

        public CreationEmployeeDto InputEmployee { get; set; } = new CreationEmployeeDto();

        [Inject]
        public EmployeeDataServiceInterface EmployeeDataService { get; set; }

        public async void Submit_CreateNewEmployee()
        {
            if (InputEmployee.Name.Trim().Length > 0 && InputEmployee.Age > 0)
            {
                await EmployeeDataService.CreateEmployee(InputEmployee.Name, InputEmployee.Age);
                Employees = (await EmployeeDataService.GetEmployees()).ToList();

                StateHasChanged();
            }
        }

        public async void Remove_Employee(Guid id)
        {
            await EmployeeDataService.DeleteEmployee(id);
            Employees = (await EmployeeDataService.GetEmployees()).ToList();

            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetEmployees()).ToList();
        }
    }
}
