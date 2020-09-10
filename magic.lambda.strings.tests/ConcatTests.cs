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
    public class ConcatTests
    {
        [Fact]
        public void Concat()
        {
            var lambda = Common.Evaluate(@"
.foo:foo
strings.concat
   get-value:x:@.foo
   .:' bar'");
            Assert.Equal("foo bar", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public async Task ConcatAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo:foo
wait.strings.concat
   get-value:x:@.foo
   .:' bar'");
            Assert.Equal("foo bar", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ConcatThrows()
        {
            Assert.Throws<ArgumentException>(() => Common.Evaluate(@"
.foo:foo
strings.concat
"));
        }
    }
}
