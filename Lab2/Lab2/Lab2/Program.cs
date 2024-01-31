using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab2
{
    class Program
    {
        static List<Employee> LoadEmployeesListFromFile(string filePath)
        {
            List<Employee> employees = new List<Employee>();
            string[] fileLines = File.ReadAllLines(filePath);

            foreach (string line in fileLines)
            {
                if (line != "")
                {
                    string[] fields = line.Split(':');
                    string id = fields[0];
                    char id_firstChar = id[0];
                    switch (id_firstChar)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                            employees.Add(new Salaried(fields[0], fields[1], fields[2], fields[3],
                                                       long.Parse(fields[4]), fields[5],
                                                       fields[6], Double.Parse(fields[7])));
                            break;
   
                        case '5':
                            employees.Add(new PartTime(fields[0], fields[1], fields[2], fields[3],
                                                       long.Parse(fields[4]), fields[5],
                                                       fields[6], Double.Parse(fields[7]),
                                                       Double.Parse(fields[8])));
                            break;
                        case '6':
                            employees.Add(new Wages(fields[0], fields[1], fields[2], fields[3],
                                                       long.Parse(fields[4]), fields[5],
                                                       fields[6], Double.Parse(fields[7]),
                                                       Double.Parse(fields[8])));
                            break;
                    }
                }
            }
            return employees;
        }


        
        static double AveragePay(List<Employee> employees)
        {

            double totalPay = 0;
            foreach (Employee emp in employees)
            {
                if (emp is Salaried)
                {
                    totalPay += ((Salaried)emp).GetPay();
                }
                

            }
            return Math.Round(totalPay / employees.Count(), 2);
        }
        
			 
        static Wages HighestPayWagesEmployee(List<Employee> employees)
        {
            double highestPay = 0;
            Wages highestPayEmp = null;
            for (int i = 0; i < employees.Count(); i++)
            {
                Employee emp = employees[i];
                if (emp is Wages)
                {
                    Wages wageEmp = (Wages)emp;
                    if (wageEmp.GetPay() > highestPay)
                    {
                        highestPay = wageEmp.GetPay();
                        highestPayEmp = wageEmp;
                    }
                }
            }
            return highestPayEmp;
        }

       		 
        static Salaried LowestPaySalariedEmployee(List<Employee> employees)
        {
            double lowestPay = double.MaxValue;
            Salaried lowestPayEmp = null;
           
            foreach (Employee emp in employees)
            {
                if (emp is Salaried)
                {
                    Salaried salariedEmp = (Salaried)emp;
                    if (salariedEmp.GetPay() < lowestPay)
                    {
                        lowestPay = salariedEmp.GetPay();
                        lowestPayEmp = salariedEmp;
                    }
                }
            }
            return lowestPayEmp;
        }
        
        static double PercentageOfSalaried(List<Employee> employees)
        {
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is Salaried)
                {
                    count++;
                }
            }
            return Math.Round((double)count / employees.Count() * 100, 2);
        }

		
        static double PercentageOfWages(List<Employee> employees)
        {
            
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is Wages)
                {
                    count++;
                }
            }
            return Math.Round((double)count / employees.Count() * 100, 2);
           
        }
        
		
        static double PercentageOfPartTime(List<Employee> employees)
        {
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is PartTime)
                {
                    count++;
                }
            }
            return Math.Round((double)count / employees.Count() * 100, 2);
           
        }

        static void Main(string[] args)
        {
            string inputFilePath = @"D:\Sem-2\Object-Oriented Programming 2 (CPRG-211-E)\Labs\Lab-2\employees.txt";
            List<Employee> employees = LoadEmployeesListFromFile(inputFilePath);

            Console.WriteLine($"The average pay for all employees is: {AveragePay(employees)}");

            Wages wage_emp = HighestPayWagesEmployee(employees);
            Console.WriteLine($"The Wages employee with the highest pay is: {wage_emp} \n\twith salary of {wage_emp.GetPay()}");

            Salaried salaried_emp = LowestPaySalariedEmployee(employees);
            Console.WriteLine($"The Salaried employee with the lowest pay is: {salaried_emp} \n\twith salary of {salaried_emp.GetPay()}");

            Console.WriteLine($"Percentage of Salaried employees is: {PercentageOfSalaried(employees)} %");
            Console.WriteLine($"Percentage of Wages employees is: {PercentageOfWages(employees)} %");
            Console.WriteLine($"Percentage of Part Time employees is: {PercentageOfPartTime(employees)}%");

            Console.ReadKey();
        }
    }
}
