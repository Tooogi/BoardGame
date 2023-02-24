using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text.Json;
using code_name_board_game.Controllers;
using Microsoft.Xna.Framework.Content;

namespace code_name_board_game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public SpriteFont font;
        public SpriteFont bleedingFont;
        public Player characterOne;
        public GameBoard _gameBoard;
        public CardController cardcontroller;
        public IList allrooms;
        public MouseState mouseState;
        private MouseState oldState;
        public KeyboardState keyboardState, previousKeyboardState;
        public int lastRoll;
        public int showInput = 1;
        public int temp;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public bool NewKey(Keys key)
        {
            return keyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // Make mouse visible
            IsMouseVisible = true;
            //Window size - full screen
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            // Get player data from external Json file
            IList playerList = (IList)ExternalData.LoadCharacters();
            if (playerList != null)
            {
                Debug.WriteLine("Player list available");
            };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            font = Content.Load<SpriteFont>("defaultFont");
            bleedingFont = Content.Load<SpriteFont>("bleeding");
            _gameBoard = new GameBoard(Content.Load<Texture2D>("game-board-background"));
            allrooms = _gameBoard.LoadBoardContent(Content);
            RoomsList.LoadRooms();
            /*  cardcontroller = new CardController(ExternalData.LoadOmenCards(), ExternalData.LoadItemCards(),
                  ExternalData.LoadEventCards()); */
            characterOne = new Player { Index = 1, Name = "Player One", x = 25, y = 25, cellList = ExternalData.LoadCellPositions(), speed = 5};
            GameController.CurrentPlayer = characterOne;
            lastRoll = 0;
            var httpcontroller = HttpController.TestApi();
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseState = Mouse.GetState();
            previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            // TODO: Add your update logic here

            foreach (Rooms rooms in allrooms)
            {
                rooms.Update(gameTime);
            }
            // checks for state of left click
            if (mouseState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                characterOne.MouseMove(GameController.PlayerPosition);
            }
            oldState = mouseState; // this reassigns the old state so that it is ready for next time

            if (NewKey(Keys.Space))
            {
               characterOne.Move();
               
            }
            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            // These 3 lines draw the text to the screen using the default font at position 0,0 with no colour tint.
            _spriteBatch.Begin();
            _gameBoard.Draw(_spriteBatch);
            //_spriteBatch.DrawString(font, characterOne.Name, new Vector2(characterOne.x, characterOne.y), Color.White);
            _spriteBatch.DrawString(bleedingFont, "Player 1 =" + characterOne.Name, new Vector2(10, 150), Color.DarkRed);
           _spriteBatch.DrawString(bleedingFont, "Player 1 =" + temp, new Vector2(10, 250), Color.DarkRed);
            if (allrooms != null)
            {
                foreach (Rooms gamerooms in allrooms)
                {
                    gamerooms.Draw(_spriteBatch);
                }
            }
            else
            {
                throw new InvalidOperationException("RoomList is Null - No rooms to draw");
            }

            _spriteBatch.Draw(Content.Load<Texture2D>("player-token-red"), new Vector2(characterOne.x, characterOne.y),
                Color.White);
            _spriteBatch.DrawString(bleedingFont, "Dice Roll = " +Dice.lastRoll.ToString(), new Vector2(800, 150),Color.Black);
            if (showInput == 1)
            { 
              _spriteBatch.DrawString(font, "current position = " +characterOne.CurrentPosition.ToString(), new Vector2(10, 200), Color.Black);
              _spriteBatch.DrawString(font, mouseState.ToString(), new Vector2(660, 850), Color.Black); 
              _spriteBatch.DrawString(font, keyboardState.ToString(), new Vector2(700, 830), Color.Black);
              _spriteBatch.Draw(_gameBoard.omencardtexture, new Rectangle(500, 50, 35, 70), Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
