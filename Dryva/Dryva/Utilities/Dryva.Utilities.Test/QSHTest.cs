using Dryva.Utitlties.Sql;
using NUnit.Framework;

namespace Dryva.Utilities.Test
{
    public class QSHTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var sql = QueryStatementHelper.Delete<Person>("People").Where(p => p.Id == 5);
            Assert.Pass();
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}