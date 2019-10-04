/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using System.Linq;
using Xunit;
using magic.node.extensions;

namespace magic.lambda.strings.tests
{
    public class StringTests
    {
        [Fact]
        public void Replace_01()
        {
            var lambda = Common.Evaluate(@"
.foo1:howdy world
replace:x:-
   what:world
   with:universe");
            Assert.Equal("howdy universe", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void Contains_01()
        {
            var lambda = Common.Evaluate(@"
.foo1:howdy world
contains:x:-
   .:world");
            Assert.Equal(true, lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void Contains_02()
        {
            var lambda = Common.Evaluate(@"
.foo1:howdy tjobing
contains:x:-
   .:world");
            Assert.Equal(false, lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void Concat_01()
        {
            var lambda = Common.Evaluate(@"
.foo:foo
concat
   get-value:x:@.foo
   .:' bar'");
            Assert.Equal("foo bar", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ToLowers()
        {
            var lambda = Common.Evaluate(@"
.foo:FOO
to-lower:x:-");
            Assert.Equal("foo", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void ToUpper()
        {
            var lambda = Common.Evaluate(@"
.foo:foo
to-upper:x:-");
            Assert.Equal("FOO", lambda.Children.Skip(1).First().Value);
        }

        [Fact]
        public void StartsWith()
        {
            var lambda = Common.Evaluate(@"
.foo:foo-xxx
starts-with:x:-
   :foo
starts-with:x:-/-
   :xxx");
            Assert.True(lambda.Children.Skip(1).First().Get<bool>());
            Assert.False(lambda.Children.Skip(2).First().Get<bool>());
        }

        [Fact]
        public void EndsWith()
        {
            var lambda = Common.Evaluate(@"
.foo:foo-xxx
ends-with:x:-
   :foo
ends-with:x:-/-
   :xxx");
            Assert.False(lambda.Children.Skip(1).First().Get<bool>());
            Assert.True(lambda.Children.Skip(2).First().Get<bool>());
        }

        [Fact]
        public void ReplaceRegEx()
        {
            var lambda = Common.Evaluate(@"
.foo:thomas han0123sen
regex-replace:x:-
   what:han[0-9]*sen
   with:cool hansen");
            Assert.Equal("thomas cool hansen", lambda.Children.Skip(1).First().Get<string>());
        }

        [Fact]
        public void Split()
        {
            var lambda = Common.Evaluate(@"
.foo:a b cde f
split:x:-
   .:' '");
            Assert.Equal(4, lambda.Children.Skip(1).First().Children.Count());
            Assert.Equal("a", lambda.Children.Skip(1).First().Children.First().Value);
            Assert.Equal("b", lambda.Children.Skip(1).First().Children.Skip(1).First().Value);
            Assert.Equal("cde", lambda.Children.Skip(1).First().Children.Skip(2).First().Value);
        }
    }
}
