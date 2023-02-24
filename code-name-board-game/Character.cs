using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace code_name_board_game
{
    public abstract class Character
    {
        public int x,y,speed;
        public string Name;
        
        public string[] itemList;

        public abstract int Move();
        public abstract void PickUoItem();
        public abstract void DropItem();

    }
}