using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TurboNoid.DrawableObjects.Sprites {
    class Player : UserControlledSprite {
        public Player(Texture2D textureImage, Vector2 position)
            : base(textureImage, position, new Point(141, 26), 1, new Vector2(20, 20)) { }

        public override Vector2 direction {
            get {
                Vector2 inputDirection = Vector2.Zero;
                KeyboardState keyboardState = Keyboard.GetState();

                if(keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A)) {
                    inputDirection.X -= 1;
                }
                if(keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D)) {
                    inputDirection.X += 1;
                }

                return inputDirection * speed;
            }
        }
    }
}
