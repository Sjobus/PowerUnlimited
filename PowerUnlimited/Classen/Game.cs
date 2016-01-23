using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerUnlimited.Classen
{
    public class Game
    {
        public int gameId;
        public string naam;
        public string uitgever;
        public string developer;
        public string platform;
        public double prijs;
        public string genre;
        public string tags { get; set; }

        public Game(int gameId, string naam, string uitgever, string developer, string platform, double prijs,
            string genre, string tags)
        {
            this.tags = tags;
        }
    }
}