using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Newtonsoft.Json;

namespace Platformer
{
    public class ScoresScreen : Screen
    {
        Scores scoresObj;
        Player player;

        Texture2D txtBackground;
        Sprite background;

        Texture2D txtExitButton;
        Sprite exitButton;

        Texture2D txtScoreString;

        List<Sprite> scoresStrings = new List<Sprite>();

        Vector2 scoreStringPosition = Values.scoreStringBasePosition;

        public ScoresScreen()
        {
            scoresObj = JsonConvert.DeserializeObject<Scores>(File.ReadAllText(Values.scoresJsonPath));
        }

        public ScoresScreen(Player player)
        {
            this.player = player;

            scoresObj = JsonConvert.DeserializeObject<Scores>(File.ReadAllText(Values.scoresJsonPath));

            foreach (ScoreItem score in scoresObj.Items)
            {
                if (score.IsLast)
                {
                    score.IsLast = false;
                }
            }

            scoresObj.Items.Add(new ScoreItem(player.Name, player.CoinsCount, true));
            scoresObj.Items = scoresObj.Items.OrderByDescending(scoreString => scoreString.Score).ToList<ScoreItem>();
            File.WriteAllText(Values.scoresJsonPath, JsonConvert.SerializeObject(scoresObj, Formatting.Indented));
        }

        void DisplayScoresTable()
        {
            for(int i = 0; i < scoresObj.Items.Count; i++)
            {
                if (i > 20)
                {
                    break;
                }

                if (i == 10)
                {
                    scoreStringPosition = new Vector2(640, Values.scoreStringBasePosition.Y);
                }

                scoreStringPosition += Values.scoresDisplayingOffset;
                scoresStrings.Add(new Sprite(txtScoreString));
                scoresStrings[i].SetPosition(scoreStringPosition);
                scoresStrings[i].SetSpriteSize(Values.scoresStringSpriteSize);
            }
        }

        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);

            txtBackground = Content.Load<Texture2D>(Values.txtScoresScreenBackgound);
            background = new Sprite(txtBackground);
            background.SetSpriteSize(Values.resolution);

            txtExitButton = content.Load<Texture2D>(Values.txtExitButton);
            exitButton = new Sprite(txtExitButton);
            exitButton.SetPosition(Values.exitButtonPosition);

            txtScoreString = content.Load<Texture2D>(Values.txtScoreString);

            DisplayScoresTable();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime, Game game)
        {
            inputManager.Update();

            if (inputManager.KeyPressed(Keys.Escape) || IsClickedOn(exitButton))
            {
                ScreenManager.Instance.AddScreen(new MenuScreen(), inputManager);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            background.DrawStatic(spriteBatch);
            exitButton.DrawStatic(spriteBatch);

            for (int i = 0; i < scoresStrings.Count; i++)
            {
                if (i >= 20)
                {
                    break;
                }

                if (scoresObj.Items[i].IsLast)
                {
                    spriteBatch.DrawString(font, $"В последний раз игрок {scoresObj.Items[i].Name} занял {i + 1} место, его очки: {scoresObj.Items[i].Score}", new Vector2(170, 70), Values.highlightColor);
                }

                scoresStrings[i].DrawStatic(spriteBatch);
                spriteBatch.DrawString(font, $"{i + 1}. {scoresObj.Items[i].Name}: {scoresObj.Items[i].Score}", scoresStrings[i].Position + new Vector2(15, 5), scoresObj.Items[i].IsLast ? Values.highlightColor : Values.mainColor);
            }
        }
    }
}
