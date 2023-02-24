using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text.Json.Serialization;
using code_name_board_game.Controllers;

namespace code_name_board_game
{
    public class Player : Character
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public string Sex { get; set; }
        public int Might { get; set; }
        public int Knowledge { get; set; }
        public int Sanity { get; set; }
        public int CurrentPosition { get; set; }
        public IList<Cell> cellList { get; set; }

        /// <summary>
        /// offstex & offsety are for the players token position in each cell/room. They are currently hardcoded but will be set dynamically for each
        /// player later, after a player list is created. More appropriate names should be used. CM
        /// </summary>
        public int offsetx = 25;
        public int offsety = 25;

        public override int Move()
        {
            int newPosition = Dice.RollDice(6);
            CurrentPosition += newPosition;
            if (CurrentPosition > 32)
            {
                CurrentPosition -= 30;
            }
            x = cellList[CurrentPosition].X + offsetx;
            y = cellList[CurrentPosition].Y + offsety;

            return CurrentPosition;
        }

        public int MouseMove(int newPosition)
        {
            if(newPosition <= CurrentPosition + GameController.CurrentPlayer.speed)

            CurrentPosition = newPosition;
            if (CurrentPosition > 32)
            {
                CurrentPosition -= 30;
            }
            x = cellList[CurrentPosition].X + offsetx;
            y = cellList[CurrentPosition].Y + offsety;
            return CurrentPosition;
        }

        public override void PickUoItem()
        {
            throw new NotImplementedException();
        }

        public override void DropItem()
        {
            throw new NotImplementedException();
        }
    }
}
