/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using System;
using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.strings
{
    /// <summary>
    /// [ends-with] slot that returns true if the specified string ends with its value
    /// from its first argument.
    /// </summary>
    [Slot(Name = "ends-with")]
    public class EndsWith : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            if (input.Children.Count() != 1)
                throw new ApplicationException("[starts-with] must be given exactly one argument that contains value to look for");

            signaler.Signal("eval", input);

            input.Value = input.GetEx<string>()
                .EndsWith(input.Children.First().GetEx<string>(), StringComparison.InvariantCulture);
        }
    }
}
