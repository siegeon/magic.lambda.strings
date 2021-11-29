/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System.Linq;
using System.Threading.Tasks;
using Xunit;
using magic.node.extensions;

namespace magic.lambda.strings.tests
{
    public class EndsWithTests
    {
        [Fact]
        public void EndsWith()
        {
            var lambda = Common.Evaluate(@"
.foo:foo-xxx
strings.ends-with:x:-
   .:foo
strings.ends-with:x:-/-
   .:xxx");
            Assert.False(lambda.Children.Skip(1).First().Get<bool>());
            Assert.True(lambda.Children.Skip(2).First().Get<bool>());
        }

        [Fact]
        public async Task EndsWithAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo:foo-xxx
strings.ends-with:x:-
   .:foo
strings.ends-with:x:-/-
   .:xxx");
            Assert.False(lambda.Children.Skip(1).First().Get<bool>());
            Assert.True(lambda.Children.Skip(2).First().Get<bool>());
        }

        [Fact]
        public void EndsWithThrows()
        {
            Assert.Throws<HyperlambdaException>(() => Common.Evaluate(@"
.foo:foo-xxx
strings.ends-with:x:-
"));
        }
    }
}
