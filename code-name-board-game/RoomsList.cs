using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace code_name_board_game
{
    public class RoomsList
    {

        private const string PATH = "rooms.json";

        public static IList<Rooms> LoadRooms()
        {

 
                var allRooms = File.ReadAllText(PATH);
                var roomsList = JsonSerializer.Deserialize<IList<Rooms>>(allRooms);

                
            Random rnd = new Random();

            var randomRooms = roomsList.OrderBy(x => rnd.Next());

            foreach (var rooms in randomRooms)
                {
                
                Debug.WriteLine("{0} - {1} - {2} - {3}", rooms.roomId.ToString(), rooms.name, rooms.symbol, rooms.tileSize.ToString());

                }

                return roomsList;


            /*  foreach (var rooms in roomsList)
              {
                  rooms.Draw(_spriteBatch);
              }
             */

        }
    }
    }
