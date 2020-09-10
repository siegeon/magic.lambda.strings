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
    public class JoinTests
    {
        [Fact]
        public void Join()
        {
            var lambda = Common.Evaluate(@"
.foo
   .:a
   .:b
   .:c
strings.join:x:-/*
   .:'-'");
            Assert.Equal("a-b-c", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public async Task JoinAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo
   .:a
   .:b
   .:c
wait.strings.join:x:-/*
   .:'-x-'");
            Assert.Equal("a-x-b-x-c", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void JoinThrows()
        {
            Assert.Throws<ArgumentException>(() => Common.Evaluate(@"
.foo
   .:a
   .:b
   .:c
strings.join:x:-/*
"));
        }
    }
}
