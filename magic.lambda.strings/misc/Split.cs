/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2021, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
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
    /// [strings.split] slot for splitting one string into multiple
    /// strings according to some string.
    /// </summary>
    [Slot(Name = "strings.split")]
    public class Split : ISlot, ISlotAsync
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

            // Figuring out which string to split, and upon what to split.
            var split = input.GetEx<string>();
            var splitOn = input.Children.First().GetEx<string>();

            // Returning the substituted strings to caller as nodes.
            input.Clear();
            input.AddRange(split
                .Split(new string[] { splitOn }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Node("", x)));
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

            // Figuring out which string to split, and upon what to split.
            var split = input.GetEx<string>();
            var splitOn = input.Children.First().GetEx<string>();

            // Returning the substituted strings to caller as nodes.
            input.Clear();
            input.AddRange(split
                .Split(new string[] { splitOn }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Node("", x)));
        }

        #region [ -- Private helper methods -- ]

        static void SanityCheck(Node input)
        {
            if (!input.Children.Any())
                throw new ArgumentException("No arguments provided to [strings.split]");
        }

        #endregion
    }
}
