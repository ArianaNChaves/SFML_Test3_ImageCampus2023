using System;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;
using System.Collections.Generic;
using SpaceInvader;

namespace SpaceInvader
{
    static public class StateManager
    {
        static private GameLoop gameLoop;
        static private MainMenu menu;
        static private PauseMenu pauseMenu;
        static private DefeatMenu defeatMenu;
        static private CreditsMenu creditsMenu;
        static private List<LoopState> scenes = new List<LoopState>();
        static private LoopState currentScene = null;

        public enum SceneType
        {
            MainMenu, //0
            Game, //1
            PauseMenu, //2
            DefeatMenu, //3
            CreditsMenu, //4
        }
        static public void Initialize(RenderWindow window)
        {
            menu = new MainMenu(window);
            gameLoop = new GameLoop(window);
            pauseMenu = new PauseMenu(window);
            defeatMenu = new DefeatMenu(window);
            creditsMenu = new CreditsMenu(window); 
            
            scenes.Add(menu);
            scenes.Add(gameLoop);
            scenes.Add(pauseMenu);
            scenes.Add(defeatMenu);
            scenes.Add(creditsMenu);
        }
        static public void LoadScene(SceneType sceneType)
        {
            if (currentScene != null)
            {
                Console.WriteLine("CERRANDO LA ESCENA " + currentScene);
                currentScene.Stop(); // Terminar la escena anterior
            }

            currentScene = scenes[Convert.ToInt32(sceneType)]; // Cambio la escena
            Console.WriteLine("CARGANDO NUEVA ESCENA " + currentScene);
            currentScene.Play(); // Le doy play a la nueva escena
        }
        static public LoopState GetScene(SceneType sceneType)
        {
            return scenes[Convert.ToInt32(sceneType)];
        }
        
    }
}