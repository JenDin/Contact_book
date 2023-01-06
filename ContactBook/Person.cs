using System;
namespace ContactBook
{
    public class Person
    {
        // Field members
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNo { get; private set; }
        public Address Address { get; }

        // Validate that each field member is set
        public Person(string firstName, string lastName, string phoneNo, Address address)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException("First name cannot be null");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException("Last name cannot be null");
            }

            if (string.IsNullOrEmpty(phoneNo))
            {
                throw new ArgumentNullException("Phone number cannot be null");
            }

            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            Address = address;
        }
    }
}