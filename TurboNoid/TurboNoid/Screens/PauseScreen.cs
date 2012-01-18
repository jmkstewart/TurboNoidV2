using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TurboNoid.CommunicationObjects;

namespace TurboNoid.Screens {
    class PauseScreen : MessageScreenBase, IScreen {
        private Texture2D _startScreen;

        public override void LoadContent(Game game, IGameInfo gameInfo) {
            base.LoadContent(game, gameInfo);
            
            _startScreen = _game.Content.Load<Texture2D>(@"Screens/StartScreen");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Draw(_startScreen, _position, _startScreen.Bounds, _transparencyColour, 0, Vector2.Zero, SpriteEffects.None, 1);

            var text = "Paused";
            spriteBatch.DrawString(_font, text, GetCenteredTextPosition(text), _transparencyColour, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            spriteBatch.End();
        }
    }
}
