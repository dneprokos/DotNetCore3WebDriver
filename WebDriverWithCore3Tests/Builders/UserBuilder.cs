using Bogus;
using NLog;
using WebDriverWithCore3Tests.Models;
using WebDriverWithCore3Tests.TestData;

namespace WebDriverWithCore3Tests.Builders
{
    public class UserBuilder
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly UserTestModel newUser;

        /// <summary>
        /// Generates user with random email and password
        /// </summary>
        public UserBuilder()
        {
            this.newUser = GenerateRequiredUserData();
        }

        /// <summary>
        /// Generates user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public UserBuilder(string email, string password)
        {
            newUser.Email = email;
            newUser.Password = password;
        }

        /// <summary>
        /// Adds first name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public UserBuilder AddFirstName(string firstName) 
        {
            newUser.FirstName = firstName;
            return this;
        }

        /// <summary>
        /// Adds random first name
        /// </summary>
        /// <returns></returns>
        public UserBuilder AddFirstName()
        {
            newUser.FirstName = TestDataManager.FirstName;
            return this;
        }

        /// <summary>
        /// Adds last name
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public UserBuilder AddLastName(string lastName)
        {
            newUser.LastName = lastName;
            return this;
        }

        /// <summary>
        /// Adds random last name
        /// </summary>
        /// <returns></returns>
        public UserBuilder AddLastName()
        {
            newUser.LastName = TestDataManager.LastName;
            return this;
        }

        public UserTestModel Build() 
        {
            logger.Info("User was generated with:\n"
                + "FirstName:" + newUser.FirstName
                + "\nLastName:" + newUser.LastName
                + "\nEmail:" + newUser.Email
                + "\nPassword:" + newUser.Password);
            return newUser;
        } 

        private UserTestModel GenerateRequiredUserData()
        {
            UserTestModel userData = new Faker<UserTestModel>()
                .RuleFor(u => u.Email, TestDataManager.Email)
                .RuleFor(u => u.Password, TestDataManager.Password)
                .Generate();

            return userData;
        }
    }
}
