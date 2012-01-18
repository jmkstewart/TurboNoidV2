using Microsoft.Xna.Framework;
using TurboNoid.Managers;
using TurboNoid.DrawableObjects;
using Microsoft.Xna.Framework.Graphics;
using TurboNoid.CommunicationObjects;

namespace TurboNoid.Screens {
    public class GameScreen : IUpdatableScreen {
        private SpriteManager _spriteManager;
        private Background _background;
        private GameInfoOverlay _gameInfoOverlay;

        public IGameInfo GameInfo { get; set; }

        public void LoadContent(Game game, IGameInfo gameInfo) {
            GameInfo = gameInfo;
            _gameInfoOverlay = new GameInfoOverlay(game, GameInfo);
            _spriteManager = new SpriteManager(game, GameInfo);
            _spriteManager.LoadContent();
            _background = new Background(game);
        }

        public void Update(GameTime gameTime) {
            _spriteManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            _background.Draw(gameTime, spriteBatch);
            _spriteManager.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            _gameInfoOverlay.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        public void Restart() {
            _spriteManager.Restart();
        }
    }
}
