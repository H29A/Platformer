using System;
using Microsoft.Xna.Framework;

namespace Platformer
{
    static public class Values
    {
        #region Main settings
            /// Game window resolution option
            /// Параметр разрешения окна игры
            static public Vector2 resolution = new Vector2(1024, 800);
            
            /// Time to lift the character up when jumping
            /// Время подъема персонажа вверх при прыжке
            static public TimeSpan jumpTimeSpan = new TimeSpan(0, 0, 0, 0, 350); //milliseconds

            /// Character acceleration time when falling
            /// Время ускорения персонажа при падении
            static public TimeSpan fallTimeSpan = new TimeSpan(0, 0, 0, 0, 150); //milliseconds    

            /// Delay in creating a new platform
            /// Задержка создания новой платформы
            static public TimeSpan spawnPlatformTimeSpan = new TimeSpan(0, 0, 0, 0, 150); //milliseconds

            /// Time needed for level up   
            /// Небходимо время для перехода на следующий уровень
            static public TimeSpan timeForLevelUp = new TimeSpan(0, 0, 1, 0, 0); //seconds

            /// Acceleration of the character at the beginning of the jump
            /// Ускорение персонажа при начале прыжка
            public const float playerJumpAcceleration = 5f;

            /// character movement speed
            /// Скорость движения персонажа
            public const float playerVelocity = 120f;

            /// Character gravity
            /// Сила тяжести персонажа
            public const float playerGravity = 0.04f;
            
            /// Platform movement speed
            /// Скорость движения платформ
            public const float platformsSpeed = 10f;
 
            /// Minimum distance (in pixels) required to turn a new platform relative to the bottom (top) of all platforms
            /// Минимальное расстояние (в пикселях), необходимое для повления новой платформы относительно низа (верха) всех платформ
            public const float LowerPlatformSpawnValue = 80;      
            public const float UpperPlatformSpawnValue = 80;

            /// Resolution of the food sprite (in pixels)
            /// Разрешение спрайта еды (в пикселях)
            public const int FoodSpriteResolution = 80;

            /// Minimum (maximum) platform generation width
            /// Минимальная (максимальная) длина сгенерированной платформы
            public const int LowerPlatformGenerationWidth = 100;
            public const int UpperPlatformGenerationWidth = 180;

            static public TimeSpan AlertDisplayingDuration = new TimeSpan(0, 0, 0, 3, 0);
        #endregion

        #region Sprites settings
        #region Animated items
        #region Menu cat sprite
                    static public readonly Vector2 menuCatPosition = new Vector2(260, 210);
                    static public readonly Point menuCatFrameSize = new Point(500, 456);
                    static public readonly Point menuCatTiles = new Point(6, 7);
                    static public readonly TimeSpan menuCatTimeSpan = new TimeSpan(0, 0, 0, 0, 65); //milliseconds
                #endregion
                #region Player sprite
                    static public readonly Vector2 playerStartPosition = new Vector2(300, 100); 
                    static public readonly Point playerFrameSize = new Point(80, 56);
                    static public readonly Point playerTiles = new Point(3, 2);
                    static public readonly TimeSpan playerTimeSpan = new TimeSpan(0, 0, 0, 0, 50); //milliseconds
                #endregion
                #region Sky
                    static public readonly Point skyFrameSize = new Point(450, 810);
                    static public readonly Point skyTiles = new Point(5, 4);
                    static public readonly TimeSpan skyTimeSpan = new TimeSpan(0, 0, 0, 0, 50); //milliseconds
                #endregion
                #region Bonuses
                    #region Coin
                        static public readonly Point coinFrameSize = new Point(160, 160);
                        static public readonly Point coinTiles = new Point(2, 4);
                        static public readonly TimeSpan coinTimeSpan = new TimeSpan(0, 0, 0, 0, 30); //milliseconds
                    #endregion
                #endregion
                #region Paths
                    public const string sptMenuCat = "Sprites/Animated/Menu/Cat";
                    public const string sptPlayer = "Sprites/Animated/Player/Player";
                    public const string sptSky = "Sprites/Animated/Map/Sky";  
                    public const string sptCoin = "Sprites/Animated/Map/Bonuses/coin";
                #endregion
            #endregion  
            #region Not animated items
                #region Menu items
                    #region Items
                        static public readonly Vector2 playButtonPosition = new Vector2(220, 675);
                        static public readonly Vector2 exitButtonPosition = new Vector2(420, 675);
                        static public readonly Vector2 scoresButtonPosition = new Vector2(620, 675);
                        static public readonly Vector2 nameTextboxPosition = new Vector2(365, 50);
                    #endregion
                    #region Paths
                        public const string txtBackground = "Sprites/Not Animated/Menu/Background";
                        public const string txtPlayButton = "Sprites/Not Animated/Menu/PlayButton";
                        public const string txtExitButton = "Sprites/Not Animated/Menu/ExitButton";
                        public const string txtScoresButton = "Sprites/Not Animated/Menu/ScoresButton";
                        public const string txtTextbox = "Sprites/Not Animated/Menu/Textbox";
                    #endregion
                #endregion
                #region Map items
                    static public readonly string txtSky = "Sprites/Not Animated/Map/Background";
                    static public readonly string defaultTile = "Sprites/Not Animated/Map/Tile"; //temporally
                    static public readonly string txtPlatform = "Sprites/Not Animated/Map/Platform";
                #endregion
                #region Screens sources
                    static public readonly string txtWinScreenBackgound = "Sprites/Not Animated/Screens/WinScreen";
                    static public readonly string txtLoseScreenBackground = "Sprites/Not Animated/Screens/LoseScreen";
                    static public readonly string txtScoresScreenBackgound= "Sprites/Not Animated/Screens/ScoresScreen";
                #endregion
                #region UI items
                    static public readonly string txtScoreBar = "Sprites/Not Animated/UI/ScoreBar";
                    static public readonly string txtScoreString = "Sprites/Not Animated/UI/ScoreString";
                #endregion
        #endregion
        #endregion

        #region Other settings
            static public Vector2 descriptorPosition = new Vector2(500, 145);
            static public Vector2 scoreBarPosition = new Vector2(20, 20);
            static public Vector2 levelUpTimerPosition = new Vector2(350 ,35);
            static public Vector2 scoresPosition = new Vector2(90, 35);
            static public Vector2 ScoresOnWinScreenPosition = new Vector2(300, 650);
            static public Vector2 ScoresButtonOnWinScreenPosition = new Vector2(420, 690);
            static public Vector2 ScoresOnLoseScreenPosition = new Vector2(320, 70);
            static public Vector2 scoreStringBasePosition = new Vector2(200, 100);
            static public Vector2 scoresDisplayingOffset = new Vector2(0, 50);
            static public Vector2 scoresStringSpriteSize = new Vector2(200, 40);
            static public Color mainColor = new Color(228, 209, 209);
            static public Color highlightColor = new Color(228, 23, 2);
            public const int mapTileSize = 32;
            static public readonly string backgroundSong = "Sounds/BackgroundMusic";
            static public Vector2 alertPosition = new Vector2(390, 135);
        #endregion

        #region Json paths
            public const string scoresJsonPath = "JsonFiles/Scores/Scores.json";
        #endregion
    }
}
