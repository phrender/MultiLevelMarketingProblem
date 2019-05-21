using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM
{
    class Program
    {
        static void Main(string[] args)
        {
            int runs = 0;
            // Grid Area
            Grid grid = new Grid(10, 10);
            // List of people
            List<Person> persons = new List<Person>();
            // List to hold indexes of the new salesmen
            List<int> newSalesmen = new List<int>();
            // How many hours have passed.
            int hours = 0;
            // How many sales people do we have.
            int counter = 0;
            // First run checker
            bool isFirstRun = true;


            Console.Write("How many runs: ");
            runs = Console.Read();

            if (runs <= 0)
            {
                Console.WriteLine("Defaulting to 5 runs.");
                runs = 5;
            }

            // Setup persons using the grid.
            for (int x = 0; x < grid.SizeX; x++)
            {
                for (int y = 0; y < grid.SizeY; y++)
                {
                    persons.Add(new Person(x, y));
                }
            }

            // Initial salesman
            persons.Insert(0, new Person(0, 0, true));

            
            // We'll run the simulation 5 times.
            for (int runIdx = 0; runIdx < runs; runIdx++)
            {

                while (counter != persons.Count - 1 || hours == int.MaxValue / 10)
                {
                    if (newSalesmen.Count >= 1)
                    {
                        foreach (int i in newSalesmen)
                        {
                            persons[i].IsSalesman = true;
                        }
                        newSalesmen.Clear();
                    }

                    if (isFirstRun)
                    {
                        for (int idx = 0; idx < persons.Count; idx++)
                        {
                            if (idx + 1 < persons.Count - 1 &&
                                persons[idx].GetPositionX() == persons[idx + 1].GetPositionX() &&
                                persons[idx].GetPositionY() == persons[idx + 1].GetPositionY())
                            {
                                persons[idx + 1].IsSalesman = true;
                                break;
                            }
                        }
                        isFirstRun = false;
                        continue;
                    }

                    foreach (Person person in persons)
                    {
                        if (!person.IsSalesman)
                        {
                            // Quick escape to next person in the list.
                            continue;
                        }

                        person.MoveSalesman(grid);

                        // Check the new space for a unemployed person.
                        for (int i = 0; i < persons.Count; i++)
                        {
                            Person unemployed = persons[i];
                            if (unemployed.GetPositionX() == person.GetPositionX() &&
                                unemployed.GetPositionY() == person.GetPositionY() &&
                                !unemployed.IsSalesman)
                            {
                                newSalesmen.Add(persons.IndexOf(unemployed));
                                break;
                            }
                        }
                    }

                    counter = persons.Count(person => person.IsSalesman == true);
                    hours++;
                }

                Console.WriteLine("Run {0} completed in {1} hours!", runIdx, hours);
            }
        }
    }
}
