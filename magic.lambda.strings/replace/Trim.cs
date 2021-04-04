﻿/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2021, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
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
    /// [strings.trim]/[strings.trim-start]/[strings.trim-end] slot for trimming a specified string,
    /// optionally passing in a string that defines which characters to trim away.
    /// </summary>
    [Slot(Name = "strings.trim")]
    [Slot(Name = "strings.trim-start")]
    [Slot(Name = "strings.trim-end")]
    public class Trim : ISlot, ISlotAsync
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
            TrimImplementation(input);
        }

        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        /// <returns>Awaitable task</returns>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            SanityCheck(input);
            await signaler.SignalAsync("eval", input);
            TrimImplementation(input);
        }

        #region [ -- Private helper methods -- ]

        static void SanityCheck(Node input)
        {
            if (input.Children.Count() > 1)
                throw new ArgumentException("[strings.trim] can handle at most one argument");
        }

        static void TrimImplementation(Node input)
        {
            var original = input.GetEx<string>();
            var what = input.Children.FirstOrDefault()?.GetEx<string>();
            switch(input.Name)
            {
                case "strings.trim-start":
                    if (string.IsNullOrEmpty(what))
                        input.Value = original.TrimStart();
                    else
                        input.Value = original.TrimStart(what.ToCharArray());
                    break;
                case "strings.trim-end":
                    if (string.IsNullOrEmpty(what))
                        input.Value = original.TrimEnd();
                    else
                        input.Value = original.TrimEnd(what.ToCharArray());
                    break;
                default:
                    if (string.IsNullOrEmpty(what))
                        input.Value = original.Trim();
                    else
                        input.Value = original.Trim(what.ToCharArray());
                    break;
            }
        }

        #endregion
    }
}
