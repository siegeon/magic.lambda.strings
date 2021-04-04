/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2021, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using magic.node.extensions;

namespace magic.lambda.strings.tests
{
    public class StartsWithTests
    {
        [Fact]
        public void StartsWith()
        {
            var lambda = Common.Evaluate(@"
.foo:foo-xxx
strings.starts-with:x:-
   .:foo
strings.starts-with:x:-/-
   .:xxx");
            Assert.True(lambda.Children.Skip(1).First().Get<bool>());
            Assert.False(lambda.Children.Skip(2).First().Get<bool>());
        }

        [Fact]
        public async Task StartsWithAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo:foo-xxx
strings.starts-with:x:-
   .:foo
strings.starts-with:x:-/-
   .:xxx");
            Assert.True(lambda.Children.Skip(1).First().Get<bool>());
            Assert.False(lambda.Children.Skip(2).First().Get<bool>());
        }

        [Fact]
        public void StartsWithThrows()
        {
            Assert.Throws<ArgumentException>(() => Common.Evaluate(@"
.foo:foo-xxx
strings.starts-with:x:-
"));
        }
    }
}
