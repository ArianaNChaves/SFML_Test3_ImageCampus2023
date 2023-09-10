using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
using SpaceInvader.Utilities;

namespace SpaceInvader

{
    class Enemy 
    {
        private readonly Random random = new Random();
        private Sprite sprite;
        public const float ENEMY_SPEED = 5f;
        Vector2f position;
        private SoundEffect death;

        public Sprite EnemySprite { get { return sprite; } }
        public Vector2f Position { get { return position; } }


        public Enemy () 
        {
            this.sprite = new Sprite();
            this.sprite.Texture = TextureManager.EnemyTexture;
            this.position.X = (float)this.random.Next(15, 1300);
            this.position.Y = -(float)this.random.Next(0, 920);
            this.sprite.Position = this.position;
            death = new SoundEffect("Assets/Music/EnemyDeath.wav",4f);
        }

        public void PlayDeathSound()
        {
            death.Play();
        }

        public void Update() {
            this.position.Y += ENEMY_SPEED;
            this.sprite.Position = this.position;
        }

        public void Draw(RenderTarget window) 
        {
            window.Draw(this.sprite);           
        }
    }
}