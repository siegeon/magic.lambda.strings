﻿/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.strings.replace
{
    /// <summary>
    /// [strings.to-upper] slot that returns the uppercase value of its specified argument.
    /// </summary>
    [Slot(Name = "strings.to-upper")]
    public class ToUpper : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.Value = input.GetEx<string>().ToUpperInvariant();
        }
    }
}
