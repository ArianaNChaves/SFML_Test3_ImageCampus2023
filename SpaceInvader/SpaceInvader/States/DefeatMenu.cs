using SFML.Graphics;
using SFML.System;

namespace SpaceInvader;

public class DefeatMenu : LoopState
{
    private Sprite defeatMenuBackground;
    private Sprite title;
    private Sprite score;
    private Sprite record;
    private Button exit;
    
    public DefeatMenu(RenderWindow window) : base(window)
    {
        this.window = window;
        TextureManager.LoadDefeatMenuTexture();
    }
    protected override void Start()
    {
        base.Start();
        defeatMenuBackground = new Sprite();
        defeatMenuBackground.Texture = TextureManager.MenuBackgroundTexture;

        score = new Sprite();
        score.Texture = TextureManager.Score;
        score.Position = new Vector2f(450, 300);

        record = new Sprite();
        record.Texture = TextureManager.HighScore;
        record.Position = new Vector2f(450, 500);

        exit = new Button(window, new Vector2f(500, 800), "Assets/Textures/UI/Exit-Button.png");
        exit.Pressed += OnBackToMenu;
        TextManager.loadFont("ethnocentric");
        
        title = new Sprite();
        title.Texture = TextureManager.LoseTitle;
        title.Position = new Vector2f(450, 25);
        
        ScoreManager.UpdateScore();
    }
    private void OnBackToMenu()
    {
        StateManager.LoadScene(StateManager.SceneType.MainMenu);
        Stop();
    }
    private void UpdateScore()
    {
        TextManager.TypeText("", ScoreManager.score, 50, Color.White, new Vector2f(800, 285));
    }

    private void UpdateRecord()
    {
        TextManager.TypeText("", ScoreManager.highscore, 50, Color.White, new Vector2f(800, 485));
    }
    protected override void Update(float deltaTime)
    {
        this.UpdateRecord();
        this.UpdateScore();
        this.exit.Update();
    }
    
    public override void Stop()
    {
        exit.Pressed -= OnBackToMenu;
        exit.KillButton();
        base.Stop();
    }
    protected override void Draw()
    {
        window.Draw(defeatMenuBackground);
        window.Draw(title);
        window.Draw(score);
        window.Draw(record);
        exit.Draw();
        TextManager.Draw(this.window);
        
        window.Display();
    }
    
   

}