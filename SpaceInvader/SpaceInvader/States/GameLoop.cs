using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using SFML.Audio;

namespace SpaceInvader
 {
    class GameLoop : LoopState
    {
        Sprite? background;        
        Player? player;
        PauseMenu pauseMenu;
        public static Music gameMusic;
        EnemyManager? enemies;

        public GameLoop(RenderWindow window) : base (window)
        {
            this.window = window;
            this.window.SetFramerateLimit(60);
            pauseMenu = new PauseMenu(window);
            TextureManager.LoadGameTexture();
        }

        protected override void Start()
        {
            base.Start();
            window.KeyPressed += OnKeyPressed;
            isPaused = false;
            this.window = window;
            TextManager.loadFont("Second-Grade");
            background = new Sprite();
            background.Texture = TextureManager.BackgroundTexture;
            player = new Player();
            enemies = new EnemyManager();
            gameMusic = new Music("Assets/Music/BitRush.ogg");
            gameMusic.Loop = true;
            gameMusic.Play();
            gameMusic.Volume = 10f;
            Run();
        }

        public override void Stop()
        {
            window.KeyPressed -= OnKeyPressed;
            base.Stop();
        }

        public void Run()
        {
            while(this.window.IsOpen)
            {
                this.HandleEvents();
                this.Update();
                this.Draw();            
            }
        }
        public void OnKeyPressed(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                SetPause();
            }
        }
        public void SetPause()
        {
            GameLoop.gameMusic.Pause();
            Pause();
            pauseMenu.Play();
        }

        private void HandleEvents()
        {
            this.window.DispatchEvents();
        }

        private void UpdateScore()
        {
            TextManager.TypeText("Score: ", ScoreManager.score, 45, Color.White, new Vector2f(10f, 10f));
        }

        private void UpdateHealth()
        {
            TextManager.TypeText("Health: ", player.Health, 45, Color.Red, new Vector2f(300f, 10f));
        }

        private void Update() 
        {
            this.UpdateScore();
            this.UpdateHealth();
            this.player.Update();
            this.enemies.Update(this.player);
            AnimationManager.Update();
        }

        private void Draw() 
        {
            this.window.Clear(Color.Blue);
            this.window.Draw(this.background); 
            this.player.Draw(this.window);
            this.enemies.Draw(this.window);
            AnimationManager.Draw(this.window);
            TextManager.Draw(this.window);
            this.window.Display();
        }
        
        
    }
}