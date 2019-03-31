using System;

namespace Platformer
{
    public class Timer : TimeManager
    {
        /// Elapsed time from timer start (read-only)
        /// Пройденное время от запуска таймера (только для чтения)
        public int ElapsedTime
        {
            get
            {
                return elapsedTime;
            }
        }

        /// Remaining time until the timer ends (read-only)
        /// Оставшееся время до завершения таймера (только для чтения)
        public int ResidualTime
        {
            get
            {
                return residualTime;
            }
        }

        /// Timer length (read-only)
        /// Длинна таймера (только для чтения)
        public TimeSpan Duration
        {
            get
            {
                return duration;
            }
        }

        public Timer(TimeSpan timeSpan)
        {
            this.duration = timeSpan;
        }
    }
}
