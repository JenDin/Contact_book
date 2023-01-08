using System.Collections.Generic;
using ContactBook;

// Create an instance of the ContactDirectory Class
ContactDirectory contactDirectory = new ContactDirectory();

while(true)
{
    Console.Clear();
    Console.WriteLine("* Tryck 1 för att söka efter kontakter");
    Console.WriteLine("* Tryck 2 för att lägga till en ny kontakt");
    Console.WriteLine("* Tryck 3 för att redigera och uppdatera en kontakt");
    Console.WriteLine("* Tryck 4 för att radera en kontakt");
    Console.WriteLine("* Tryck X för att avsluta programmet");
    Console.WriteLine("------------------------------");
    Console.WriteLine("Kontaktlista:");

    var contacts = contactDirectory.GetContacts();

    if(contacts.Any())
    {
        // Loop through the contact list
        foreach (var contact in contacts)
        {
            Console.WriteLine($"[{contacts.IndexOf(contact)}] - {contact}");
        }
    } else
    {
        Console.WriteLine("Kontaktboken är tom");
    }

    int input = (int)Console.ReadKey(true).Key;

    // Depending on input - call the corresponding function
    switch (input)
    {
        case '1':
            GetContactsByName();
            break;
        case '2':
            AddNewContact();
            break;
        case '3':
            EditAndUpdateContact();
            break;
        case '4':
            DeleteContact();
            break;
        case 88:
            Environment.Exit(0);
            break;
    }
}

// Loop through the contact list and print the search result
void GetContactsByName()
{
    Console.WriteLine("\nAnge ett förnamn:");
    string searchInput = Console.ReadLine();
    var people = contactDirectory.GetContactsByName(searchInput);

    if (people.Any())
    {
        foreach (var person in people)
        {
            Console.WriteLine(person.ToString());
        }
        Console.Read();
    } else
    {
        Console.WriteLine($"\n{searchInput} finns inte i kontaktboken");
        Console.Read();
    }
}


/*
 * Add a new contact -
 * Keep prompting for an input if the field is left empty
 */
void AddNewContact()
{
    // First name
    Console.WriteLine("Förnamn:");
    string firstName = Console.ReadLine();
    while(true)
    {
        if(!string.IsNullOrEmpty(firstName))
        {
            break;
        }

        Console.WriteLine("Du måste ange ett förnamn.");
        Console.WriteLine("Förnamn:");
        firstName = Console.ReadLine();
    }

    // Last name
    Console.WriteLine("Efternamn:");
    string lastName = Console.ReadLine();
    while (true)
    {
        if (!string.IsNullOrEmpty(lastName))
        {
            break;
        }

        Console.WriteLine("Du måste ange ett efternamn.");
        Console.WriteLine("Efternamn:");
        lastName = Console.ReadLine();
    }

    // Phone number
    Console.WriteLine("Telefonnummer:");
    string phoneNo = Console.ReadLine();
    while (true)
    {
        if (!string.IsNullOrEmpty(phoneNo))
        {
            break;
        }

        Console.WriteLine("Du måste ange ett telefonnummer.");
        Console.WriteLine("Telefonnummer:");
        phoneNo = Console.ReadLine();
    }

    // Street name
    Console.WriteLine("Gatunamn:");
    string streetName = Console.ReadLine();
    while (true)
    {
        if (!string.IsNullOrEmpty(streetName))
        {
            break;
        }

        Console.WriteLine("Du måste ange ett gatunamn.");
        Console.WriteLine("Gatunamn:");
        streetName = Console.ReadLine();
    }

    // Street number
    Console.WriteLine("Gatunummer:");
    string streetNo = Console.ReadLine();
    while (true)
    {
        if (!string.IsNullOrEmpty(streetNo))
        {
            break;
        }

        Console.WriteLine("Du måste ange ett gatunummer.");
        Console.WriteLine("Gatunummer:");
        streetNo = Console.ReadLine();
    }

    // Create a new contact object
    var address = new Address(streetName, streetNo);
    var person = new Person(firstName, lastName, phoneNo, address);
    contactDirectory.AddContact(person);
}

/*
 * Edit and update a contact
 * Keep prompting for an input if the field is left empty
 */
void EditAndUpdateContact()
{
    Console.Clear();
    Console.WriteLine("Ange ett index på den kontakt som ska uppdateras:");

    try
    {
        int indexToUpdate = Convert.ToInt32(Console.ReadLine());
        var person = contactDirectory.GetContactByIndex(indexToUpdate);

        Console.WriteLine();
        Console.WriteLine($"{person}\n");

        // First name
        Console.WriteLine($"Förnamn: {person.FirstName}");
        Console.Write("Nytt förnamn (valfritt): \n");
        string firstName = Console.ReadLine();

        // Last name
        Console.WriteLine($"Efternamn: {person.LastName}");
        Console.Write("Nytt efternamn (valfritt): \n");
        string lastName = Console.ReadLine();

        // Phone number
        Console.WriteLine($"Telefonnummer: {person.PhoneNo}");
        Console.Write("Nytt telefonnummer (valfritt): \n");
        string phoneNo = Console.ReadLine();

        // Street name
        Console.WriteLine($"Gatunamn: {person.Address.StreetName}");
        Console.Write("Nytt gatunamn (valfritt): \n");
        string streetName = Console.ReadLine();

        // Street number
        Console.WriteLine($"Gatunummer: {person.Address.StreetNo}");
        Console.Write("Nytt gatunummer (valfritt): \n");
        string streetNo = Console.ReadLine();

        contactDirectory.UpdateContact(indexToUpdate, firstName, lastName, phoneNo, streetName, streetNo);

        Console.WriteLine(person);
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine("Detta index existerar inte. Försök igen.");
        Console.Read();
    }
}

/*
 * Delete a contact -
 */
void DeleteContact()
{
    try
    {
        Console.WriteLine("Ange ett index på den kontakt som ska raderas:");
        int indexToDelete = Convert.ToInt32(Console.ReadLine());
        contactDirectory.DeleteContact(indexToDelete);
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Var snäll fyll i ett giltigt index.");
        Console.Read();
    }
}