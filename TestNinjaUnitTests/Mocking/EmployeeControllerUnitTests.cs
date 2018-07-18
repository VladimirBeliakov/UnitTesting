using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinjaUnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerUnitTests
    {
        [Test]
        public void DeleteEmployee_ValidId_ReturnsActionResult()
        {
            // Arrange
            var stubEmpContext = FakeEmployeeContextFactory();
            stubEmpContext.Employees.Add(new Employee());
            var id = 1;

            EmployeeContextFactory.SetEmployeeContext(stubEmpContext);
            var empContr = new EmployeeController();

            // Act
            var result = empContr.DeleteEmployee(id);

            // Assert
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }

        private IEmployeeContext FakeEmployeeContextFactory()
        {
            var FakeEmployeeContext = Substitute.For<IEmployeeContext>();
            FakeEmployeeContext.Employees = Substitute.For<IDbSet<Employee>>();
            return FakeEmployeeContext;
        }
    }
}
