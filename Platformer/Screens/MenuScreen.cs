using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class MenuScreen : Screen
    {
        TextureManager txtBackground;
        AnimationManager sptMenuCat;

        TextureManager playButton;
        TextureManager exitButton;
        TextureManager scoresButton;

        TextureManager nameTextbox;

        public MenuScreen()
        {
            txtBackground = new TextureManager(Values.txtBackgroundPath, Vector2.Zero);
            sptMenuCat = new AnimationManager(Values.sptMenuCat, Values.menuCatFrameSize, Values.menuCatTiles);

            playButton = new TextureManager(Values.txtPlayButton, Values.playButtonPosition);
            exitButton = new TextureManager(Values.txtExitButton, Values.exitButtonPosition);
            scoresButton = new TextureManager(Values.txtScoresButton, Values.scoresButtonPosition);

            nameTextbox = new TextureManager(Values.txtTextbox, Values.nameTextboxPosition);
        }

        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);

            txtBackground.LoadContent(Content);
            sptMenuCat.LoadContent(Content);

            playButton.LoadContent(Content);
            exitButton.LoadContent(Content);
            scoresButton.LoadContent(Content);

            nameTextbox.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        private bool IsClickedOn(TextureManager item)
        {
            Vector2 position = inputManager.MouseState.Position.ToVector2();

            if (position.X >= item.Position.X &&
                position.Y >= item.Position.Y &&
                position.X <= item.Position.X + item.Texture.Width &&
                position.Y <= item.Position.Y + item.Texture.Height &&
                inputManager.MouseState.LeftButton == ButtonState.Released &&
                inputManager.PrevMouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }

        public void IsLetterEntered(Keys[] keyArray)
        {
            string toStringKeys;

            foreach (Keys key in keyArray)
            {
                if (inputManager.KeyPressed(key))
                {
                    if (key == Keys.Back && Player.Instance.PlayerName.Length > 0)
                    {
                        Player.Instance.PlayerName = Player.Instance.PlayerName.Remove(Player.Instance.PlayerName.Length - 1, 1);
                        Values.descriptorPosition.X += 7.5f;
                    }
                    else 
                    if (Player.Instance.PlayerName.Length < 8 &&
                             key.GetHashCode() >= 65 &&
                             key.GetHashCode() <= 90 ||
                             key == Keys.OemOpenBrackets ||
                             key == Keys.OemCloseBrackets ||
                             key == Keys.OemQuotes ||
                             key == Keys.OemSemicolon ||
                             key == Keys.OemComma ||
                             key == Keys.OemPeriod)
                    {
                        switch (key.ToString())
                        {
                            case "Q": toStringKeys = "Й"; break;
                            case "W": toStringKeys = "Ц"; break;
                            case "E": toStringKeys = "У"; break;
                            case "R": toStringKeys = "К"; break;
                            case "T": toStringKeys = "Е"; break;
                            case "Y": toStringKeys = "Н"; break;
                            case "U": toStringKeys = "Г"; break;
                            case "I": toStringKeys = "Ш"; break;
                            case "O": toStringKeys = "Щ"; break;
                            case "P": toStringKeys = "З"; break;
                            case "OemOpenBrackets": toStringKeys = "Х"; break;
                            case "OemCloseBrackets": toStringKeys = "Ъ"; break;
                            case "A": toStringKeys = "Ф"; break;
                            case "S": toStringKeys = "Ы"; break;
                            case "D": toStringKeys = "В"; break;
                            case "F": toStringKeys = "А"; break;
                            case "G": toStringKeys = "П"; break;
                            case "H": toStringKeys = "Р"; break;
                            case "J": toStringKeys = "О"; break;
                            case "K": toStringKeys = "Л"; break;
                            case "L": toStringKeys = "Д"; break;
                            case "OemSemicolon": toStringKeys = "Ж"; break;
                            case "OemQuotes": toStringKeys = "Э"; break;
                            case "Z": toStringKeys = "Я"; break;
                            case "X": toStringKeys = "Ч"; break;
                            case "C": toStringKeys = "С"; break;
                            case "V": toStringKeys = "М"; break;
                            case "B": toStringKeys = "И"; break;
                            case "N": toStringKeys = "Т"; break;
                            case "M": toStringKeys = "Ь"; break;
                            case "OemComma": toStringKeys = "Б"; break;
                            case "OemPeriod": toStringKeys = "Ю"; break;
                            default: toStringKeys = Convert.ToString((Keys)key); break;
                        }
                        Player.Instance.PlayerName += toStringKeys;
                        Values.descriptorPosition.X -= 7.5f;
                    }
                }
            }
        }

        public override void Update(GameTime gameTime, Game game)
        {
            inputManager.Update();
            IsLetterEntered(inputManager.KeyState.GetPressedKeys());

            sptMenuCat.Update(gameTime, ScreenManager.Instance.Dimensions / 4);

            if (IsClickedOn(playButton) && (Player.Instance.PlayerName != string.Empty))
            {
                ScreenManager.Instance.AddScreen(new LevelScreen(), inputManager);
            } else 
            if (IsClickedOn(scoresButton))
            {
                ScreenManager.Instance.AddScreen(new ScoresScreen(), inputManager);
            } else 
            if (IsClickedOn(exitButton) || inputManager.KeyPressed(Keys.Escape))
            {
                game.Exit();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.Black);

            txtBackground.Draw(spriteBatch);
            sptMenuCat.Draw(spriteBatch);

            playButton.Draw(spriteBatch);
            exitButton.Draw(spriteBatch);
            scoresButton.Draw(spriteBatch);

            nameTextbox.Draw(spriteBatch);
            spriteBatch.DrawString(font, Player.Instance.PlayerName, Values.descriptorPosition, new Color(228, 209, 209));
        }
    }
}
