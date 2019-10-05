using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer
{
    public class LoseScreen : Screen
    {
        Player player;

        Texture2D txtBackground;
        Sprite background;

        Texture2D txtScoresButton;
        Sprite scoresTableButton;

        public LoseScreen(Player player)
        {
            this.player = player;
            Player.position = Values.playerStartPosition;
            Player.isOnLevelTwo = false;
        }

        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);

            txtBackground = Content.Load<Texture2D>(Values.txtLoseScreenBackground);
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

            if (IsClickedOn(scoresTableButton) || inputManager.KeyPressed(Keys.Escape))
            {
                ScreenManager.Instance.AddScreen(new ScoresScreen(player), inputManager);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            background.DrawStatic(spriteBatch);
            spriteBatch.DrawString(font, $"{player.Name}, вы проиграли, ваши очки: {player.CoinsCount}!", Values.ScoresOnLoseScreenPosition, new Color(228, 209, 209));
            scoresTableButton.DrawStatic(spriteBatch);
        }
    }
}
