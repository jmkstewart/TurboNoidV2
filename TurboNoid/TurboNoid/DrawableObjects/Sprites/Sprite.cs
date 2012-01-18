using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurboNoid.DrawableObjects.Sprites {
    abstract class Sprite {
        protected Texture2D textureImage;
        private int collisionOffset;
        protected Vector2 speed;
        protected Vector2 position;
        protected Point size;

        public Sprite(Texture2D textureImage, Vector2 position, Point size, int collisionOffset, Vector2 speed) {
            this.textureImage = textureImage;
            this.position = position;
            this.size = size;
            this.collisionOffset = collisionOffset;
            this.speed = speed;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds) {
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureImage, position, GetCurrentSourceRectangle(), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public abstract Vector2 direction { get; }

        private Rectangle GetCurrentSourceRectangle() {
            return new Rectangle(0, 0, size.X, size.Y);
        }

        public Rectangle collisionRectangle {
            get {
                return new Rectangle(
                    (int)position.X + collisionOffset,
                    (int)position.Y + collisionOffset,
                    size.X - (2 * collisionOffset),
                    size.Y - (2 * collisionOffset));
            }
        }
    }
}
