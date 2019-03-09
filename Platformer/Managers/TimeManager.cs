using Microsoft.Xna.Framework;

namespace Platformer
{
    public class TimeManager
    {
        int time;
        int startTime;
        int elapsedTime;
        double duration;

        int ElapsedTime
        {
            get { return elapsedTime; }
        }

        public TimeManager(double duration)
        {
            this.duration = duration;
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
            if (IsTimerStarted() && (elapsedTime >= duration))
            {
                return true;
            }
            return false;
        }
    }
}
