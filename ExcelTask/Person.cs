namespace ExcelTask
{
    internal class Person
    {
        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public Person(int age, string firstName, string lastName, string phone)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
