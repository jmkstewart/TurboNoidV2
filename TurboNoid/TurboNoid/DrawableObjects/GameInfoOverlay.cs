using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TurboNoid.CommunicationObjects;

namespace TurboNoid.DrawableObjects {
    public class GameInfoOverlay {
        private SpriteFont _font;
        private Rectangle _windowRect;
        private IGameInfo _gameInfo;

        public GameInfoOverlay(Game game, IGameInfo gameInfo) {
            _gameInfo = gameInfo;
            _font = game.Content.Load<SpriteFont>("Fonts/GameFont");
            _windowRect = game.Window.ClientBounds;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            var livesText = "Mans: " + _gameInfo.Lives;
            var livesTextSize = _font.MeasureString(livesText);
            Vector2 livesTextPosition = new Vector2(_windowRect.Width - livesTextSize.X, 0);
            spriteBatch.DrawString(_font, livesText, livesTextPosition, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            var levelText = "Level: " + _gameInfo.Level;
            var levelTextSize = _font.MeasureString(levelText);
            Vector2 levelTextPosition = new Vector2(_windowRect.Width - levelTextSize.X, livesTextSize.Y);
            spriteBatch.DrawString(_font, levelText, levelTextPosition, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
    }
}
