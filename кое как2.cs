using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static List<Note> notes = new List<Note>();
        static int currentMenuIndex = 0;

        static void Main(string[] args)
        {
            notes.Add(new Note("заметка 1 день", "\n сходить в мпт\n сделать практос\n сходить на вб", new DateTime(2023, 10, 24), new DateTime(2023, 10, 25)));
            notes.Add(new Note("заметка 2 день", "\n сдать практос\n сходить в магазин\n сабрать посылку", new DateTime(2023, 10, 25), new DateTime(2023, 10, 26)));
            notes.Add(new Note("заметка 3 день", "\n выспаться\n закинуть стирку\n выучить лекцию", new DateTime(2023, 10, 26), new DateTime(2023, 10, 27)));
            notes.Add(new Note("заметка 4 день", "\n проснуться\n сходить на пары\n лечь раньше спать", new DateTime(2023, 10, 27), new DateTime(2023, 10, 28)));
            notes.Add(new Note("заметка 5 день", "\n сходить в библиотеку\n сделать практос\n переписать лекцию", new DateTime(2023, 10, 28), new DateTime(2023, 10, 29)));

            Console.WriteLine("ежедневник");
            Console.WriteLine();  //stshk

            while (true)
            {
                ShowMenu();

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    ShowNoteDetails(currentMenuIndex);
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    ChangeDate(false);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    ChangeDate(true);
                }
            }
        }

        static void ShowMenu()
        {
            Console.Clear();

            var currentDate = notes[currentMenuIndex].Date;
            Console.WriteLine(currentDate.ToString("D"));
            Console.WriteLine();

            for (int i = 0; i < notes.Count; i++)
            {
                if (i == currentMenuIndex)
                {
                    Console.WriteLine("> " + notes[i].Title);
                }
                else
                {
                    Console.WriteLine("  " + notes[i].Title);  //stshk
                }
            }
        }

        static void ShowNoteDetails(int index)
        {
            Console.Clear();

            var note = notes[index];
            Console.WriteLine("3аметка: " + note.Title);
            Console.WriteLine("описание заметки: " + note.Description);
            Console.WriteLine("дата создания: " + note.Date.ToString("D"));
            Console.WriteLine("дата выполнения: " + note.DueDate.ToString("D"));

            Console.WriteLine();
            Console.WriteLine("нажмите любую клавишу для возвращения к меню");
            Console.ReadKey();
        }

        static void ChangeDate(bool isNext)
        {
            if (isNext)
            {
                currentMenuIndex++;
                if (currentMenuIndex >= notes.Count)
                {
                    currentMenuIndex = 0;
                }
            }
            else
            {
                currentMenuIndex--;
                if (currentMenuIndex < 0)
                {
                    currentMenuIndex = notes.Count - 1;
                }
            }
        }
    }

    class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }  //stshk
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public Note(string title, string description, DateTime date, DateTime dueDate)
        {
            Title = title;
            Description = description;
            Date = date;
            DueDate = dueDate;
        }
    }
}
