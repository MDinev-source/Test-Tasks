namespace MovieStarTask1
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            DeserializeDataObjects();
        }

        private static void DeserializeDataObjects()
        {
            var jsonText = File.ReadAllText("./input.txt");
            var movieStars = JsonConvert.DeserializeObject<IList<MovieStar>>(jsonText);

            ObjectsIteration(movieStars);
        }

        private static void ObjectsIteration(IList<MovieStar> movieStars)
        {
            foreach (var mvStar in movieStars)
            {
                PrintData(mvStar);
            }
        }

        private static void PrintData(MovieStar mvStar)
        {
            var currentYear = DateTime.UtcNow.Year;
            var movieStarYearOfBirth = DateTime.Parse(mvStar.DateOfBirth).Year;
            var age = currentYear - movieStarYearOfBirth;

            var data = StringBuilding(mvStar, age);

            Console.WriteLine(data);
        }

        private static string StringBuilding(MovieStar mvStar, int age)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{mvStar.Name} {mvStar.Surname}");
            sb.AppendLine(mvStar.Sex);
            sb.AppendLine(mvStar.Nationality);
            sb.AppendLine($"{age} years old");
            sb.Append("\r");

            return sb.ToString();
        }
    }
}
