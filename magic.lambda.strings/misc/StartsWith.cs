﻿/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.strings.misc
{
    /// <summary>
    /// [strings.starts-with] slot that returns true if the specified string starts with its value
    /// from its first argument.
    /// </summary>
    [Slot(Name = "strings.starts-with")]
    public class StartsWith : ISlot, ISlotAsync
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            SanityCheck(input);
            signaler.Signal("eval", input);
            input.Value = input.GetEx<string>()
                .StartsWith(input.Children.First().GetEx<string>(), StringComparison.InvariantCulture);
            input.Clear(); // House cleaning.
        }

        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise the signal.</param>
        /// <param name="input">Arguments to slot.</param>
        /// <returns>An awaitable task.</returns>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            SanityCheck(input);
            await signaler.SignalAsync("eval", input);
            input.Value = input.GetEx<string>()
                .StartsWith(input.Children.First().GetEx<string>(), StringComparison.InvariantCulture);
            input.Clear(); // House cleaning.
        }

        #region [ -- Private helper methods -- ]

        static void SanityCheck(Node input)
        {
            if (input.Children.Count() != 1)
                throw new HyperlambdaException("[strings.starts-with] must be given exactly one argument that contains value to look for");
        }

        #endregion
    }
}
