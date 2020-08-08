using FluentAssertions;
using FluentAssertions.Execution;
using WebDriverWithCore3Tests.Models;

namespace WebDriverWithCore3Tests.Assertions
{
    public static class UserTestModelAssertion
    {
        public static void AssertFakeUserDetails(UserTestModel testUser) 
        {
            using (new AssertionScope())
            {
                testUser.Should().NotBeNull();
                testUser.LastName.Should().NotBeNullOrEmpty();
                testUser.FirstName.Should().NotBeNullOrEmpty();
                testUser.Email.Should().NotBeNullOrEmpty();
                testUser.Password.Should().NotBeNullOrEmpty();
            }
        }
    }
}
