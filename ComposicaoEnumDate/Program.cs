using System;
using ComposicaoEnumDate.Entities;
using ComposicaoEnumDate.Entities.Enuns;
using System.Globalization;

namespace ComposicaoEnumDate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nom du département: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Entrez les données du travailleur");
            Console.Write("Nom: ");
            string name = Console.ReadLine();
            Console.WriteLine("Niveau (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salaire de base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("Combien des contrat pour le travailleur? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entrez les données du contrat #{i}");
                Console.Write("Date (YYYY-MM-DD): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valeur horaire: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (heurs): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Entrez le mois et l'anée pour calculer les gains (YYYY-MM): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(5));
            int year = int.Parse(monthAndYear.Substring(0, 4));
            Console.WriteLine("Nom: " + worker.Name);
            Console.WriteLine("Département: " + worker.Department.Name);
            Console.WriteLine("Gains en " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
