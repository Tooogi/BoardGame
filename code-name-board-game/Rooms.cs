using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using code_name_board_game.Controllers;

namespace code_name_board_game
{
    public class Rooms
    {
        #region fields


        public int roomId { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int tileSize { get; set; }

        public Texture2D _texture;
        public Rectangle _rectangle;


        public Rectangle mouseCollider;
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        private bool _isHovering;
        private bool _isSelected;

        #endregion
        #region Properties

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Rooms RoomsList { get; private set; }


        #endregion
        #region Methods

        public Rooms(Texture2D texture, Rectangle rectangle)
        {
            _texture = texture;
            _rectangle = rectangle;


        }

        //Rooms constructor for rooms.json
        public Rooms()
        {

    }

        public int CallRoomId(int rmid)
        {
            Debug.WriteLine(rmid);
            GameController.PlayerPosition = rmid;
            return rmid;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            var colour = Color.DarkGray;
            if (_isHovering)
            {
                colour = Color.White;
                if (mouseCollider.Intersects(_rectangle))
                {
                    _isHovering = true;
                }
            }

            if (_isSelected)
            {
                colour = Color.DarkRed;
            }
            _spriteBatch.Draw(_texture, _rectangle, colour);
        }

        public  void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

             mouseCollider = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            _isHovering = false;

            if (mouseCollider.Intersects(_rectangle))
            {
                _isHovering = true;
                // checks for state of left click
                if (_currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released)
                {
                    _isSelected = (_isSelected) ? false : true;
                    CallRoomId(roomId);

                }
                _previousMouse = _currentMouse; // this reassigns the old state so that it is ready for next time
            }


        }
        #endregion
    }
}