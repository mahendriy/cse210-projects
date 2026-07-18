using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in words)
        {
            _words.Add(new Word(wordText));
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.TrimEnd();
    }

    public void HideRandomWords(int numberToHide)
    {
        int visibleWordCount = GetVisibleWordCount();
        if (visibleWordCount == 0)
        {
            return;
        }

        int wordsToHide = Math.Min(numberToHide, visibleWordCount);

        for (int i = 0; i < wordsToHide; i++)
        {
            List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();
            if (visibleWords.Count == 0)
            {
                break;
            }

            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden);
    }

    private int GetVisibleWordCount()
    {
        return _words.Count(word => !word.IsHidden);
    }
}
