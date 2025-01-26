using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Server.Options;

namespace Vehicle.Server.UnitTests
{

    public class ApplicationOptionsTest
    {
        private readonly ApplicationOptions target;

        public ApplicationOptionsTest()
        {
            target = new ApplicationOptions();
        }

        [Theory]
        [InlineData("App1", "DEV")]
        [InlineData("App2", "ST")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void When_Create_new_Instance_Assign_Value_Should_return_CorrectValue(string applicationName, string environment)
        {
            target.ApplicationName = applicationName;
            target.Environment = environment;

            target.ApplicationName.Should().Be(applicationName);
            target.Environment.Should().Be(environment);
        }
    }
}
