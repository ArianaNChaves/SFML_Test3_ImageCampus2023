using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;

namespace SpaceInvader
{
    class Button
    {
        private RenderWindow window;
        private Sprite sprite;
        private bool beingHovered; 

        public event Action Pressed;
        public event Action Hover;

        public Button(RenderWindow window, Vector2f position, string imagePath)
        {
            this.window = window;
            sprite = new Sprite(new Texture(imagePath));
            sprite.Position = position;
            FloatRect limits = sprite.GetLocalBounds();
            beingHovered = false;
            window.MouseButtonReleased += OnMouseRelease;
            window.MouseMoved += OnMouseHover;
        }
        private void OnMouseRelease(object sender, MouseButtonEventArgs e)
        {
            FloatRect limits = sprite.GetGlobalBounds();
            if (limits.Contains(e.X, e.Y))
            {
                Pressed?.Invoke();
            }
        }
        private void OnMouseHover(object sender, MouseMoveEventArgs e)
        {
            FloatRect limits = sprite.GetGlobalBounds();
            if (limits.Contains(e.X, e.Y))
            {
                beingHovered = true;
                Hover?.Invoke();
            }
            else beingHovered = false;
        }
        
        public void SetSpriteColor(Color color)
        {
            sprite.Color = color;
        }
        public void Draw()
        {
            window.Draw(sprite);
        }
        public void KillButton()
        {
            window.MouseButtonReleased -= OnMouseRelease;
            window.MouseMoved -= OnMouseHover;
        }
        public void Update()
        {
            if(!beingHovered)
            {
                sprite.Color = Color.White;
            }
            else
            {
                sprite.Color = Color.Cyan;
            }
        }

    }
}
