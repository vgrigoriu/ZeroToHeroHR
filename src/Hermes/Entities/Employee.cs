using System;

namespace Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public Job Job { get; set; }

        public decimal? Salary { get; set; }

        public decimal? CommissionPct { get; set; }

        public Employee Manager { get; set; }

        public Department Department { get; set; }

        public override string ToString()
        {
            var result = $"{FirstName} {LastName} ({Job.JobTitle})";

            if (Department != null)
            {
                result += $" in {Department}";
            }

            if (Manager != null)
            {
                result += $" under {Manager}";
            }

            return result;
        }
    }
}
