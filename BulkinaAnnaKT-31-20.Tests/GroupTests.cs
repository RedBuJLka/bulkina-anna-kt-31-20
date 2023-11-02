using BulkinaAnnaKT_31_20.Models;
using Xunit;

namespace BulkinaAnnaKT_31_20.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT3120_True()
        {
            var testGroup = new Group
            {
                GroupName = "��-31-20"
            };

            var result = testGroup.IsValidGroupName();

            Assert.True(result);
        }
    }
}