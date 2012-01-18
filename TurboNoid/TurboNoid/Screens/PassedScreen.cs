using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TurboNoid.CommunicationObjects;
using System.Collections.Generic;

namespace TurboNoid.Screens {
    public class PassedScreen: MessageScreenBase, IScreen {
        private Texture2D _startScreen;

        public override void LoadContent(Game game, IGameInfo gameInfo) {
            base.LoadContent(game, gameInfo);
            
            _startScreen = _game.Content.Load<Texture2D>(@"Screens/StartScreen");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Draw(_startScreen, _position, _startScreen.Bounds, _transparencyColour, 0, Vector2.Zero, SpriteEffects.None, 1);

            var textLines = new List<string>() {
                "TurboNoid Passage!", 
                "", 
                "Will Stewart level of Noid-bilities!", 
                "", 
                "S to play that shit again!"
            };
            DrawCenteredTextLines(spriteBatch, textLines);
            
            spriteBatch.End();
        }
    }
}
