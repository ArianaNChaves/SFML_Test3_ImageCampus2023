using System;
using SFML.System;
using SFML.Graphics;

namespace SpaceInvader
{
    public class PauseMenu : LoopState
    {
        Button keepPlaying;
        Button backToMenu;
        Sprite pauseMenuBackground;
        public PauseMenu(RenderWindow window) : base(window)
        {
            this.window = window;
            TextureManager.LoadPauseMenuTexture();
        }
        protected override void Start()
        {
            base.Start();
            pauseMenuBackground = new Sprite();
            pauseMenuBackground.Texture = TextureManager.MenuBackgroundTexture;
            
            keepPlaying = new Button(window, new Vector2f(500, 350), "Assets/Textures/UI/Resume-Button.png");
            backToMenu = new Button(window, new Vector2f(500, 550), "Assets/Textures/UI/Exit-Button.png");

            keepPlaying.Pressed += OnKeepPlaying;
            backToMenu.Pressed += OnBackToMenu;

        }
        private void OnKeepPlaying()
        {
            StateManager.GetScene(StateManager.SceneType.Game).Resume();
            GameLoop.gameMusic.Play();
            Stop();
        }
        private void OnBackToMenu()
        {
            keepPlaying.Pressed -= OnKeepPlaying;
            backToMenu.Pressed -= OnBackToMenu;
            keepPlaying.KillButton();
            backToMenu.KillButton();
            GameLoop.gameMusic.Stop();
            StateManager.LoadScene(StateManager.SceneType.MainMenu);
            Stop();
        }
        protected override void Draw()
        {
            window.Draw(pauseMenuBackground);
            keepPlaying.Draw();
            backToMenu.Draw();
            window.Display();
        }
        public override void Stop()
        {
            keepPlaying.Pressed -= OnKeepPlaying;
            backToMenu.Pressed -= OnBackToMenu;
            keepPlaying.KillButton();
            backToMenu.KillButton();
            base.Stop();
        }
        protected override void Update(float deltaTime)
        {
            keepPlaying.Update();
            backToMenu.Update();
        }
    }
}