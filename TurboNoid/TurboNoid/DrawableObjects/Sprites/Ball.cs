using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurboNoid.DrawableObjects.Sprites {
    class Ball : AutomatedSprite {
        public Ball(Texture2D textureImage, Vector2 position)
            : base(textureImage, position, new Point(textureImage.Width, textureImage.Height), 1, new Vector2(10, -10)) { }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {
            if(position.X < 0) {
                position.X = 0;
                speed.X = speed.X * -1;
            }
            if(position.X + size.X > clientBounds.Width) {
                position.X = clientBounds.Width - size.X;
                speed.X = speed.X * -1;
            }

            if(position.Y < 0) {
                position.Y = 0;
                speed.Y = speed.Y * -1;
            }
            if(position.Y + size.Y > clientBounds.Height) {
                position.Y = clientBounds.Height - size.Y;
                speed.Y = speed.Y * -1;
            }

            //var time = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            //var speedOffset = time * 60;

            base.Update(gameTime, clientBounds);
            //position += direction * speedOffset;
        }

        public void ReverseXSpeed() {
            speed.X = speed.X * -1;
        }
        public void ReverseYSpeed() {
            speed.Y = speed.Y * -1;
        }

        public void MovePosition(Vector2 movement) {
            position = position + movement;
        }

        public bool HitBottom(Rectangle clientBounds) {
            if(position.Y + size.Y > clientBounds.Height) {
                return true;
            }

            return false;
        }
    }
}
