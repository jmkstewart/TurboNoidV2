using Microsoft.Xna.Framework;

namespace TurboNoid.Screens {
    interface IUpdatableScreen : IScreen {
        void Update(GameTime gameTime);
    }
}
