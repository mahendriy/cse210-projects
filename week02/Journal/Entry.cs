class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public int _mood;

    public void Display()
    {
        string moodLabel = _mood switch
        {
            1 => "Terrible",
            2 => "Bad",
            3 => "Okay",
            4 => "Good",
            5 => "Great",
            _ => "Unknown"
        };

        Console.WriteLine($"Date: {_date} - Mood: {moodLabel} ({_mood}/5)");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }
}
