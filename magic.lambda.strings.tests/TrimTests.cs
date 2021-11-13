/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace magic.lambda.strings.tests
{
    public class TrimTests
    {
        [Fact]
        public void Trim()
        {
            var lambda = Common.Evaluate(@"
.foo1:@""  howdy world    ""
strings.trim:x:-
");
            Assert.Equal("howdy world", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void TrimArgs()
        {
            var lambda = Common.Evaluate(@"
.foo1:@""XXX  howdy world    XXX""
strings.trim:x:-
   .:X
");
            Assert.Equal("  howdy world    ", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public async Task TrimAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo1:@""  howdy world    ""
strings.trim:x:-
");
            Assert.Equal("howdy world", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void TrimStart()
        {
            var lambda = Common.Evaluate(@"
.foo1:@""  howdy world    ""
strings.trim-start:x:-
");
            Assert.Equal("howdy world    ", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void TrimStartArgs()
        {
            var lambda = Common.Evaluate(@"
.foo1:@""XXX  howdy world    XXX""
strings.trim-start:x:-
   .:X
");
            Assert.Equal("  howdy world    XXX", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public async Task TrimStartAsyn()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo1:@""  howdy world    ""
strings.trim-start:x:-
");
            Assert.Equal("howdy world    ", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void TrimEnd()
        {
            var lambda = Common.Evaluate(@"
.foo1:@""  howdy world    ""
strings.trim-end:x:-
");
            Assert.Equal("  howdy world", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void TrimEndArgs()
        {
            var lambda = Common.Evaluate(@"
.foo1:@""123  howdy world    123""
strings.trim-end:x:-
   .:123
");
            Assert.Equal("123  howdy world    ", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public async Task TrimEndAsyn()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo1:@""  howdy world    ""
strings.trim-end:x:-
");
            Assert.Equal("  howdy world", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void TrimThrows()
        {
            Assert.Throws<ArgumentException>(() => Common.Evaluate(@"
.foo1:@""  howdy world    ""
strings.trim-end:x:-
   .:foo
   .:error
"));
        }

        [Fact]
        public async Task TrimThrowsAsyn()
        {
            await Assert.ThrowsAsync<ArgumentException>(async () => await Common.EvaluateAsync(@"
.foo1:@""  howdy world    ""
strings.trim-end:x:-
   .:foo
   .:error
"));
        }
    }
}
