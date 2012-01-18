using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TurboNoid.DrawableObjects.Sprites {
    class UserControlledSprite : Sprite {
        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point size, int collisionOffset, Vector2 speed)
            : base(textureImage, position, size, collisionOffset, speed) { }

        public override Vector2 direction {
            get {
                Vector2 inputDirection = Vector2.Zero;

                if(Keyboard.GetState().IsKeyDown(Keys.Left)) {
                    inputDirection.X -= 1;
                }
                if(Keyboard.GetState().IsKeyDown(Keys.Right)) {
                    inputDirection.X += 1;
                }
                if(Keyboard.GetState().IsKeyDown(Keys.Up)) {
                    inputDirection.Y -= 1;
                }
                if(Keyboard.GetState().IsKeyDown(Keys.Down)) {
                    inputDirection.Y += 1;
                }

                return inputDirection * speed;
            }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {
            position += direction;

            if(position.X < 0) {
                position.X = 0;
            }
            if(position.Y < 0) {
                position.Y = 0;
            }
            if(position.X > clientBounds.Width - size.X) {
                position.X = clientBounds.Width - size.X;
            }
            if(position.Y > clientBounds.Height - size.Y) {
                position.Y = clientBounds.Height - size.Y;
            }

            base.Update(gameTime, clientBounds);
        }
    }
}
