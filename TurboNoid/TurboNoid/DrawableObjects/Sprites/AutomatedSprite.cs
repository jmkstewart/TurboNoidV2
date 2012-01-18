using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurboNoid.DrawableObjects.Sprites {
    class AutomatedSprite : Sprite {
        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point size, int collisionOffset, Vector2 speed)
            : base(textureImage, position, size, collisionOffset, speed) { }

        public override Vector2 direction {
            get { return speed; }
        }
        
        public override void Update(GameTime gameTime, Rectangle clientBounds) {
            if(gameTime.ElapsedGameTime.Milliseconds != 16) {
                var s = "";
            }

            var time = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            var speedOffset = time * 60;
            
            position += direction * speedOffset;
            
            base.Update(gameTime, clientBounds);
        }
    }
}
