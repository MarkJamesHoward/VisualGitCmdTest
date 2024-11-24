using Xunit;

namespace Testing
{
    public class MyTests()
    {
        [Fact]
        public void MyTest()
        {
            string option = "test";

            Assert.Contains(option, "test");
        }

    }
}
