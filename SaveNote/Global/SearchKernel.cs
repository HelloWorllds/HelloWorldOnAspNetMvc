using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SaveNote.Global
{
    public class SearchKernel<T> where T : class
    {
        public static IEnumerable<T> Search(string searchString, IQueryable<T> source)
        {
            var term = CleanContent(searchString.ToLowerInvariant().Trim(), false);

            var terms = term.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var regex = string.Format(CultureInfo.InvariantCulture, "({0})", string.Join("|", terms));

            foreach (var entry in source)
            {
                var rank = 0;

                if (!string.IsNullOrWhiteSpace(entry.ToString()))
                {
                    rank += Regex.Matches(entry.ToString().ToLowerInvariant(), regex).Count;
                }

                if (rank > 0)
                {
                    yield return entry;
                }
            }
        }

        private static readonly Regex RegexStripHTML = new Regex("<[^>]*>", RegexOptions.Compiled);

        private static string StripHTML(string html)
        {
            return string.IsNullOrWhiteSpace(html) ? string.Empty : RegexStripHTML.Replace(html, string.Empty).Trim();
        }

        private static string CleanContent(string content, bool removeHtml)
        {
            if (removeHtml)
            {
                content = StripHTML(content);
            }

            content = content.Replace("\\", string.Empty).
                            Replace("|", string.Empty).
                            Replace("(", string.Empty).
                            Replace(")", string.Empty).
                            Replace("[", string.Empty).
                            Replace("]", string.Empty).
                            Replace("*", string.Empty).
                            Replace("?", string.Empty).
                            Replace("}", string.Empty).
                            Replace("{", string.Empty).
                            Replace("^", string.Empty).
                            Replace("+", string.Empty);

            var words = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            var sb = new StringBuilder();

            foreach (var word in words.Select(t => t.ToLowerInvariant().Trim()).Where(word => word.Length > 1))
            {
                sb.AppendFormat("{0} ", word);
            }

            return sb.ToString();
        }
    }
}