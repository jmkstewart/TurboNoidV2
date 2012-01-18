using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurboNoid.DrawableObjects {
    public class Background {
        Texture2D _backgroundTexture;

        public Background(Game game) {
            _backgroundTexture = game.Content.Load<Texture2D>(@"Sprites/frozen-lake");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(_backgroundTexture, Vector2.Zero, _backgroundTexture.Bounds, Color.White, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);
        }
    }
}
