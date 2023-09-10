using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
using SpaceInvader.Utilities;

namespace SpaceInvader
 {
    class Player 
    {
        private int delay = 0;
        private Sprite sprite;
        public const float PLAYER_SPEED = 11f;
        
        static public int recordScore;
        private SoundEffect shoot;
        private SoundEffect death;
        private int health = 100;

        Vector2f position = new Vector2f(310, 460);
        public List<Bullet> bullets = new List<Bullet>();
        public Sprite PlayerSprite { get { return sprite; } }
      
        public int Health { get { return health; } set { health = value; } }

        public Player () 
        {
            sprite = new Sprite();
            sprite.Position = position;
            sprite.Texture = TextureManager.PlayerTexture;
            shoot = new SoundEffect("Assets/Music/Shot.wav", 15f);
            death = new SoundEffect("Assets/Music/Game over.wav", 10f);
            ScoreManager.score = 0;
        }
        public void Movement()
        {
            bool moveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool moveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool moveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
            bool moveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);

            bool isMove = moveLeft || moveRight || moveUp || moveDown;

            if(isMove)
            {
                if(moveLeft) position.X -= PLAYER_SPEED;
                if(moveRight) position.X += PLAYER_SPEED;
                if(moveUp) position.Y -= PLAYER_SPEED;
                if(moveDown) position.Y += PLAYER_SPEED;
            }

            bool isFire = Mouse.IsButtonPressed(Mouse.Button.Left);
            if(isFire) this.Shoot();   
        }
        private void Shoot()
        {
            this.delay++;
            if ( this.delay >= 15 )
            {
                shoot.Play();
                var positionOfFirstBullet = new Vector2f(this.position.X + 47, this.position.Y);
                this.bullets.Add(new Bullet(positionOfFirstBullet));
                var positionOfSecondBullet = new Vector2f(positionOfFirstBullet.X + 25, positionOfFirstBullet.Y);
                this.bullets.Add(new Bullet(positionOfSecondBullet));
                this.delay = 0;
            }
        }
        public void Update() {
            this.Movement();
            this.sprite.Position = position;

            for (int i = 0; i < this.bullets.Count; i++) {
                this.bullets[i].Update();
                if (this.bullets[i].Position.Y < 0) 
                {
                    this.bullets.Remove(this.bullets[i]);
                }
            }
        }
        public void Draw(RenderTarget window) 
        {
            window.Draw(this.sprite);
            foreach (var bullet in this.bullets)
            {
                window.Draw(bullet.RectangleBullet);    
            }
        }

        public void PlayDeathSound()
        {
            death.Play();
        }
    }
}