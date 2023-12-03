namespace G14_20230203
{
	internal sealed class Person
	{
		public Person(int id)
		{
			Id = id;
		}

		public Person(int id, string firstName, string lastName) : this(id)
		{
			FirstName = firstName;
			LastName = lastName;
		}

		public int Id { get; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public DateTime BirthDate { get; set; }
		public List<Person> Children { get; set; } = new List<Person>();

		public override bool Equals(object obj)
		{
			return this.GetHashCode().Equals(obj.GetHashCode());
		}

		public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
