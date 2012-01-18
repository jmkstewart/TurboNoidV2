using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TurboNoid.DrawableObjects.Sprites {
    class StationarySprite : Sprite {
        public StationarySprite(Texture2D textureImage, Vector2 position, Point size, int collisionOffset)
            : base(textureImage, position, size, collisionOffset, Vector2.Zero) { }

        public override Vector2 direction {
            get { return Vector2.Zero; }
        }
    }
}
