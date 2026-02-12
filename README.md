# Cinema Management & Loyalty System (C#)

This C# application provides a full-featured console interface for managing cinema operations. It allows users to browse movie schedules, purchase tickets, and track frequent viewers using advanced data manipulation techniques.

###  Logic & Data Analysis
The system leverages the power of **LINQ (Language Integrated Query)** to perform complex data grouping and sorting.

**Key Algorithmic Concepts:**
* **Data Grouping:** Uses `.GroupBy(v => v.Name)` to aggregate purchase history for individual customers.
* **Analytics:** Calculates customer loyalty rankings by counting entries and sorting them in descending order using `.OrderByDescending()`.
* **Relational Mapping:** Connects `Viewer` records with `Movie` and `Session` objects to ensure data consistency across the system.



###  Key Features
* **Interactive Scheduling:** Displays a structured timetable of movies with detailed session info (times and prices).
* **Transaction Logic:** Simulates a ticket purchasing flow, linking user input to specific movie sessions.
* **Loyalty Ranking:** Generates a "top customers" report, showing who bought the most tickets and which movies they watched.
* **Persistence Layer:** Automatically saves and loads viewer data from `viewers.txt` to maintain history between application runs. 
* **Modern .NET Core:** Built on **.NET 8.0**, utilizing top-level statements and modern C# syntax.

###  Technical Stack
* **Language:** C# (.NET 8.0)
* **Library:** `System.Linq` for data processing.
* **Concepts:** Encapsulation, File I/O, Grouping/Sorting, Collections (`List<T>`).

###  How to Use
1. Run the program through Visual Studio or the .NET CLI.
2. Select "1" to view the current movie schedule.
3. Select "2" to purchase a ticket for a specific session.
4. Select "3" to view the ranking of your most loyal customers based on their history.
