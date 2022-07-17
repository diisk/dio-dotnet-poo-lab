using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_dotnet_poo_lab.Entities;
using dio_dotnet_poo_lab.Enums;

namespace dio_dotnet_poo_lab
{
    public class Program
    {

        static SeriesRepository repository = new SeriesRepository();
        public static void Main(string[] args)
        {
            string userOption;
            do
            {
                userOption = getUserOption();
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        AddNewSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        RemoveSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                }
            } while (userOption != "X");
        }

        private static void ListSeries()
        {
            Console.WriteLine("List series");

            List<Series> list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No series found in repository.");
                return;
            }

            foreach (Series series in list)
            {
                if(!series.isRemoved()){
                    Console.WriteLine($"ID: {series.getID()} Title: {series.getTitle()}");
                }
            }
        }

        private static Series getNewSeriesInstance(int id = -1)
        {
            foreach (int value in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{value}. {Enum.GetName(typeof(Genre), value)}");
            }
            Console.WriteLine("Choose the genre above:");
            int idGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter the description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the year:");
            int year = int.Parse(Console.ReadLine());


            return new Series(
                id == -1 ? repository.NextID() : id,
                (Genre)idGenre,
                title,
                description,
                year
            );
        }

        private static void AddNewSeries()
        {
            Console.WriteLine("Add new series");
            repository.Add(getNewSeriesInstance());
        }

        private static void UpdateSeries()
        {
            Console.WriteLine("Update series");

            Console.WriteLine("Enter series ID:");
            int id = int.Parse(Console.ReadLine());
            if (id < 0 || id >= repository.List().Count)
            {
                Console.WriteLine("Invalid ID!");
                return;
            }
            repository.Update(getNewSeriesInstance(id));
        }

        private static void RemoveSeries()
        {
            Console.WriteLine("Remove series");

            Console.WriteLine("Enter series ID:");
            int id = int.Parse(Console.ReadLine());
            if (id < 0 || id >= repository.List().Count)
            {
                Console.WriteLine("Invalid ID!");
                return;
            }
            repository.Remove(id);
        }

        private static void ViewSeries()
        {
            Console.WriteLine("View series");

            Console.WriteLine("Enter series ID:");
            int id = int.Parse(Console.ReadLine());

            Series series = repository.GetByID(id);

            if(series == null){
                Console.WriteLine("Invalid ID!");
                return;
            }
            Console.WriteLine(series);
        }

        public static string getUserOption()
        {
            Console.WriteLine($@"
            Select an option:
            1. List series
            2. Add new series
            3. Update series
            4. Remove series
            5. View series
            C. Clear screen
            X. Exit");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}