using System;


namespace Lab2
{
    public class Salaried : Employee
    {
        public double Salary { get; set; }
        public Salaried(string id, string name, string address, string phone, long sin, string dateOfBirth, string department, double salary)
        : base(id, name, address, phone, sin, dateOfBirth, department)
        {
            Salary = salary;
        }
        public double GetPay()
        {
            return Salary;
        }
    }
}
