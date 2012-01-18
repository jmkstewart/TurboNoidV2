using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using TurboNoid.DrawableObjects.Sprites;
using TurboNoid.CommunicationObjects;

namespace TurboNoid.Managers {
    class SpriteManager {
        private Player _player;
        private Ball _ball;
        private List<Block> blockList = new List<Block>();
        private IGameInfo _gameInfo;

        private SoundEffect _ballCollisionSoundEffect;

        protected Game _game;

        public SpriteManager(Game game, IGameInfo gameInfo) {
            _game = game;
            _gameInfo = gameInfo;
        }

        public void LoadContent() {
            Restart();

            //MapGenerator mapGenerator = new MapGenerator(@"./Content/Levels/Test/");
            MapGenerator mapGenerator = new MapGenerator(@"./Content/Levels/");
            blockList = mapGenerator.GetBlockList(_game, @"Map" + _gameInfo.Level + ".txt");

            _ballCollisionSoundEffect = _game.Content.Load<SoundEffect>(@"Sounds/Doink");
        }

        public void Restart() {
            Vector2 playerPosition = new Vector2((_game.Window.ClientBounds.Width / 2 ) - 70, _game.Window.ClientBounds.Height - 26);
            _gameInfo.Dead = false;

            _player = new Player(_game.Content.Load<Texture2D>(@"Sprites/Player"), playerPosition);
            _ball = new Ball(_game.Content.Load<Texture2D>(@"Sprites/Ball"), new Vector2(playerPosition.X - 50, playerPosition.Y - 50));
        }

        public void Update(GameTime gameTime) {
            if(_ball.HitBottom(_game.Window.ClientBounds)) {
                _gameInfo.Lives--;
                _gameInfo.Dead = true;
            }

            if(_gameInfo.Lives == 0) {
                _gameInfo.GameOver = true;
            }
            
            _player.Update(gameTime, _game.Window.ClientBounds);
            _ball.Update(gameTime, _game.Window.ClientBounds);

            if(_player.collisionRectangle.Intersects(_ball.collisionRectangle)) {
                Collision(_player.collisionRectangle, _ball);
            }

            var deleteBlockList = new List<Block>();

            foreach(Block block in blockList) {
                block.Update(gameTime, _game.Window.ClientBounds);

                if(block.collisionRectangle.Intersects(_ball.collisionRectangle)) {
                    Collision(block.collisionRectangle, _ball);

                    if(block.BlockColour == BlockColour.White) {
                        deleteBlockList.Add(block);
                    } else if(block.BlockColour == BlockColour.Blue) {
                        block.BlockColour = BlockColour.White;
                    } else if(block.BlockColour == BlockColour.Red) {
                        block.BlockColour = BlockColour.Blue;
                    }

                    _ballCollisionSoundEffect.Play();
                }
            }

            foreach(Block deleteBlock in deleteBlockList) {
                blockList.Remove(deleteBlock);
            }

            if(blockList.Count == 0) {
                _gameInfo.Level++;
                _gameInfo.NextLevel = true;
            }
        }

        private void Collision(Rectangle collisionRect, Ball ball) {
            int xOffset = 0;
            int yOffset = 0;

            // check direction the ball is from the rect in X
            int xDirection = ball.collisionRectangle.Center.X - collisionRect.Center.X;
            if(xDirection > 0) {
                // if the ball is right of the rect then what is the overlap
                xOffset = collisionRect.Right - ball.collisionRectangle.Left;
            } else {
                // if the ball is left of the rect then what is the overlap
                xOffset = ball.collisionRectangle.Right - collisionRect.Left;
            }

            // check direction the ball is from the rect in Y
            int yDirection = ball.collisionRectangle.Center.Y - collisionRect.Center.Y;
            if(yDirection > 0) {
                // if the ball is below the rect then what is the overlap
                yOffset = collisionRect.Bottom - ball.collisionRectangle.Top;
            } else {
                // if the ball is above the rect then what is the overlap
                yOffset = ball.collisionRectangle.Bottom - collisionRect.Top;
            }

            if(xDirection != 0) {
                xDirection = xDirection / Math.Abs(xDirection);
            }
            if(yDirection != 0) {
                yDirection = yDirection / Math.Abs(yDirection);
            }
            
            if(xOffset == yOffset) {
                ball.ReverseXSpeed();
                ball.ReverseYSpeed();
            } else if(xOffset > yOffset) {
                ball.MovePosition(new Vector2(0, yDirection * yOffset));
                ball.ReverseYSpeed();
            } else if(xOffset < yOffset) {
                ball.MovePosition(new Vector2(xDirection * xOffset, 0));
                ball.ReverseXSpeed();
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            _player.Draw(gameTime, spriteBatch);
            _ball.Draw(gameTime, spriteBatch);

            foreach(Block block in blockList) {
                block.Draw(gameTime, spriteBatch);
            }
        }
    }
}
