using System;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;

namespace SpaceInvader

{
    class EnemyManager
    {
        public List<Enemy> enemies = new List<Enemy>();
        public DefeatMenu defeatMenu;
        private int maxEnemies = 3;
        private int damage = 5;
        public void Update(Player player) 
        {
            if (enemies.Count < maxEnemies){
                for (int i = 0; i < (maxEnemies-1) - enemies.Count; i++)
                {
                    enemies.Add(new Enemy());
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update();
                if (enemies[i].Position.Y > 920)
                {
                    if (ScoreManager.score > 0)
                    {
                        ScoreManager.score -= damage;
                    }
                    AnimationManager.Animations.Add(new Animation(TextureManager.ExplosionTextures, enemies[i].Position));
                    enemies.Remove(enemies[i]);
                }else if (Collisions(enemies[i], player))
                {
                    AnimationManager.Animations.Add(new Animation(TextureManager.ExplosionTextures, enemies[i].Position));
                    enemies[i].PlayDeathSound();
                    enemies.Remove(enemies[i]);
                    if (maxEnemies < 15)
                    {
                        maxEnemies++;
                    }
                    else
                    {
                        damage = 10;
                    }
                }
            }
        }

        public bool Collisions(Enemy enemy, Player player)
        {
            if (player.PlayerSprite.GetGlobalBounds().Intersects(enemy.EnemySprite.GetGlobalBounds()))
            {
                player.Health -= 20;
                if (player.Health <= 0)
                {
                    player.PlayDeathSound();
                    GameLoop.gameMusic.Stop();
                    StateManager.LoadScene(StateManager.SceneType.DefeatMenu);
                }
                return true;
            }
            for (int i = 0; i < player.bullets.Count; i++)
            {
                if (enemy.EnemySprite.GetGlobalBounds().Intersects(player.bullets[i].RectangleBullet.GetGlobalBounds()))
                {
                    ScoreManager.score += 10;
                    player.bullets.Remove(player.bullets[i]);
                    return true;
                }
            } 
            return false;
        }
        public void Draw(RenderTarget window)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(window);
            }
        }
    }
}