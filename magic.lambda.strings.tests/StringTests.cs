/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2020, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System.Linq;
using Xunit;
using magic.node.extensions;
using System.Threading.Tasks;
using System;

namespace magic.lambda.strings.tests
{
    public class StringTests
    {
        [Fact]
        public void Replace()
        {
            var lambda = Common.Evaluate(@"
.foo1:howdy world
strings.replace:x:-
   .:world
   .:universe");
            Assert.Equal("howdy universe", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ReplaceNotOf()
        {
            var lambda = Common.Evaluate(@"
.foo1:abcd123efg
strings.replace-not-of:x:-
   .:abcdefg
   .:XX");
            Assert.Equal("abcdXXXXXXefg", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public async Task ReplaceNotOfAsync()
        {
            var lambda = await Common.EvaluateAsync(@"
.foo1:abcd123efg
strings.replace-not-of:x:-
   .:abcdefg
   .:XX");
            Assert.Equal("abcdXXXXXXefg", lambda.Children.Skip(1).First().Value);
        }

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
wait.strings.trim:x:-
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
wait.strings.trim-start:x:-
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
wait.strings.trim-end:x:-
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
wait.strings.trim-end:x:-
   .:foo
   .:error
"));
        }

        [Fact]
        public void Contains_01()
        {
            var lambda = Common.Evaluate(@"
.foo1:howdy world
strings.contains:x:-
   .:world");
            Assert.Equal(true, lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void Contains_02()
        {
            var lambda = Common.Evaluate(@"
.foo1:howdy tjobing
strings.contains:x:-
   .:world");
            Assert.Equal(false, lambda.Children.Skip(1).First().Value);
        }

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
        public void ToUpper()
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
        public void Split()
        {
            var lambda = Common.Evaluate(@"
.foo:a b cde f
strings.split:x:-
   .:' '");
            Assert.Equal(4, lambda.Children.Skip(1).First().Children.Count());
            Assert.Equal("a", lambda.Children.Skip(1).First().Children.First().Value);
            Assert.Equal("b", lambda.Children.Skip(1).First().Children.Skip(1).First().Value);
            Assert.Equal("cde", lambda.Children.Skip(1).First().Children.Skip(2).First().Value);
        }

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
    }
}
