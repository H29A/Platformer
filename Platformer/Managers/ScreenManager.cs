using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Platformer
{
    public class ScreenManager
    {
        ContentManager content;

        //Экран, который в данный момент отображается
        Screen currentScreen;

        //Новый экран который  будет отображен
        Screen newScreen;

        InputManager inputManager;

        private static ScreenManager instance;

        private ScreenManager() { }

        //В этом LIFO стеке хранится история открытия экранов (последний вошел - первый вышел)
        public static Stack<Screen> screenStack = new Stack<Screen>();

        //Высота и ширина отображаемого окна
        Vector2 dimensions;

        //Юзаем сингтон паттерн, ибо экран должен гарантированно один за life cycle приложения
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
            get { return dimensions; }
            set { dimensions = value; }
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
