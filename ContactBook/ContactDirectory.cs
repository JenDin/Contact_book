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

        // Save and serialize JSON object
        private void SerializeAndSave()
		{
			string jsonStr = JsonConvert.SerializeObject(_contacts);
			File.WriteAllText(_jsonFile, jsonStr);
		}
	}
}

