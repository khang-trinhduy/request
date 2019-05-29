using SharedKernel.Abstractions;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Request.API.Model
{
    public class User : AggregateRoot
    {
        public FullName FullName { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DOB { get; set; }
        public string Role { get; set; }

        protected User():base()
        { }

        private User(FullName fullName, DateTime dob)
        {
            FullName = fullName;
            DOB = dob;
        }

        public static User Create(FullName fullName, DateTime dob)
        {
            return new User(fullName, dob);
        }
    }
}