/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2020, thomas@servergardens.com, all rights reserved.
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
    /// [strings.join] slot for joining two or more strings with
    /// a separator character in between each string joined.
    /// </summary>
    [Slot(Name = "strings.join")]
    public class Join : ISlot, ISlotAsync
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
            input.Value = string.Join(
                input.Children.First(x => x.Name != "").GetEx<string>(),
                input.Evaluate().Select(x => x.GetEx<string>()).ToArray());

            // House cleaning.
            input.Clear();
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
            input.Value = string.Join(
                input.Children.First(x => x.Name != "").GetEx<string>(),
                input.Evaluate().Select(x => x.GetEx<string>()).ToArray());
        }

        #region [ -- Private helper methods -- ]

        static void SanityCheck(Node input)
        {
            if (input.Children.Count(x => x.Name.Length != 0) != 1)
                throw new ArgumentException("[strings.join] requires exactly one argument with a name.");
        }

        #endregion
    }
}
