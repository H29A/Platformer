using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class LevelScreen : Screen
    {
        Map map;
        Player player;
        Timer nextLevelTimer;
        Timer winTimer;

        Sprite ScoreBar;
        Texture2D txtScoreBar;

        public LevelScreen(string playerName)
        {
            player = new Player(playerName);
            map = new Map(player);
            nextLevelTimer = new Timer(Values.timeForLevelUp);
            winTimer = new Timer(Values.timeForWin);
        }

        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);

            map.LoadContent(Content);
            player.LoadContent(Content);

            txtScoreBar = Content.Load<Texture2D>(Values.txtScoreBar);
            ScoreBar = new Sprite(txtScoreBar);
            ScoreBar.SetPosition(Values.scoreBarPosition);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime, Game game)
        {
            if (!Player.isOnLevelTwo && !nextLevelTimer.IsTimerStarted())
            {
                nextLevelTimer.StartTimer();
            }

            nextLevelTimer.Update(gameTime);
            winTimer.Update(gameTime);

            inputManager.Update();
            map.Update(gameTime);
            player.Update(gameTime, inputManager);

            if (!Player.isOnLevelTwo && nextLevelTimer.IsTimeOver())
            {
                nextLevelTimer.CleanTimer();
                winTimer.StartTimer();
                Player.isOnLevelTwo = true;
            }

            if (Player.isOnLevelTwo && winTimer.IsTimeOver())
            {
                winTimer.CleanTimer();
                ScreenManager.Instance.AddScreen(new WinScreen(player), inputManager);
            }
            

            if (player.Position.Y > Values.resolution.Y)
            {
                ScreenManager.Instance.AddScreen(new LoseScreen(player), inputManager);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.LightBlue);
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
            ScoreBar.DrawStatic(spriteBatch);
            spriteBatch.DrawString(font, $"{player.Name}: {player.CoinsCount}", Values.scoresPosition, new Color(228, 209, 209));
            spriteBatch.DrawString(font, $"До окончания {(Player.isOnLevelTwo ? 2 : 1)} уровня {(Player.isOnLevelTwo ? (int)winTimer.ResidualTime.TotalSeconds : (int)nextLevelTimer.ResidualTime.TotalSeconds)} секунд!", Values.levelUpTimerPosition, new Color(228, 209, 209));
        }
    }
}
