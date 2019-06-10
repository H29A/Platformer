// ============================================================================
// Sprite.cs
//
// A XNA class that resembles a sprite. Has properties such as position, scale,
// and rotation that can be set. Calling Sprite.Draw( SpriteBatch ) will then
// call SpriteBatch.Draw and pass in each of the Sprites properties. Also
// contains helper methods like Move and Scale that will change the Sprite's
// properties using a delta that gets added to the previous property's value.
// ============================================================================

using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Sprite
    {
        private Texture2D texture;
        /// The sprite's texture (Read-only)
        /// Текстура спрайта (Только для чтения)
        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }
        }

        private Vector2 position;
        /// The sprite's 2D position (Read-only)
        /// Позиция 2D спрайта (Только для чтения) 
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }

        /// The sprite's rotation angle in radians (Read/Write)
        /// Угол поворота спрайта в радианах (Чтение/Запись)
        private float rotation;
        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }

        private Vector2 origin;
        /// The sprite's origin offset (Read-only) 
        /// Смещение источника спрайта (Только для чтения)
        public Vector2 Origin
        {
            get
            {
                return this.origin;
            }
        }

        private Rectangle rect;
        /// The sprite's source rectangle (Read-only)
        /// Исходный rectangle спрайта (Только для чтения)
        public Rectangle Rect
        {
            get
            {
                return this.rect;
            }
        }

        private Vector2 scaleFactor;
        /// The sprite's 2D scale factors (Read-only)
        /// 2D коэффициент масштабирования спрайта (Только для чтения)
        public Vector2 ScaleFactor
        {
            get
            {
                return this.scaleFactor;
            }
        }

        /// The sprite's width with using scale factor (Read-only)
        /// Ширина спрайта с использованным масштабным коэффициентом (только для чтения)
        public float Width
        {
            get
            {
                return texture.Width * scaleFactor.X;
            }
        }

        /// The sprite's width with using scale factor (Read-only)
        /// Высота спрайта с использованным масштабным коэффициентом (только для чтения)
        public float Height
        {
            get
            {
                return texture.Height * scaleFactor.Y;
            }
        }

        private bool isAnimated;
        /// Return true, if sprite is animated (Read-only)
        /// Возвращает true, если спрайт анимирован (Только для чтения)
        public bool IsAnimated
        {
            get
            {
                return isAnimated;
            }
        }

        /// The size and structure of whole frames sheet in animationTexture
        /// Размер структуры таблицы с кадрами анимированной текстуры
        private Point sheetSize;

        /// Amount of time between frames
        /// Время прошло между кадрами
        private TimeSpan frameInterval;

        /// Time passed since last frame
        /// Время прошло после последнего кадра
        private TimeSpan nextFrame;

        private Point currentFrame;
        /// Current frame in the animation sequence (Read-only)
        /// Текущий кадр в последовательности анимации (Только для чтения)
        public Point CurrentFrame
        {
            get
            {
                return this.currentFrame;
            }
        }

        private Point frameSize;
        /// The size of single frame inside the animationTexture (Read-only)
        /// Размер одного кадра в таблице фреймов (Только для чтения)
        public Point FrameSize
        {
            get
            {
                return this.frameSize;
            }
        }

        // ========================================================================
        // Creates a new sprite using the given texture
        // Создает новый спрайт, используя данную текстуру
        // ========================================================================

        /// Constructor for a static sprite (not animated)
        /// Констурктор для статического спарайта (не анимированного)
        public Sprite(Texture2D texture)
        {
            isAnimated = false;
            this.texture = texture;
            position = Vector2.Zero;
            rotation = 0.0f;
            origin = Vector2.Zero;
            rect = new Rectangle(0, 0, texture.Width, texture.Height);
            scaleFactor = Vector2.One;
        }

        /// Constructor for a animated sprite
        /// Констурктор для анимированного спрайта
        public Sprite(Texture2D texture, Point size, Point frameSheetSize, TimeSpan interval)
        {
            isAnimated = true;
            this.texture = texture;
            frameSize = size;
            sheetSize = frameSheetSize;
            frameInterval = interval;
            position = Vector2.Zero;
            rotation = 0.0f;
            origin = Vector2.Zero;
            rect = new Rectangle(0, 0, texture.Width, texture.Height);
            scaleFactor = Vector2.One;
        }

        // ========================================================================
        // Updates the animaton progress
        // Обновляет анимацию
        // ========================================================================

        ///Returns true if animation were progressed; in such case 
        ///caller could updated the position of the animated object.
        /// Возвращает true, если анимация еще выполняется;
        /// вызывающий может обновить позицию анимированного объекта.
        public bool Update(GameTime gameTime)
        {
            bool progressed;

            // Check is it is a time to progress to the next frame
            // Проверка на выполнение чтобы перейти на следующий кадр
            if (nextFrame >= frameInterval)
            {
                // Progress to the next frame in the row
                // Переход на следующий кадр в строке
                currentFrame.X++;

                // If reached end of the row advance to the next row 
                // and start form the first frame there
                // Если достигнут конец строки, переход к следующей строке
                // и начать выполнение с первого кадра 
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    currentFrame.Y++;
                }
                // If reached last row in the frame sheet jump to the first row again (endless loop)
                // Если достигнута последняя строка в таблице кадров - снова переход на первую строку (бесконечный цикл)
                if (currentFrame.Y >= sheetSize.Y)
                    currentFrame.Y = 0;

                // Reset interval for next frame
                // Сбросить интервал для следующего кадра
                progressed = true;
                nextFrame = TimeSpan.Zero;
            }
            else
            {
                // Wait for the next frame
                // Ожидание следующего кадра
                nextFrame += gameTime.ElapsedGameTime;
                progressed = false;
            }

            return progressed;
        }

        // ========================================================================
        // Draws the sprite onto a spritebatch using its settings
        // Рисует спрайт используя настройки spriteBatch 
        // ========================================================================

        public void DrawStatic(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rect, Color.White, rotation,
                              origin, scaleFactor, SpriteEffects.None, 0.0f);
        }

        public void DrawAnimated(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(
                  frameSize.X * currentFrame.X,
                  frameSize.Y * currentFrame.Y,
                  frameSize.X,
                  frameSize.Y),
                  Color.White, rotation, origin, scaleFactor, SpriteEffects.None, 0.0f);
        }

        // ========================================================================
        // Position modifiers
        // Модификатор Позиции
        // ========================================================================

        /// Sets the sprite's position given X and Y coordinates
        /// Устанавливает позицию спрайта по координатам X и Y
        public void SetPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        /// Sets the sprite's position given a Vector2
        /// Устанавливает позицию спрайта, по Vector2
        public void SetPosition(Vector2 pos)
        {
            position = pos;
        }

        /// Adds to the sprite's position given an X and Y
        /// Двигает спрайт по float X и Y
        public void Move(float deltaX, float deltaY)
        {
            position.X += deltaX;
            position.Y += deltaY;
        }

        /// Adds to the sprite's position given a Vector2
        /// Двигает спрайт по Vector2
        public void Move(Vector2 deltaPos)
        {
            position += deltaPos;
        }

        // ========================================================================
        // Origin modifiers
        // Модификаторы отсутупа
        // ========================================================================

        /// Sets the sprite's offset given X and Y coordinates
        /// Устанавливает смещение спрайта по float X и Y
        public void SetOrigin(float x, float y)
        {
            origin.X = x;
            origin.Y = y;
        }

        /// Sets the sprite's offset given a Vector2
        /// Устанавливает смещение спрайта по Vector2
        public void SetOrigin(Vector2 origin)
        {
            this.origin = origin;
        }

        // ========================================================================
        // Rect modifiers
        // Модификатор Rectangle
        // ========================================================================

        /// Sets the sprite's source rectangle given the X, Y, Width, and Height
        /// Устанавливает исходный rectangle спрайта по X, Y, Width и Height
        public void SetRect(int x, int y, int width, int height)
        {
            rect.X = x;
            rect.Y = y;
            rect.Width = width;
            rect.Height = height;
        }

        /// Sets the sprite's source rectangle given a new Rectangle
        /// Устанавливает исходный rectangle спрайта по new Rectangle
        public void SetRect(Rectangle newRect)
        {
            rect = newRect;
        }

        // ========================================================================
        // Scale modifiers
        // Модификаторы масштабирования
        // ========================================================================

        /// Sets the sprite's size given width and height in pixels
        /// Устанавливает размер спрайта по ширине и высоте в пикселях
        public void SetSpriteSize(int resolution)
        {
            scaleFactor.X = scaleFactor.Y = resolution / Width;     
        }

        public void SetSpriteSize(Vector2 resolution)
        {
            scaleFactor.X = resolution.X / Width;
            scaleFactor.Y = resolution.Y / Height;
        }

        /// Sets the sprite's scale given the X and Y factors
        /// Устанавливает коэффициент масштабирования спрайта по float X и Y
        public void SetScale(float x, float y)
        {
            scaleFactor.X = x;
            scaleFactor.Y = y;
        }

        /// Sets the sprite's scale given a uniform factor
        /// Устанавливает коэффициент масштабирования спрайта по одинаковым X и Y
        public void SetScale(float xy)
        {
            scaleFactor.X = scaleFactor.Y = xy;
        }

        /// Sets the sprite's scale given a new Vector2 factor
        /// Устанавливает коэффициент масштабирования спрайта по Vector2
        public void SetScale(Vector2 scale)
        {
            this.scaleFactor = scale;
        }

        /// Scales the sprite's current scale by the given X and Y factors
        /// Устанавливает коэффициент масштабирвоания спрайта по float X и Y
        public void Scale(float x, float y)
        {
            scaleFactor.X *= x;
            scaleFactor.Y *= y;
        }

        /// Scales the sprite's current scale by the given uniform factor
        /// Устанавливает коэффициент масштабирвоания спрайта по одинаковым X и Y
        public void Scale(float xy)
        {
            scaleFactor.X *= xy;
            scaleFactor.Y *= xy;
        }

        /// Scales the sprite's current scale by the given Vector2 factor
        /// Устанавливает коэффициент уже отмасштабированнрого спрайта по Vector2
        public void Scale(Vector2 scale)
        {
            scaleFactor *= scale;
        }
    }
}
