using System;

using Microsoft.Xna.Framework;

namespace Platformer
{
    public abstract class TimeManager
    {
        /// Current game time relative to the total playing time
        /// Текущее игровое время относительно всего игрового времени
        protected TimeSpan time;

        /// Timer start relative to the total playing time
        /// Время запуска таймера относительно всего игрового времени
        protected TimeSpan startTime;

        /// Timer length
        /// Длинна таймера
        protected TimeSpan duration;

        /// Remaining time until the timer ends
        /// Оставшееся время до завершения таймера
        protected TimeSpan residualTime;

        /// Elapsed time from timer start
        /// Пройденное время от запуска таймера
        protected TimeSpan elapsedTime;

        /// The main method of updating the timer state
        /// Главный метод обновления состояния таймера
        public void Update(GameTime gameTime)
        {
            /// Global time update
            /// Обновление глобального времени
            time += gameTime.ElapsedGameTime;

            /// Updating the state of the running timer
            /// Обновление состояния запущенного таймера
            if (IsTimerStarted() && !IsTimeOver())
            {
                elapsedTime = time - startTime;
                residualTime = duration - elapsedTime;
            }
        }

        /// Starts the timer(Starting point - current global time)
        /// Запускает таймер (Начальная точка - текущее глобальное время)
        public void StartTimer()
        {
            if (!IsTimerStarted())
            {
                startTime = time;
            }
        }

        /// Resets timer settings
        /// Обнуляет параметры таймера
        public void CleanTimer()
        {
            if (IsTimerStarted())
            {
                startTime = TimeSpan.Zero;
                elapsedTime = TimeSpan.Zero;
                residualTime = TimeSpan.Zero;
            }
        }

        /// Returns true, if the timer is running.
        /// Возвращает true, если таймер запущен
        public bool IsTimerStarted()
        {
            if (startTime > TimeSpan.Zero)
            {
                return true;
            }
            return false;
        }

        /// Returns true if the timer has expired
        /// Возвращает true, если таймер завершил отсчет 
        public bool IsTimeOver()
        {
            if (IsTimerStarted() && (elapsedTime >= duration))
            {
                return true;
            }
            return false;
        }
    }
}
