
# Magic Lambda Strings

[![Build status](https://travis-ci.org/polterguy/magic.lambda.strings.svg?master)](https://travis-ci.org/polterguy/magic.lambda.strings)

String manipulation library for [Magic](https://github.com/polterguy/magic). More specifically, it gives you the following slots.

* __[strings.concat]__ - Concatenates two or more strings.
* __[strings.contains]__ - Returns true if specified string contains the given argument.
* __[strings.ends-with]__ - Returns true if the specified string ends with the specified argument.
* __[strings.length]__ - Returns the length in characters of the given string.
* __[strings.regex-replace]__ - Replaces occurrencies matching the given regular expression with its argument.
* __[strings.replace]__ - Replaces occurrencies of the specified argument with the value of its specified argument.
* __[strings.split]__ - Splits a string into multiple strings on every match of its given argument
* __[strings.starts-with]__ - Returns true if the specified string starts with its argument.
* __[strings.to-lower]__ - Returns the lower caps version of its given argument
* __[strings.to-upper]__ - Returns the upper caps version of its specified argument.

## Usage

All the above slots that requires two arguments, will use the first argument as its _"what"_ argument, and the second
as its _"with"_ argument. Avoiding naming these though, allows you to reference other slots, and use these as sources
to parametrize your invocations to the above slots. For instance.

```
/*
 * This will replace "hansen" with "tjobing hansen".
 */
.foo:thomas hansen
replace:x:-
   :hansen
   :tjobing hansen
```

Basically, the first argument is _"what to look for"_, and the second argument is _"what to substitute it with"_.

## License

Although most of Magic's source code is publicly available, Magic is _not_ Open Source or Free Software.
You have to obtain a valid license key to install it in production, and I normally charge a fee for such a
key. You can [obtain a license key here](https://gaiasoul.com/license-magic/).
Notice, 5 hours after you put Magic into production, it will stop functioning, unless you have a valid
license for it.

* [Get licensed](https://gaiasoul.com/license-magic/)
