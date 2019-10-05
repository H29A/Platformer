using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Player
    {
        string name = string.Empty;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public static Vector2 position = Values.playerStartPosition;
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        string info = string.Empty;
        public string Info
        {
            get
            {
                return info;
            }
            set
            {
                Info = value;
            }
        }

        public static Sprite sptPlayer;
        Texture2D txtPlayer;

        Timer jumpTimer;
        Timer fallTimer;

        bool isJumping;
        bool isOnPlatform;
        bool isSecondJumpUsed;
        public static bool isUnderBonus;
        public static bool isOnLevelTwo;

        public static Timer BonusTimer = new Timer(Values.bonusTimerSpan);

        int coinsCount = 0;
        public int CoinsCount
        {
            get
            {
                return coinsCount;
            }
        }

        public Player(string name)
        {
            jumpTimer = new Timer(Values.jumpTimeSpan);
            fallTimer = new Timer(Values.fallTimeSpan);

            this.name = name;

            isJumping = false;
            isOnPlatform = false;
            isSecondJumpUsed = false;
            isUnderBonus = false;
            isOnLevelTwo = false;
        }

        public void LoadContent(ContentManager content)
        {
            txtPlayer = content.Load<Texture2D>(Values.sptPlayer);
            sptPlayer = new Sprite(txtPlayer, Values.playerFrameSize, Values.playerTiles, Values.playerTimeSpan);
            sptPlayer.SetPosition(Values.playerStartPosition);
        }

        public void UnloadContent() { }

        public void IncCoinCount()
        {
            coinsCount++;
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            jumpTimer.Update(gameTime);
            fallTimer.Update(gameTime);
            BonusTimer.Update(gameTime);

            if (isUnderBonus && !BonusTimer.IsTimerStarted())
            {
                BonusTimer.StartTimer();
            }

            if (BonusTimer.IsTimeOver())
            {
                isUnderBonus = false;
                BonusTimer.CleanTimer();
            }


            sptPlayer.SetPosition(position);
            sptPlayer.SetRect((int)position.X, (int)position.Y, (int)Values.playerFrameSize.X, (int)Values.playerFrameSize.Y);
            sptPlayer.Update(gameTime);

            foreach (Platform platform in Map.platforms)
            {
                Rectangle item = new Rectangle((int)platform.Position.X, (int)platform.Position.Y, (int)platform.sprite.Width, (int)platform.sprite.Height);
                if (sptPlayer.Rect.isOnTopOf(item))
                {
                    isOnPlatform = true;
                    isSecondJumpUsed = false;

                    fallTimer.CleanTimer();

                    position.Y = item.Y - Values.playerFrameSize.Y;

                    if ((inputManager.KeyPressed(Keys.Space) || inputManager.KeyPressed(Keys.Up)))
                    {
                        isJumping = true;
                        jumpTimer.CleanTimer();
                        jumpTimer.StartTimer();
                    }
                }
                else 
                {
                    isOnPlatform = false;
                }
            }

            if (jumpTimer.IsTimeOver() && isJumping)
            {
                isJumping = false;

                jumpTimer.CleanTimer();
                fallTimer.StartTimer();
            }


            if (isJumping)
            {
                position.Y -= jumpTimer.ResidualTime.Milliseconds * Values.playerGravity + Values.playerJumpAcceleration;
            }

            if (!isOnPlatform)
            {
                if (!fallTimer.IsTimerStarted())
                {
                    fallTimer.StartTimer();
                }

                position.Y += fallTimer.ElapsedTime.Milliseconds * Values.playerGravity;

                if (!isSecondJumpUsed && (inputManager.KeyPressed(Keys.Space) || inputManager.KeyPressed(Keys.Up)))
                {
                    isJumping = true;
                    isSecondJumpUsed = true;

                    jumpTimer.CleanTimer();
                    jumpTimer.StartTimer();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sptPlayer.DrawAnimated(spriteBatch);
        }
    }
}
