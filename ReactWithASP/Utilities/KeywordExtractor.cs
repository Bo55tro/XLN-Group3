using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReactWithASP.Utilities
{
    public static class KeywordExtractor
    {
        private static readonly HashSet<string> CommonWords = new HashSet<string> {
            "is", "it", "the", "a", "an", "and", "or", "but", "to", "for", "of", "on", "in", "at", "with", "by", "as",
            "that", "this", "these", "those", "are", "was", "were", "be", "been", "has", "have", "had", "not", "so"
        };

        public static List<string> ExtractKeywords(string comments)
        {
            if (string.IsNullOrWhiteSpace(comments))
            {
                return new List<string> { "NoKeywords" }; // Returns default value for comments with no keywords to avoid empty errors
            }

            var words = Regex.Split(comments.ToLower(), @"\W+");

            var keywords = words
                .Where(word => !CommonWords.Contains(word) && word.Length > 2)
                .Distinct()
                .ToList();

            return keywords.Any() ? keywords : new List<string> { "NoKeywords" };
        }
    }
}