using System;
namespace ContactBook
{
	public class Address
	{
        // Properties
        public string StreetName { get; private set; }
        public string StreetNo { get; private set; }

        // Constructor - validate inputs and set them
        public Address(string streetName, string streetNo)
        {
            if (string.IsNullOrEmpty(streetName))
            {
                throw new ArgumentNullException("Street name cannot be null");
            }

            if (string.IsNullOrEmpty(streetNo))
            {
                throw new ArgumentNullException("Street number cannot be null");
            }

            StreetName = streetName;
            StreetNo = streetNo;
        }

        // Update address
        public void Update(string streetName, string streetNo)
        {
            if(!string.IsNullOrEmpty(streetName))
            {
                StreetName = streetName;
            }

            if(!string.IsNullOrEmpty(streetNo))
            {
                StreetNo = streetNo;
            }
        }

        // Override the default output
        public override string ToString()
        {
            var message = $"{StreetName} {StreetNo}";
            return message;
        }
    }
}

