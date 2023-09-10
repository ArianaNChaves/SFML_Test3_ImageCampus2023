using System;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;

namespace SpaceInvader
{
    class MainMenu : LoopState
    {
        Button gameStart;
        Button quit;
        Button credits;
        Sprite menuBackground;
        Sprite title;
        public MainMenu(RenderWindow window) : base (window)
        { 
            this.window = window;
            TextureManager.LoadMainMenuTexture();
        }

        protected override void Start()
        {
            base.Start();
            
            
            menuBackground = new Sprite();
            menuBackground.Texture = TextureManager.MenuBackgroundTexture;
            title = new Sprite();
            title.Texture = TextureManager.Title;
            title.Position = new Vector2f(175f, 5f);
            
            gameStart = new Button(window, new Vector2f(500, 750),  "Assets/Textures/UI/Play-Button.png");
            quit = new Button(window, new Vector2f(900, 750),  "Assets/Textures/UI/Exit-Button.png");
            credits = new Button(window, new Vector2f(100, 750), "Assets/Textures/UI/Credits-Button.png");
            
            gameStart.Pressed += OnStartPressed;
            quit.Pressed += OnQuitPressed;
            credits.Pressed += OnCreditsPressed;
        }

        private void OnStartPressed() 
        {
            StateManager.LoadScene(StateManager.SceneType.Game);
        }

        private void OnCreditsPressed()
        {
            StateManager.LoadScene(StateManager.SceneType.CreditsMenu);
        }
        private void OnQuitPressed() {
            
            Stop();
            window.Close();
        }

        protected override void Update(float deltaTime)
        {
            gameStart.Update();
            quit.Update();
            credits.Update();
        }
        protected override void Draw() 
        {
            window.Draw(menuBackground);
            window.Draw(title);
            gameStart.Draw();
            quit.Draw();
            credits.Draw();

            window.Display();
        }
        public override void Stop()
        {
            gameStart.Pressed -= OnStartPressed;
            quit.Pressed -= OnQuitPressed;
            gameStart.KillButton();
            quit.KillButton();
            credits.KillButton();
            base.Stop();
        }
        protected override void Finish()
        {
            base.Finish();
        }
    }
}
