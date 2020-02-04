using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class Player
    {
        public string PlayerFullName { get; set; }
        public string Club { get; set; }
        public double ReleaseClause { get; set; }
        public DateTime BirthDate { get; set; }
        public double Wage { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }

        public Player(string playerFullName, string club, double releaseClause, DateTime birthDate, double wage, int age, string nationality)
        {
            PlayerFullName = playerFullName;
            Club = club;
            ReleaseClause = releaseClause;
            BirthDate = birthDate;
            Wage = wage;
            Age = age;
            Nationality = nationality;
        }
    }
}
