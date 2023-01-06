using System;
using Newtonsoft.Json;

namespace ContactBook
{
	public class ContactDirectory
	{
        // Field members
        private string _jsonFile = Directory.GetCurrentDirectory().ToString() + @"contactDirectory.json";
        private List<Person> _contacts = new List<Person>();

		// Constructor - deserialize all JSON objects
        public ContactDirectory()
		{
			if(File.Exists(_jsonFile))
			{
				string jsonStr = File.ReadAllText(_jsonFile);

				if(!string.IsNullOrEmpty(jsonStr))
				{
					_contacts = JsonConvert.DeserializeObject<List<Person>>(jsonStr);
				}
			}
		}

		// Get all contacts
		public List<Person> GetContacts()
		{
			return _contacts;
		}

		// Get a specific contact by index

		public Person GetContactByIndex(int index)
		{
			var person = _contacts[index];
			return person;
		}

		// Create new contact
		public Person AddContact(Person person)
		{
			try
			{
                _contacts.Add(person);
                SerializeAndSave();
                return person;
            }
			catch (Exception ex)
			{
				Console.WriteLine("Det gick inte att lägga till denna kontakt. Försök igen.", ex);
			}

			return null;
		}

		// Update a contact
		public Person UpdateContact(int index, string firstName, string lastName, string phoneNo, string streetName, string streetNo)
		{
			try
			{
				var person = GetContactByIndex(index);
				person.Address.Update(streetName, streetNo);
				person.Update(firstName, lastName, phoneNo);
				SerializeAndSave();
				return person;
			}
			catch (Exception ex)
			{
                Console.WriteLine("Det gick inte att uppdatera denna kontakt. Försök igen.", ex);
            }

			return null;
		}

		// Delete a contact
		public int DeleteContact(int index)
		{
			try
			{
				_contacts.RemoveAt(index);
				SerializeAndSave();
				return index;
			}
			catch (Exception ex)
			{
                Console.WriteLine("Detta index existerar inte. Försök igen.", ex);
            }
			return 0;
		}

        // Save and serialize JSON object
        private void SerializeAndSave()
		{
			string jsonStr = JsonConvert.SerializeObject(_contacts);
			File.WriteAllText(_jsonFile, jsonStr);
		}
	}
}

