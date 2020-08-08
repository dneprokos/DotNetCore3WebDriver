using Bogus;

namespace WebDriverWithCore3Tests.TestData
{
    public class TestDataManager
    {
        private static readonly Faker faker = new Faker();

        public static string LastName => faker.Person.LastName;
        public static string FirstName => faker.Person.FirstName;
        public static string Email => faker.Internet.Email(FirstName, LastName);
        public static string Password => faker.Random.String(10, 15, 'A', 'z');
    }
}
