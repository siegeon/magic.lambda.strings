/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2020, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace magic.lambda.strings.tests
{
    public class ContainsTests
    {
        [Fact]
        public void ContainsTrue()
        {
            var lambda = Common.Evaluate(@"
.foo1:howdy world
strings.contains:x:-
   .:world");
            Assert.Equal(true, lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ContainsFalse()
        {
            var lambda = Common.Evaluate(@"
.foo1:howdy tjobing
strings.contains:x:-
   .:world");
            Assert.Equal(false, lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public async Task ContainsAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo1:howdy world
wait.strings.contains:x:-
   .:world");
            Assert.Equal(true, lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ContainsThrows()
        {
            Assert.Throws<ArgumentException>(() => Common.Evaluate(@"
.foo1:howdy world
strings.contains:x:-
"));
        }
    }
}
