/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace magic.lambda.strings.tests
{
    public class SplitTests
    {
        [Fact]
        public void Split()
        {
            var lambda = Common.Evaluate(@"
.foo:a b cde f
strings.split:x:-
   .:' '
");
            Assert.Equal(4, lambda.Children.Skip(1).First().Children.Count());
            Assert.Equal("a", lambda.Children.Skip(1).First().Children.First().Value);
            Assert.Equal("b", lambda.Children.Skip(1).First().Children.Skip(1).First().Value);
            Assert.Equal("cde", lambda.Children.Skip(1).First().Children.Skip(2).First().Value);
        }

        [Fact]
        public async Task SplitAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo:a b cde f
strings.split:x:-
   .:' '
");
            Assert.Equal(4, lambda.Children.Skip(1).First().Children.Count());
            Assert.Equal("a", lambda.Children.Skip(1).First().Children.First().Value);
            Assert.Equal("b", lambda.Children.Skip(1).First().Children.Skip(1).First().Value);
            Assert.Equal("cde", lambda.Children.Skip(1).First().Children.Skip(2).First().Value);
        }

        [Fact]
        public void SplitThrows()
        {
            Assert.Throws<ArgumentException>(() => Common.Evaluate(@"
.foo:a b cde f
strings.split:x:-
"));
        }
    }
}
