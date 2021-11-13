/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.strings.replace
{
    /// <summary>
    /// [strings.concat] slot for concatenating two or more strings together to become one.
    /// </summary>
    [Slot(Name = "strings.substring")]
    public class Substring : ISlot, ISlotAsync
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
            var start = input.Children.First().GetEx<int>();
            var end = input.Children.Skip(1)?.FirstOrDefault()?.GetEx<int>() ?? -1;
            if (end == -1)
                input.Value = input.GetEx<string>().Substring(start);
            else
                input.Value = input.GetEx<string>().Substring(start, end);
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
            var start = input.Children.First().GetEx<int>();
            var end = input.Children.Skip(1)?.FirstOrDefault()?.GetEx<int>() ?? -1;
            if (end == -1)
                input.Value = input.GetEx<string>().Substring(start);
            else
                input.Value = input.GetEx<string>().Substring(start, end);
            input.Clear();
        }

        #region [ -- Private helper methods -- ]

        static void SanityCheck(Node input)
        {
            if (!input.Children.Any())
                throw new ArgumentException("[strings.substring] requires one or two arguments");
        }

        #endregion
    }
}
