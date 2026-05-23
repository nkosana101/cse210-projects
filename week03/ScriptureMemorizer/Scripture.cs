using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            // Split text into words (preserve punctuation attached to words - good for memorization)
            string[] wordArray = text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            _words = wordArray.Select(w => new Word(w)).ToList();
        }

        public string GetDisplayText()
        {
            string wordsDisplay = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{_reference.GetDisplayText()}\n{wordsDisplay}";
        }

        /// <summary>
        /// Hides up to 'count' random words that are currently visible.
        /// Returns false if all words are already hidden, otherwise true.
        /// </summary>
        public bool HideRandomWords(int count)
        {
            // Get list of words that are not yet hidden
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
            if (visibleWords.Count == 0)
                return false; // everything is already hidden

            // Hide up to 'count' words, but not more than available
            Random random = new Random();
            int wordsToHide = Math.Min(count, visibleWords.Count);
            for (int i = 0; i < wordsToHide; i++)
            {
                // Pick a random visible word
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                // Remove it from the list so we don't hide the same word twice in this call
                visibleWords.RemoveAt(index);
            }
            return true;
        }
    }
}