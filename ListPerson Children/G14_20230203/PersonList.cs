using System.Data;

namespace G14_20230203
{
    internal sealed class PersonList : List<Person>
    {
        public new Person this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                if (!base[index].Equals(value) && this.Contains(value))
                    throw new Exception($"Id already exists");
                base[index] = value;
            }
        }

        public new void Insert(int index, Person item)
        {
            if (this.Contains(item))
            {
                throw new Exception($"Id {item.Id} already exists");
            }

            base.Insert(index, item);
        }

        public new void Add(Person item)
        {
            foreach (var person in this)
            {
                if (person.Id == item.Id) throw new Exception($"Id {person.Id} already exists");
            }

            base.Add(item);
        }

        public new void AddRange(IEnumerable<Person> list)
        {
            Print(list);
            foreach (var person in list)
            {
                if (this.Contains(person))
                {
                    throw new Exception("Message");
                }
            }

            base.AddRange(list);
        }

        public new void InsertRange(int index, IEnumerable<Person> list)
        {
            foreach (var person in list)
            {
                if (this.Contains(person)) throw new Exception($"Id {person.Id} already exists");
            }

            base.InsertRange(index, list);
        }

        public void Print(IEnumerable<Person> persons)
        {

            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Id}.{person.FirstName} {person.LastName} ");

                Print(person.Children);

            }
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return GetAllPersons(this, new HashSet<Person>());
        }

        private static IEnumerable<Person> GetAllPersons(IEnumerable<Person> list, ICollection<Person> result)
        {
            foreach (var person in list)
            {
                if (result.Contains(person))
                {
                    throw new Exception($"Id {person.Id} already exists");
                }
                result.Add(person);
                GetAllPersons(person.Children, result);
            }

            return result;
        }

        public void Load(string filePath)
        {
            this.Clear();
            BinaryReader reader = new(new FileStream(filePath, FileMode.Open));
            try
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Person person = new(reader.ReadInt32(),
                                        reader.ReadString(),
                                        reader.ReadString());
                    this.Add(person);
                }
            }
            finally
            {
                reader.Close();
            }
        }

        public void Save(string filePath)
        {
            BinaryWriter writer = new(new FileStream(filePath, FileMode.Create));
            try
            {
                foreach (var person in this)
                {
                    writer.Write(person.Id);
                    writer.Write(person.FirstName);
                    writer.Write(person.LastName);
                }
            }
            finally
            {
                writer.Close();
            }
        }
    }
}