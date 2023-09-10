using SFML.Graphics;
using SFML.System;

namespace SpaceInvader;

public class CreditsMenu : LoopState
{
    private Sprite menuBackground;
    private Sprite credits;
    private Sprite controls;
    private Button exit;
    
    public CreditsMenu(RenderWindow window) : base(window)
    {
        this.window = window;
        TextureManager.LoadCreditsMenuTexture();
    }

    protected override void Start()
    {
        base.Start();
        menuBackground = new Sprite();
        menuBackground.Texture = TextureManager.MenuBackgroundTexture;

        credits = new Sprite();
        credits.Texture = TextureManager.Credits;
        credits.Position = new Vector2f(730, 2);

        controls = new Sprite();
        controls.Texture = TextureManager.Controls;
        controls.Position = new Vector2f(100, 2);
        
        exit = new Button(window, new Vector2f(500, 800), "Assets/Textures/UI/Exit-Button.png");
        exit.Pressed += OnBackToMenu;
        
        TextManager.loadFont("ethnocentric");
    }

    private void UpdateText()
    {
        TextManager.TypeString("Kill enemies to gain points", 30, Color.White, new Vector2f(400,675));
        TextManager.TypeString("If they reach the bottom of the screen, you lose points", 30, Color.White, new Vector2f(35,725));
    }
    
    private void OnBackToMenu()
    {
        StateManager.LoadScene(StateManager.SceneType.MainMenu);
        Stop();
    }
    
    protected override void Update(float deltaTime)
    {
        exit.Update();
        UpdateText();
    }
    protected override void Draw()
    {
        window.Draw(menuBackground);
        window.Draw(credits);
        window.Draw(controls);
        exit.Draw();
        TextManager.Draw(window);
        
        window.Display();
    }
    public override void Stop()
    {
        exit.Pressed -= OnBackToMenu;
        exit.KillButton();
        base.Stop();
    }
}