﻿/*
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
    /// [strings.to-lower] slot that returns the lowercase value of its specified argument.
    /// </summary>
    [Slot(Name = "strings.to-lower")]
    public class ToLower : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            // Sanity checking.
            if (input.Children.Any())
                throw new ApplicationException("[strings.starts-with] must be given exactly one argument that contains value to look for");

            input.Value = input.GetEx<string>().ToLowerInvariant();
        }
    }
}
