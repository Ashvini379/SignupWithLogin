using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignupWithLogin.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Salary { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}