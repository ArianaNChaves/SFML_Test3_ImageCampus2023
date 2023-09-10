using System;
using SFML.System;
using SFML.Graphics;

namespace SpaceInvader
{
    public abstract class LoopState
    {
        protected RenderWindow window;
        protected bool isRunning;
        protected bool isPaused;

        public LoopState(RenderWindow window)
        {
            this.window = window;
            isRunning = false;
            isPaused = false;
        }
        protected virtual void Start() => window.Closed += OnCloseWindow;
        public virtual void Stop() { isRunning = false; }
        protected virtual void Update(float deltaTime) { }
        protected virtual void Draw() { }
        protected virtual void Finish() => window.Closed -= OnCloseWindow;
        protected virtual void ProcessInputs() => window.DispatchEvents();

        public void OnCloseWindow(object sender, EventArgs eventArgs)
        {
            window.Close();
        }
        public void Play()
        {
            Clock clock = new Clock();

            isRunning = true;

            Start();

            while (isRunning)
            {
                if (isPaused) continue;

                Time deltaTime = clock.Restart();

                ProcessInputs();
                Update(deltaTime.AsSeconds());
                Draw();
            }
            Finish();
        }
        public void Pause() 
        {
            if (isRunning && !isPaused) isPaused = true;
        }

        public void Resume()
        {
            if (isRunning && isPaused) isPaused = false;
        }
    }
}