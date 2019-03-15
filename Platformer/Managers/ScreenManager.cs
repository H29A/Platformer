using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Platformer
{
    public class ScreenManager
    {
        ContentManager content;

        Screen currentScreen;

        Screen newScreen;

        InputManager inputManager;

        private static ScreenManager instance;

        private ScreenManager()
        {

        }

        public static Stack<Screen> screenStack = new Stack<Screen>();

        Vector2 dimensions;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public Vector2 Dimensions
        {
            get
            {
                return dimensions;
            }
            set
            {
                dimensions = value;
            }
        }

        public void AddScreen(Screen screen, InputManager inputManager)
        {
            if (screenStack.Count != 0)
                screenStack.Pop();

            newScreen = screen;
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = newScreen;
            currentScreen.LoadContent(content, inputManager);
            this.inputManager = inputManager;
        }

        public void Initialize()
        {
            currentScreen = new MenuScreen();
            inputManager = new InputManager();
        }
        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content, inputManager);
        }

        public void Update(GameTime gameTime, Game game)
        {
            currentScreen.Update(gameTime, game);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
