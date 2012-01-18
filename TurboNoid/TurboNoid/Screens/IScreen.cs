using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TurboNoid.CommunicationObjects;

namespace TurboNoid.Screens {
    interface IScreen {
        void LoadContent(Game game, IGameInfo gameInfo);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
