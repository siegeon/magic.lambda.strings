
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

Magic is licensed as Affero GPL. This means that you can only use it to create Open Source solutions.
If this is a problem, you can contact at thomas@gaiasoul.com me to negotiate a proprietary license if
you want to use the framework to build closed source code. This will allow you to use Magic in closed
source projects, in addition to giving you access to Microsoft SQL Server adapters, to _"crudify"_
database tables in MS SQL Server. I also provide professional support for clients that buys a
proprietary enabling license.


