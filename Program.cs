using System;
using System.Collections.Generic;
using System.Linq;

// Модель даних для глядача
class Viewer
{
    public string Name { get; set; } = string.Empty;
    public string MovieTitle { get; set; } = string.Empty;
}

// Модель даних для фільму
class Movie
{
    public string Title { get; set; } = string.Empty;
}

// Модель даних для сеансу
class Session
{
    public Movie Movie { get; set; } = new Movie();
    public string Time { get; set; } = string.Empty;
    public double Price { get; set; }
}

// Основний клас керування кінотеатром
class Cinema
{
    private List<Session> sessions = new List<Session>();
    private List<Viewer> viewers = new List<Viewer>();

    public Cinema()
    {
        // Ініціалізація розкладу
        sessions.Add(new Session { Movie = new Movie { Title = "Inception" }, Time = "12:00", Price = 150 });
        sessions.Add(new Session { Movie = new Movie { Title = "The Dark Knight" }, Time = "15:00", Price = 180 });
        sessions.Add(new Session { Movie = new Movie { Title = "Interstellar" }, Time = "18:00", Price = 200 });
    }

    public void ShowSchedule()
    {
        Console.WriteLine("\n--- Розклад сеансiв ---");
        for (int i = 0; i < sessions.Count; i++)
        {
            var s = sessions[i];
            Console.WriteLine($"{i + 1}. {s.Movie.Title} | Час: {s.Time} | Цiна: {s.Price} грн");
        }
    }

    public void BuyTicket()
    {
        ShowSchedule();
        Console.Write("Оберiть номер сеансу: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= sessions.Count)
        {
            var session = sessions[index - 1];
            Console.Write("Ваше iм'я: ");
            string name = Console.ReadLine() ?? "Глядач";
            viewers.Add(new Viewer { Name = name, MovieTitle = session.Movie.Title });
            Console.WriteLine("Квиток куплено успішно!");
        }
        else
        {
            Console.WriteLine("Некоректний вибiр.");
        }
    }

    public void ShowLoyalCustomers()
    {
        if (!viewers.Any())
        {
            Console.WriteLine("Глядачiв ще немає.");
            return;
        }

        Console.WriteLine("\n--- Рейтинг постiйних глядачiв ---");
        var rating = viewers.GroupBy(v => v.Name)
                            .Select(g => new { Name = g.Key, Count = g.Count(), Movies = string.Join(", ", g.Select(v => v.MovieTitle)) })
                            .OrderByDescending(x => x.Count);

        foreach (var item in rating)
        {
            Console.WriteLine($"{item.Name}: {item.Count} квиткiв (Фiльми: {item.Movies})");
        }
    }

    public void SaveData()
    {
        try
        {
            System.IO.File.WriteAllLines("viewers.txt", viewers.Select(v => $"{v.Name}|{v.MovieTitle}"));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка збереження: {ex.Message}");
        }
    }

    public void LoadData()
    {
        if (System.IO.File.Exists("viewers.txt"))
        {
            try
            {
                var lines = System.IO.File.ReadAllLines("viewers.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                        viewers.Add(new Viewer { Name = parts[0], MovieTitle = parts[1] });
                }
            }
            catch { }
        }
    }
}

class Program
{
    static void Main()
    {
        Cinema cinema = new Cinema();
        cinema.LoadData();
        
        int choice;
        do
        {
            Console.WriteLine("\n=== КIНОТЕАТР ===");
            Console.WriteLine("1. Розклад\n2. Купити квиток\n3. Рейтинг\n4. Вийти");
            Console.Write("Вибiр: ");
            if (!int.TryParse(Console.ReadLine(), out choice)) continue;

            switch (choice)
            {
                case 1: cinema.ShowSchedule(); break;
                case 2: cinema.BuyTicket(); break;
                case 3: cinema.ShowLoyalCustomers(); break;
                case 4: cinema.SaveData(); break;
            }
        } while (choice != 4);
    }
}
