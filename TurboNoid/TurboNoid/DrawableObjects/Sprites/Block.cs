using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TurboNoid.DrawableObjects.Sprites {
    public enum BlockColour { White, Blue, Red };

    class Block : StationarySprite {
        private Texture2D _whiteTexture;
        private Texture2D _blueTexture;
        private Texture2D _redTexture;

        private BlockColour _blockColour;
        public BlockColour BlockColour {
            get { return _blockColour; }
            set {
                _blockColour = value;
                if(_blockColour == Sprites.BlockColour.White) {
                    textureImage = _whiteTexture;
                } else if(_blockColour == Sprites.BlockColour.Blue) {
                    textureImage = _blueTexture;
                } else if(_blockColour == Sprites.BlockColour.Red) {
                    textureImage = _redTexture;
                }
            }
        }

        public Block(Game game, Vector2 position, BlockColour blockColour)
            : base(null, position, new Point(77, 28), 1) {
            _whiteTexture = game.Content.Load<Texture2D>(@"Sprites/WhiteBlock");
            _blueTexture = game.Content.Load<Texture2D>(@"Sprites/BlueBlock");
            _redTexture = game.Content.Load<Texture2D>(@"Sprites/RedBlock");

            BlockColour = blockColour;
        }
    }
}
