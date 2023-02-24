using System;
using Microsoft.Xna.Framework.Graphics;

namespace code_name_board_game
{
    public class Card
    {
        public string name { get; set; }
        public string description { get; set; }
        public Texture2D symbol { get; set; }

        //Constructor commented out for the time being as to create a list out of a json array the object constructor must be parameter-less.

        //public  Card(string name, string description, Texture2D newTexture)
        //{
        //    _name = name;
        //    _description = description;
        //    _symbol = newTexture;

        //}
    }
}