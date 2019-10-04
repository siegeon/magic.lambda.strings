/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using System.Linq;
using System.Text.RegularExpressions;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.strings
{
    /// <summary>
    /// [regex-replace] slot that will perform a substitution of the regular expression
    /// matches from [what] with [with] found in your source string. [what] is expected
    /// to be a valid regular expression.
    /// </summary>
    [Slot(Name = "regex-replace")]
    public class RegexReplace : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var original = input.GetEx<string>();
            var what = input.Children.First(x => x.Name == "what").GetEx<string>();
            var with = input.Children.First(x => x.Name == "with").GetEx<string>();
            var ex = new Regex(what);
            input.Value = ex.Replace(original, with);
        }
    }
}
