using System;
using System.Collections.Generic;

public interface ISalaryCalculator
{
    double CalculateSalary(Employee employee);
}

public class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }
    public string EmployeeType { get; set; } 
}

public class PermanentSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.2; 
    }
}

public class ContractSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.1; 
    }
}

public class InternSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 0.8; 
    }
}

public class FreelancerSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary; 
    }
}

public class EmployeeSalaryCalculator
{
    private readonly Dictionary<string, ISalaryCalculator> _salaryCalculators;

    public EmployeeSalaryCalculator()
    {
        _salaryCalculators = new Dictionary<string, ISalaryCalculator>
        {
            { "Permanent", new PermanentSalaryCalculator() },
            { "Contract", new ContractSalaryCalculator() },
            { "Intern", new InternSalaryCalculator() },
            { "Freelancer", new FreelancerSalaryCalculator() }
        };
    }

    public double CalculateSalary(Employee employee)
    {
        if (_salaryCalculators.TryGetValue(employee.EmployeeType, out var calculator))
        {
            return calculator.CalculateSalary(employee);
        }

        throw new NotSupportedException("Тип сотрудника не поддерживается");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var employee1 = new Employee { Name = "Алиса", BaseSalary = 1000, EmployeeType = "Permanent" };
        var employee2 = new Employee { Name = "Боб", BaseSalary = 1000, EmployeeType = "Contract" };
        var employee3 = new Employee { Name = "Чарли", BaseSalary = 1000, EmployeeType = "Intern" };
        var employee4 = new Employee { Name = "Дэвид", BaseSalary = 1000, EmployeeType = "Freelancer" };

        var salaryCalculator = new EmployeeSalaryCalculator();

        Console.WriteLine($"Зарплата {employee1.Name}: {salaryCalculator.CalculateSalary(employee1):F2} тенге");
        Console.WriteLine($"Зарплата {employee2.Name}: {salaryCalculator.CalculateSalary(employee2):F2} тенге");
        Console.WriteLine($"Зарплата {employee3.Name}: {salaryCalculator.CalculateSalary(employee3):F2} тенге");
        Console.WriteLine($"Зарплата {employee4.Name}: {salaryCalculator.CalculateSalary(employee4):F2} тенге");
    }
}
