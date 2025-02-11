/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System.Linq;
using Xunit;

namespace magic.lambda.strings.tests
{
    public class MiscStringTests
    {
        [Fact]
        public void Capitalize()
        {
            var lambda = Common.Evaluate(@"
.foo:foo
strings.capitalize:x:-");
            Assert.Equal("Foo", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ToLowers()
        {
            var lambda = Common.Evaluate(@"
.foo:FOO
strings.to-lower:x:-");
            Assert.Equal("foo", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ToUppers()
        {
            var lambda = Common.Evaluate(@"
.foo:foo
strings.to-upper:x:-");
            Assert.Equal("FOO", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void Length()
        {
            var lambda = Common.Evaluate(@"
.foo:foo
strings.length:x:-");
            Assert.Equal(3, lambda.Children.Skip(1).First().Value);
        }
    }
}
