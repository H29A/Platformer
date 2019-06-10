using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer
{
    public class WinScreen : Screen
    {
        Player player;

        Texture2D txtBackground;
        Sprite background;

        Texture2D txtScoresButton;
        Sprite scoresTableButton;

        public WinScreen(Player player)
        {
            this.player = player;
        }

        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);

            txtBackground = Content.Load<Texture2D>(Values.txtWinScreenBackgound);
            background = new Sprite(txtBackground);
            background.SetSpriteSize(Values.resolution);

            txtScoresButton = Content.Load<Texture2D>(Values.txtScoresButton);
            scoresTableButton = new Sprite(txtScoresButton);
            scoresTableButton.SetPosition(Values.ScoresButtonOnWinScreenPosition);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime, Game game)
        {
            inputManager.Update();

            if (IsClickedOn(scoresTableButton))
            {
                ScreenManager.Instance.AddScreen(new ScoresScreen(player), inputManager);
            } else 
            if (inputManager.KeyPressed(Keys.Escape))
            {
                ScreenManager.Instance.AddScreen(new MenuScreen(), inputManager);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            background.DrawStatic(spriteBatch);
            spriteBatch.DrawString(font, $"{player.Name}, вы победили, ваши очки: {player.CoinsCount}!", Values.ScoresOnWinScreenPosition, new Color(228, 209, 209));
            scoresTableButton.DrawStatic(spriteBatch);
        }
    }
}
