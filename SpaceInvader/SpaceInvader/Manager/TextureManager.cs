using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace SpaceInvader
{
    class TextureManager
    {
        private static string ASSETS_PATH = "Assets/Textures/";
        private static string UI_PATH = "Assets/Textures/UI/";
        private static string EXPLOSION_ASSETS_PATH = "Assets/Textures/explosions/";

        static Texture playerTexture;
        static Texture enemyTexture;
        static Texture backgroundTexture;
        static Texture menuBackgroundTexture;
        static Texture title;
        static Texture score;
        static Texture highScore;
        static Texture loseTitle;
        static Texture credits;
        static Texture controls;
        static List<Texture> explosionTextures = new List<Texture>(); 

        public static Texture MenuBackgroundTexture { get {return menuBackgroundTexture; } }
        public static Texture PlayerTexture { get {return playerTexture; } }
        public static Texture EnemyTexture { get {return enemyTexture; } }
        public static Texture Title { get {return title; } }
        public static Texture BackgroundTexture { get {return backgroundTexture; } }
        public static Texture Score { get {return score; } }
        public static Texture HighScore { get {return highScore; } }
        public static Texture LoseTitle { get {return loseTitle; } }
        public static Texture Credits { get {return credits; } }
        public static Texture Controls { get {return controls; } }

        public static List<Texture> ExplosionTextures { get { return explosionTextures; } }

        public static void LoadGameTexture()
        {
            playerTexture = new Texture(ASSETS_PATH + "Player-Ship.png");
            enemyTexture = new Texture(ASSETS_PATH + "Enemy Mantis.png");
            backgroundTexture = new Texture(ASSETS_PATH + "Nebula BackGround.png");
            
            for (int i = 0; i < 8 ; i++)
            {
                explosionTextures.Add(new Texture(EXPLOSION_ASSETS_PATH + "explosion-00" + i.ToString() +".png"));
            }
        }

        public static void LoadMainMenuTexture()
        {
            menuBackgroundTexture = new Texture(UI_PATH + "Menu-Background.png");
            title = new Texture(UI_PATH + "Title.png");
        }
        
        public static void LoadPauseMenuTexture()
        {
            menuBackgroundTexture = new Texture(UI_PATH + "Menu-Background.png");
        }

        public static void LoadDefeatMenuTexture()
        {
            menuBackgroundTexture = new Texture(UI_PATH + "Menu-Background.png");
            score = new Texture(UI_PATH + "Score.png");
            highScore = new Texture(UI_PATH + "Record.png");
            loseTitle = new Texture(UI_PATH + "Header.png");
        }
        
        public static void LoadCreditsMenuTexture()
        {
            menuBackgroundTexture = new Texture(UI_PATH + "Menu-Background.png");
            credits = new Texture(UI_PATH + "Credits - Screen.png");
            controls = new Texture(UI_PATH + "Tutorial - Screen.png");
        }
    }
}