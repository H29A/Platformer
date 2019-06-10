using System.IO;
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
            scoresObj.Items.Add(new ScoreItem(player.Name, player.CoinsCount));
            File.WriteAllText(Values.scoresJsonPath, JsonConvert.SerializeObject(scoresObj, Formatting.Indented));
        }

        void DisplayScoresTable()
        {
            for(int i = 0; i < scoresObj.Items.Count; i++)
            {
                if (i == 10)
                {
                    scoreStringPosition += new Vector2(200, 0);
                }
                scoreStringPosition += Values.scoresDisplayingOffset;
                scoresStrings.Add(new Sprite(txtScoreString));
                scoresStrings[i].SetPosition(scoreStringPosition);
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

            foreach (Sprite scoreString in scoresStrings)
            {
                scoreString.DrawStatic(spriteBatch);
            }
        }
    }
}
