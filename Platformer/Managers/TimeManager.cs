using System;
using Microsoft.Xna.Framework;

namespace Platformer
{
    public class TimeManager
    {
        int time;
        int startTime;
        TimeSpan duration;

        int elapsedTime;
        int ElapsedTime
        {
            get
            {
                return elapsedTime;
            }
        }

        public TimeManager(TimeSpan timeSpan)
        {
            this.duration = timeSpan;
        }

        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;

            if (IsTimerStarted())
            {
                elapsedTime = time - startTime;
            }
        }

        public void StartTimer()
        {
            if (!IsTimerStarted())
            {
                startTime = time;
            }
        }

        public void CleanTimer()
        {
            if (IsTimerStarted())
            {
                startTime = 0;
                elapsedTime = 0;
            }
        }

        public bool IsTimerStarted()
        {
            if (startTime > 0)
            {
                return true;
            }
            return false;
        }
        
        public bool IsTimeOver ()
        {
            if (IsTimerStarted() && (elapsedTime >= duration.Milliseconds))
            {
                return true;
            }
            return false;
        }
    }
}
