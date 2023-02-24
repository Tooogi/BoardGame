using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using System.IO;

namespace code_name_board_game
{
    public class GameBoard 
    {
        private Texture2D _texture;
        public Texture2D omencardtexture;

        public IList LoadBoardContent(ContentManager content)
        {
            omencardtexture = content.Load<Texture2D>("OmenCard");
            List<Rooms> RoomList = new List<Rooms>();

            int _width = 128;
            int _height = 128;

           // RoomList.Add("roomsId");

            RoomList.Add(new Rooms(content.Load<Texture2D>("Entrance"), new Rectangle(0, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Foyer"), new Rectangle(125, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Staircase"), new Rectangle(250, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Dining Room"), new Rectangle(375, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Kitchen"), new Rectangle(500, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Conference"), new Rectangle(625, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Game Room"), new Rectangle(750, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Crypt"), new Rectangle(875, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Stairs to Floor"), new Rectangle(1000, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("CreakyHallway"), new Rectangle(1125, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("CharredRoom"), new Rectangle(1250, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("JunkRoom"), new Rectangle(1375, 0, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Bedroom"), new Rectangle(1375, 125, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Ballroom"), new Rectangle(1375, 250, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Organ Room"), new Rectangle(1375, 375, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Poker Room"), new Rectangle(1375, 500, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("MysticElevator"), new Rectangle(1375, 625, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("ResearchLaboratory"), new Rectangle(1375, 750, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Bloody Room"), new Rectangle(1375, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("DustyHallway"), new Rectangle(1250, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("ServantsQuarters"), new Rectangle(1125, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Stairs from Floor"), new Rectangle(1000, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Collapsed Room"), new Rectangle(875, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Wine Cellar"), new Rectangle(750, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Graveyard"), new Rectangle(625, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("UndergroundLake"), new Rectangle(500, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("PentagramChamber"), new Rectangle(375, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Conservatory"), new Rectangle(250, 875, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Vault"), new Rectangle(250, 750, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Catacombs"), new Rectangle(250, 625, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Furnace Room"), new Rectangle(250, 500, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Chapel"), new Rectangle(250, 375, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Stairs from Cellar"), new Rectangle(250, 250, _width, _height)));
            RoomList.Add(new Rooms(content.Load<Texture2D>("Garden"), new Rectangle(250, 125, _width, _height)));

           

            int roomindex = 0;
            foreach (Rooms room in RoomList)
            {
                room.roomId = roomindex;
                roomindex++;
            }
                
            return RoomList;
        }

        public GameBoard(Texture2D boardTexture)
        {
            _texture = boardTexture;
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Vector2.Zero, Color.White);
            
        }
    }
}

