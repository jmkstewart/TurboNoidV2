using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TurboNoid.CommunicationObjects;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace TurboNoid.Screens {
    public class RestartScreen : MessageScreenBase, IScreen {
        private List<Texture2D> _frames;
        private int _currentFrame = 0;
        private int _frameChangeTime = 60;
        private int _lastFrameChange = 60;

        private Song _restartSound;
        private bool _soundStarted = false;

        public override void LoadContent(Game game, IGameInfo gameInfo) {
            base.LoadContent(game, gameInfo);

            _frames = new List<Texture2D>();
            _frames.Add(game.Content.Load<Texture2D>(@"Screens/SkullGuy1"));
            _frames.Add(game.Content.Load<Texture2D>(@"Screens/SkullGuy2"));

            _restartSound = game.Content.Load<Song>("Sounds/ID4 Virus");
        }

        public void ResetScreen() {
            _soundStarted = false;
        }

        public void Update(GameTime gameTime) {
            if(_lastFrameChange > _frameChangeTime) {
                _currentFrame = _currentFrame == 1 ? 0 : 1;
                _lastFrameChange = 0;
            } else {
                _lastFrameChange += gameTime.ElapsedGameTime.Milliseconds;
            }

            if(!_soundStarted) {
                try {
                    MediaPlayer.Play(_restartSound);
                } catch { }
                _soundStarted = true;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Draw(_frames[_currentFrame], _position, _frames[_currentFrame].Bounds, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);

            var textLines = new List<string>() {
                "", "", "", "", "", "", "", "", "", "", "", "", 
                "Press S to re-start!"
            };
            DrawCenteredTextLines(spriteBatch, textLines);

            spriteBatch.End();
        }

        public void StopRestartScreen() {
            MediaPlayer.Stop();
        }
    }
}
