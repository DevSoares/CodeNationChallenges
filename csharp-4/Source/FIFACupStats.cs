using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace Codenation.Challenge
{
    public class FIFACupStats
    {
        public List<Player> Players { get; set; }
        public string CSVFilePath { get; set; } = "data.csv";

        public Encoding CSVEncoding { get; set; } = Encoding.UTF8;

        public int NationalityDistinctCount()
        {
            Players = ReadData();
            return Players.Where(p => p.Nationality != string.Empty).GroupBy(p => p.Nationality).Select(g => g.First()).Count();
        }

        public int ClubDistinctCount()
        {
            Players = ReadData();
            return Players.Where(p => p.Club != string.Empty).GroupBy(p => p.Club).Select(g => g.First()).Count();
        }

        public List<string> First20Players()
        {
            Players = ReadData();
            return Players.Select(p => p.PlayerFullName).Take(20).ToList();
        }

        public List<string> Top10PlayersByReleaseClause()
        {
            Players = ReadData();
            return Players.OrderByDescending(p => p.ReleaseClause).Select(p => p.PlayerFullName).Take(10).ToList();
        }

        public List<string> Top10PlayersByAge()
        {
            Players = ReadData();
            return Players.OrderBy(p => p.BirthDate).ThenBy(p => p.Wage).Select(p => p.PlayerFullName).Take(10).ToList();
        }

        public Dictionary<int, int> AgeCountMap()
        {
            Players = ReadData();
            var dictionary = new Dictionary<int, int>();
            var ages = Players.GroupBy(p => p.Age).Select(g => g.First()).Select(p => p.Age).ToList();

            for (int i = 0; i < ages.Count; i++)
            {
                dictionary.Add(ages[i], Players.Where(p => p.Age == ages[i]).ToList().Count());
            }

            return dictionary;
        }

        public List<Player> ReadData()
        {
            var playerList = new List<Player>();
            string lineRead;
            bool notFirst = false;

            using (StreamReader stream = new StreamReader(CSVFilePath, CSVEncoding))
            {
                while ((lineRead = stream.ReadLine()) != null)
                {
                    if (notFirst)
                        playerList.Add(InstantiatePlayer(lineRead));
                    else
                        notFirst = true;
                }
            }

            return playerList;
        }

        public Player InstantiatePlayer(string data)
        {
            double releaseClause = 0;
            double wage = 0;

            string[] splittedLine;
            splittedLine = data.Split(',');

            if (!string.IsNullOrEmpty(splittedLine[18]))
                releaseClause = double.Parse(splittedLine[18], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(splittedLine[17]))
                wage = double.Parse(splittedLine[17], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);

            return new Player(splittedLine[2], splittedLine[3], releaseClause, DateTime.Parse(splittedLine[8]), wage, int.Parse(splittedLine[6]), splittedLine[14]);
        }        
    }
}
