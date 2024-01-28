using System;
using System.Collections.Generic;

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool IsCompleted { get; set; }

    public Note(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
        IsCompleted = false;
    }

    public override string ToString()
    {
        string status = IsCompleted ? "Выполнена" : "Ожидается";
        return $"Заметка \"{Title}\" ({status} до {Date.ToString("dd.MM.yyyy")})";
    }
}

class Program
{
    private static List<Note> notes = new List<Note>();

    static void Main()
    {
        InitializeNotes();

        int currentDateIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Дата: {notes[currentDateIndex].Date.ToString("dd.MM.yyyy")}\n");

            ShowMenu(notes[currentDateIndex]);

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentDateIndex = (currentDateIndex - 1 + notes.Count) % notes.Count;
                    break;
                case ConsoleKey.RightArrow:
                    currentDateIndex = (currentDateIndex + 1) % notes.Count;
                    break;
                case ConsoleKey.Enter:
                    ShowNoteDetails(notes[currentDateIndex]);
                    break;
                default:
                    break;
            }
        }
    }

    static void ShowMenu(Note note)
    {
        Console.WriteLine(note.Title);
    }

    static void ShowNoteDetails(Note note)
    {
        Console.Clear();
        Console.WriteLine($"Заголовок: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Дата: {note.Date.ToString("dd.MM.yyyy")}");
        Console.WriteLine($"Статус: {(note.IsCompleted ? "Выполнена" : "Ожидается")}");

        Console.WriteLine("\nНажмите Enter для продолжения...");
        Console.ReadLine();
    }

    static void InitializeNotes()
    {
        notes.Add(new Note("На шестое число", "\n1. Доделать практические. \n2. Выжить.", new DateTime(2024, 1, 6)));
        notes.Add(new Note("На седьмое", "\n1. Прийти к первой пре. \n2. Репетитор в 21:00", new DateTime(2024, 1, 7)));
        notes.Add(new Note("К восьмому", "\n1. Принять таблетки. \n2. Выключить свет \n3. Игнорировать их.", new DateTime(2024, 1, 8)));
        notes.Add(new Note("Девятого декабря", "\n1. Прийти на пары. \n2. Сделать ещё пару практических", new DateTime(2024, 1, 9)));
        notes.Add(new Note("Десятое декабря", "\n1.", new DateTime(2024, 1, 10)));
        notes.Add(new Note("Заметка 6", "Описание заметки 6", new DateTime(2024, 1, 11)));
        notes.Add(new Note("Заметка 7", "Описание заметки 7", new DateTime(2024, 1, 12)));
        notes.Add(new Note("Заметка 8", "Описание заметки 8", new DateTime(2024, 1, 13)));
        notes.Add(new Note("Заметка 9", "Описание заметки 9", new DateTime(2024, 1, 14)));
        notes.Add(new Note("Заметка 10", "Описание заметки 10", new DateTime(2024, 1, 15)));
    }
}
