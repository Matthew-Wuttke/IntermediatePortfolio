//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntermPortfolio
{
    class Info
    {
        //Data members
        string name;
        string course;
        string instructor;
        string assignmentName;

        public Info() //Constructor
        {
            name = "Matthew Wuttke";
            course = "ITDEV 115 - Intermediate OOP";
            instructor = "Judy Ligocki";
        }
        public Info(string assignment) //Constructor with a parameter
        {
            name = "Matthew Wuttke";
            course = "ITDEV 115 - Intermediate OOP";
            instructor = "Judy Ligocki";
            assignmentName = assignment;
        }
        
        //Displays all my information for the course
        public void DisplayInfo()
        {
            System.Console.WriteLine("******************************************************");
            System.Console.WriteLine("Name:                     " + name);
            System.Console.WriteLine("Course:                   " + course);
            System.Console.WriteLine("Instructor:               " + instructor);
            System.Console.WriteLine("Assignment:               " + assignmentName);
            System.Console.WriteLine("Date:                     " + System.DateTime.Today.Date);
            System.Console.WriteLine("******************************************************");
            System.Console.WriteLine('\n');
            
        }
    }
}
