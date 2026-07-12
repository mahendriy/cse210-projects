class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                string date = EscapeCsvField(entry._date);
                string prompt = EscapeCsvField(entry._promptText);
                string response = EscapeCsvField(entry._entryText);
                writer.WriteLine($"{date},{prompt},{response},{entry._mood}");
            }
        }
        Console.WriteLine("Journal saved successfully.\n");
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();

        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = ParseCsvLine(line);
                if (parts.Length >= 4)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._promptText = parts[1];
                    entry._entryText = parts[2];
                    entry._mood = int.Parse(parts[3]);
                    _entries.Add(entry);
                }
            }
        }
        Console.WriteLine("Journal loaded successfully.\n");
    }

    private string EscapeCsvField(string field)
    {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            return "\"" + field.Replace("\"", "\"\"") + "\"";
        }
        return field;
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        int i = 0;
        while (i < line.Length)
        {
            if (line[i] == '"')
            {
                i++;
                string field = "";
                while (i < line.Length)
                {
                    if (line[i] == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            field += "\"";
                            i += 2;
                        }
                        else
                        {
                            i++;
                            break;
                        }
                    }
                    else
                    {
                        field += line[i];
                        i++;
                    }
                }
                fields.Add(field);
                if (i < line.Length && line[i] == ',') i++;
            }
            else
            {
                string field = "";
                while (i < line.Length && line[i] != ',')
                {
                    field += line[i];
                    i++;
                }
                fields.Add(field);
                if (i < line.Length && line[i] == ',') i++;
            }
        }
        return fields.ToArray();
    }
}
