using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace SpaceInvader
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoMode videoMode = new VideoMode(1400, 920);
            string title = "Survive in space";
            RenderWindow renderWindow = new RenderWindow(videoMode, title);
            StateManager.Initialize(renderWindow);
            StateManager.LoadScene(StateManager.SceneType.MainMenu);
        }
    }
}