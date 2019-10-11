/*
 * Magic, Copyright(c) Thomas Hansen 2019, thomas@gaiasoul.com, all rights reserved.
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
    /// [strings.split] slot for splitting one string into multiple according to some string.
    /// </summary>
    [Slot(Name = "strings.split")]
    public class Split : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            // Sanity checking.
            if (!input.Children.Any())
                throw new ApplicationException("No arguments provided to [strings.split]");

            signaler.Signal("eval", input);

            // Figuring out which string to split, and upon what to split.
            var split = input.GetEx<string>();
            var splitOn = input.Children.First().GetEx<string>();

            // Returning the substituted strings to caller as nodes.
            input.Clear();
            input.AddRange(split
                .Split(new string[] { splitOn }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Node("", x)));
        }
    }
}
