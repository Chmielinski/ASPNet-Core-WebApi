using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
    }
}
