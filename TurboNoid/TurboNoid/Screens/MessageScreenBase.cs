using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TurboNoid.CommunicationObjects;
using System.Collections.Generic;

namespace TurboNoid.Screens {
    public abstract class MessageScreenBase {
        protected Rectangle _position;
        protected Game _game;
        protected SpriteFont _font;
        protected Color _transparencyColour;
        protected IGameInfo _gameInfo;

        public virtual void LoadContent(Game game, IGameInfo gameInfo) {
            _game = game;
            _gameInfo = gameInfo;
            _position = new Rectangle(50, 20, 700, 420);
            _font = _game.Content.Load<SpriteFont>("Fonts/GameFont");

            float alpha = 0.7f;
            _transparencyColour = new Color(new Vector4(alpha, alpha, alpha, alpha));
        }

        protected Vector2 GetCenteredTextPosition(string text) {
            Vector2 textSize = _font.MeasureString(text);
            return new Vector2(_game.GraphicsDevice.Viewport.TitleSafeArea.Center.X - textSize.X / 2, _game.GraphicsDevice.Viewport.TitleSafeArea.Center.Y - textSize.Y / 2);
        }

        protected List<int> GetCenteredYByNumberOfLines(int lines) {
            var centeredYs = new List<int>();

            Vector2 textSize = _font.MeasureString("Test");
            var totalY = lines * textSize.Y;
            var centreY = _game.Window.ClientBounds.Height / 2;
            var startY = centreY - (totalY / 2);

            var y = startY;
            for(int i = 0; i < lines; i++) {
                centeredYs.Add((int)y);
                y += textSize.Y;
            }

            return centeredYs;
        }

        protected void DrawCenteredTextLines(SpriteBatch spriteBatch, List<string> textLines) {
            var yList = GetCenteredYByNumberOfLines(textLines.Count);

            int i = 0;
            foreach(var textLine in textLines) {
                var x1 = GetCenteredTextPosition(textLine).X;
                spriteBatch.DrawString(_font, textLine, new Vector2(x1, yList[i]), _transparencyColour, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                i++;
            }
        }

    }
}
