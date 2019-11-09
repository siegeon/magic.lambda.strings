/*
 * Magic, Copyright(c) Thomas Hansen 2019, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.strings
{
    /// <summary>
    /// [strings.replace] slot for replacing occurrencies of one string with another string. Pass in [what]
    /// being what to replace and [with] being its new value.
    /// </summary>
    [Slot(Name = "strings.replace")]
    public class Replace : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            // Sanity checking.
            if (input.Children.Count() != 2)
                throw new ArgumentException("[strings.regex-replace] requires exactly two arguments, the first being a regular expression of what to look for, the other beings its substitute");

            signaler.Signal("eval", input);

            var original = input.GetEx<string>();
            var what = input.Children.First().GetEx<string>();
            var with = input.Children.Skip(1).First().GetEx<string>();

            // Substituting.
            input.Value = original.Replace(what, with);
        }
    }
}
