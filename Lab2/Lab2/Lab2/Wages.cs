using System;


namespace Lab2
{
    public class Wages : Employee
    {
        public double Hours { get; set; }
        public double Rate { get; set; }

        public Wages(string id, string name, string address, string phone, long sin, string dateOfBirth, string department, double hours, double rate) : base(id, name, address, phone, sin, dateOfBirth, department)

        {
            Hours = hours;
            Rate = rate;
        }

        public double GetPay()
        {
            double salary = 0;
           
            if (Hours <= 40)
            {
                salary = Hours * Rate;
            }
            else
            {
                double regularHours = 40;
                double overtimeHours = Hours - regularHours;

                salary = regularHours * Rate + (overtimeHours * Rate * 1.5);
            }

            return salary;

           
        }
    }
}
