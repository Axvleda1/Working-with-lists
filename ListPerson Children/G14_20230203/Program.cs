namespace G14_20230203
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Person p1 = new(1, "Dato", "Vardoshvili");
            Person p2 = new(2, "Luka", "Vardoshvili");
            Person p3 = new(3, "Leri", "Vardoshvili");

            Person p4 = new(4, "Shalva", "Aspanidze");
            Person p5 = new(5, "Ana", "Aspanidze");
            Person p6 = new(6, "Nita", "Aspanidze");
            Person p7 = new(7, "Deme", "Aspanidze");
            Person p8 = new(7, "Lizi", "Aspanidze");
            Person p9 = new(9, "Anastasia", "Aspanidze");

            p1.Children.Add(p2);
            p1.Children.Add(p3);

            p4.Children.Add(p5);
            p4.Children.Add(p6);
            p4.Children.Add(p7);
            p5.Children.Add(p8);
            p8.Children.Add(p9);

            PersonList personList = new PersonList();
            personList.Add(p1);
            personList.Add(p4);
            var persons = personList.GetAllPersons();

			foreach (var person in persons)
			{
				Console.WriteLine($"{person.Id}, {person.FirstName}, {person.LastName}");
			}
		}
	}
}