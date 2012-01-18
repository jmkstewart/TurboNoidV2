using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TurboNoid.CommunicationObjects;
using System.Collections.Generic;

namespace TurboNoid.Screens {
    class StartScreen : MessageScreenBase, IScreen {
        private Texture2D _startScreen;

        public override void LoadContent(Game game, IGameInfo gameInfo) {
            base.LoadContent(game, gameInfo);

            _startScreen = game.Content.Load<Texture2D>(@"Screens/StartScreen");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Draw(_startScreen, _position, _startScreen.Bounds, _transparencyColour, 0, Vector2.Zero, SpriteEffects.None, 1);

            var textLines = new List<string>() {
                "Level " + _gameInfo.Level + " !", "", "Press S to start!"
            };
            DrawCenteredTextLines(spriteBatch, textLines);
            
            spriteBatch.End();
        }
    }
}
