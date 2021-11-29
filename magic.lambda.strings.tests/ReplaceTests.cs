/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System.Linq;
using System.Threading.Tasks;
using Xunit;
using magic.node.extensions;

namespace magic.lambda.strings.tests
{
    public class ReplaceTests
    {
        [Fact]
        public void Replace()
        {
            var lambda = Common.Evaluate(@"
.foo1:howdy world
strings.replace:x:-
   .:world
   .:universe
");
            Assert.Equal("howdy universe", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public async Task ReplaceAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo1:howdy world
strings.replace:x:-
   .:world
   .:universe
");
            Assert.Equal("howdy universe", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ReplaceTooFewArgumentsThrows()
        {
            Assert.Throws<HyperlambdaException>(() => Common.Evaluate(@"
.foo1:howdy world
strings.replace:x:-
   .:world
"));
        }

        [Fact]
        public void ReplaceTooManyArgumentsThrows()
        {
            Assert.Throws<HyperlambdaException>(() => Common.Evaluate(@"
.foo1:howdy world
strings.replace:x:-
   .:world
   .:universe
   .:throws
"));
        }

        [Fact]
        public void ReplaceNotOf()
        {
            var lambda = Common.Evaluate(@"
.foo1:abcd123efg
strings.replace-not-of:x:-
   .:abcdefg
   .:XX
");
            Assert.Equal("abcdXXXXXXefg", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public async Task ReplaceNotOfAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo1:abcd123efg
strings.replace-not-of:x:-
   .:abcdefg
   .:XX
");
            Assert.Equal("abcdXXXXXXefg", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ReplaceNotOfThrows()
        {
            Assert.Throws<HyperlambdaException>(() => Common.Evaluate(@"
.foo1:abcd123efg
strings.replace-not-of:x:-
   .:abcdefg
"));
        }

        [Fact]
        public void ReplaceRegEx()
        {
            var lambda = Common.Evaluate(@"
.foo:thomas han0123sen
strings.regex-replace:x:-
   .:han[0-9]*sen
   .:cool hansen");
            Assert.Equal("thomas cool hansen", lambda.Children.Skip(1).First().Get<string>());
        }

        [Fact]
        public async Task ReplaceRegExAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo:thomas han0123sen
strings.regex-replace:x:-
   .:han[0-9]*sen
   .:cool hansen");
            Assert.Equal("thomas cool hansen", lambda.Children.Skip(1).First().Get<string>());
        }

        [Fact]
        public void ReplaceRegExThrows_01()
        {
            Assert.Throws<HyperlambdaException>(() => Common.Evaluate(@"
.foo:thomas han0123sen
strings.regex-replace:x:-
   .:han[0-9]*sen"));
        }

        [Fact]
        public void ReplaceRegExThrows_02()
        {
            Assert.Throws<HyperlambdaException>(() => Common.Evaluate(@"
.foo:thomas han0123sen
strings.regex-replace:x:-
   .:han[0-9]*sen
   .:cool hansen
   .:throws"));
        }
    }
}
