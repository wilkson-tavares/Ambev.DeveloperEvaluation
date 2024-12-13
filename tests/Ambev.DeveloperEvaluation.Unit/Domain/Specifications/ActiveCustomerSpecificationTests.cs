using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications
{
    public class ActiveCustomerSpecificationTests
    {
        [Fact]
        public void IsSatisfiedBy_ShouldValidateCustomerStatus()
        {
            // Arrange
            var customer = ActiveCustomerSpecificationTestData.GenerateCustomer();
            var specification = new ActiveCustomerSpecification();

            // Act
            var result = specification.IsSatisfiedBy(customer);

            // Assert
            result.Should().BeTrue();
        }
    }
}