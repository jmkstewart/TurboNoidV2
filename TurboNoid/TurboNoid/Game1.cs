using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using TurboNoid.Managers;
using TurboNoid.Screens;
using TurboNoid.CommunicationObjects;

namespace TurboNoid {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        private enum ScreenState { Start, Game, Restart, Paused, Passed };

        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;

        private ScreenState _screenState = ScreenState.Start;
        private GameScreen _gameScreen;
        private StartScreen _startScreen;
        private RestartScreen _restartScreen;
        private PauseScreen _pausedScreen;
        private PassedScreen _passedScreen;

        private GameInfo _gameInfo;

        private bool _pPressedOnce = false;
        private bool _sPressedOnce = false;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            _gameScreen = new GameScreen();
            _startScreen = new StartScreen();
            _restartScreen = new RestartScreen();
            _pausedScreen = new PauseScreen();
            _passedScreen = new PassedScreen();
            _gameInfo = new GameInfo();
            _gameInfo.Level = 1;
            _gameInfo.Lives = 3;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameScreen.LoadContent(this, _gameInfo);
            _startScreen.LoadContent(this, _gameInfo);
            _restartScreen.LoadContent(this, _gameInfo);
            _pausedScreen.LoadContent(this, _gameInfo);
            _passedScreen.LoadContent(this, _gameInfo);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if(Keyboard.GetState().IsKeyDown(Keys.S)) {
                var s = "";
            }

            // determine the game screen
            if(_screenState == ScreenState.Start) {
                if(Keyboard.GetState().IsKeyDown(Keys.S) && !_sPressedOnce) {
                    _screenState = ScreenState.Game;
                    _sPressedOnce = true;
                }
            } else if(_screenState == ScreenState.Restart) {
                if(Keyboard.GetState().IsKeyDown(Keys.S) && !_sPressedOnce) {
                    _restartScreen.StopRestartScreen();
                    _screenState = ScreenState.Start;
                    _sPressedOnce = true;
                }
            } else if(_screenState == ScreenState.Game) {
                if(Keyboard.GetState().IsKeyDown(Keys.P) && !_pPressedOnce) {
                    _screenState = ScreenState.Paused;
                    _pPressedOnce = true;
                }
            } else if(_screenState == ScreenState.Paused) {
                if(Keyboard.GetState().IsKeyDown(Keys.P) && !_pPressedOnce) {
                    _screenState = ScreenState.Game;
                    _pPressedOnce = true;
                }
            } else if(_screenState == ScreenState.Passed) {
                if(Keyboard.GetState().IsKeyDown(Keys.S) && !_sPressedOnce) {
                    _screenState = ScreenState.Start;
                    _sPressedOnce = true;
                }
            }

            if(_pPressedOnce) {
                if(!Keyboard.GetState().IsKeyDown(Keys.P)) {
                    _pPressedOnce = false;
                }
            }
            if(_sPressedOnce) {
                if(!Keyboard.GetState().IsKeyDown(Keys.S)) {
                    _sPressedOnce = false;
                }
            }

            if(_screenState == ScreenState.Game) {
                if(_gameInfo.GameOver) {
                    _gameInfo.Level = 1;
                    _gameInfo.GameOver = false;
                    _gameInfo.Dead = false;
                    _gameInfo.Lives = 3;
                    _gameScreen.LoadContent(this, _gameInfo);
                    _screenState = ScreenState.Restart;
                    _restartScreen.ResetScreen();
                } else if(_gameInfo.Dead) {
                    _screenState = ScreenState.Start;
                    _gameScreen.Restart();
                    _gameInfo.Dead = false;
                } else if(_gameInfo.NextLevel) {
                    if(_gameInfo.Level == 4) {
                        _screenState = ScreenState.Passed;
                        _gameInfo.Level = 1;
                        _gameInfo.GameOver = false;
                        _gameInfo.Dead = false;
                        _gameInfo.Lives = 3;
                        _gameInfo.NextLevel = false;
                        _gameScreen.LoadContent(this, _gameInfo);
                    } else {
                        _gameInfo.NextLevel = false;
                        _gameScreen.LoadContent(this, _gameInfo);
                        _screenState = ScreenState.Start;
                    }
                } else {
                    _gameScreen.Update(gameTime);
                }
            } else if(_screenState == ScreenState.Restart) {
                _restartScreen.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            if(_screenState != ScreenState.Restart) {
                _gameScreen.Draw(gameTime, _spriteBatch);
            }

            if(_screenState == ScreenState.Start) {
                _startScreen.Draw(gameTime, _spriteBatch);
            }

            if(_screenState == ScreenState.Paused) {
                _pausedScreen.Draw(gameTime, _spriteBatch);
            }

            if(_screenState == ScreenState.Restart) {
                _restartScreen.Draw(gameTime, _spriteBatch);
            }

            if(_screenState == ScreenState.Passed) {
                _passedScreen.Draw(gameTime, _spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
