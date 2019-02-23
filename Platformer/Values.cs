using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Platformer
{
    static public class Values
    {
        public const float gravitation = 5;
        public const int mapTileSize = 32;

        static public readonly string defaultTile = "Sprites/Tile";

        public const string txtBackgroundPath = "Sprites/Menu_Background";

        public const string sptMenuCat = "Sprites/Animated/Menu_animation";
        static public readonly Vector2 menuCatPosition = new Vector2(260, 165);
        static public readonly Vector2 menuCatFrameSize = new Vector2(500, 456);
        static public readonly Point menuCatTiles = new Point(6, 7);

        static public Vector2 descriptorPosition = new Vector2(515, 145);

        public const string txtPlayButton = "Sprites/PlayButton";
        static public readonly Vector2 playButtonPosition = new Vector2(220, 630);
        public const string txtExitButton = "Sprites/ExitButton";
        static public readonly Vector2 exitButtonPosition = new Vector2(420, 630);
        public const string txtScoresButton = "Sprites/ScoresButton";
        static public readonly Vector2 scoresButtonPosition = new Vector2(620, 630);

        public const string txtTextbox = "Sprites/Menu_Textbox";
        static public readonly Vector2 nameTextboxPosition = new Vector2(365, 50);

        static public readonly Vector2 playerStartPosition = new Vector2(300, 100);
        public const float playerStep = 3;
        public const string sptPlayer = "Sprites/Animated/Player";
        static public readonly Vector2 playerFrameSize = new Vector2(80, 56);
        static public readonly Point playerTiles = new Point(3, 2);
    }
}
