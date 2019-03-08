using Microsoft.Xna.Framework;

namespace Platformer
{
    static public class Values
    {
        #region Main settings
            static public Vector2 resolution = new Vector2(1024, 800);
            public const float gravitation = 5;
            public const float playerStep = 3;
        #endregion

        #region Sprites settings
            #region Animated items
                #region Menu cat sprite
                    static public readonly Vector2 menuCatPosition = new Vector2(260, 210);
                    static public readonly Vector2 menuCatFrameSize = new Vector2(500, 456);
                    static public readonly Point menuCatTiles = new Point(6, 7);
                #endregion
                #region Player sprite
                    static public readonly Vector2 playerStartPosition = new Vector2(300, 100);
                    static public readonly Vector2 playerFrameSize = new Vector2(80, 56);
                    static public readonly Point playerTiles = new Point(3, 2);
                #endregion
                #region Paths
                    public const string sptMenuCat = "Sprites/Animated/Menu/Cat";
                    public const string sptPlayer = "Sprites/Animated/Player/Player";
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
                        public const string txtBackgroundPath = "Sprites/Not Animated/Menu/Background";
                        public const string txtPlayButton = "Sprites/Not Animated/Menu/PlayButton";
                        public const string txtExitButton = "Sprites/Not Animated/Menu/ExitButton";
                        public const string txtScoresButton = "Sprites/Not Animated/Menu/ScoresButton";
                        public const string txtTextbox = "Sprites/Not Animated/Menu/Textbox";
        #endregion
                #endregion
                #region Map items
                    static public readonly string defaultTile = "Sprites/Not Animated/Map/Tile"; //temporally
                #endregion
            #endregion
        #endregion

        #region Other settings
            static public Vector2 descriptorPosition = new Vector2(518, 145);
            public const int mapTileSize = 32;
        #endregion

        #region Json paths
            public const string scoresJsonPath = "JsonFiles/Scores/Scores.json";
        #endregion
    }
}
