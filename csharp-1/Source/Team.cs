using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class Team
    {
        public List<Player> Players;

        public long id;

        public string name;

        public DateTime createDate;

        public string mainShirtColor;

        public string secondaryShirtColor;

        public long? captain;

        public Team(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            Players = new List<Player>();
            this.id = id;
            this.name = name;
            this.createDate = createDate;
            this.mainShirtColor = mainShirtColor;
            this.secondaryShirtColor = secondaryShirtColor;
        }
    }
}
