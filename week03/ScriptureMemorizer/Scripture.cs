using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        Split the text into words 
        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _words = wordArray.Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
         Get indices of words that are not hidden
        var visibleIndices = _words
            .Select((word, index) => new { word, index })
            .Where(x => !x.word.IsHidden)
            .Select(x => x.index)
            .ToList();

         If there are no visible words, nothing to hide
        if (visibleIndices.Count == 0)
            return;

         Randomly pick up to 'count' distinct indices
        Random random = new Random();
        int wordsToHide = Math.Min(count, visibleIndices.Count);
        var indicesToHide = visibleIndices
            .OrderBy(x => random.Next())
            .Take(wordsToHide)
            .ToList();

        foreach (int idx in indicesToHide)
        {
            _words[idx].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.ToString();
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{referenceText}\n{wordsText}";
    }
}