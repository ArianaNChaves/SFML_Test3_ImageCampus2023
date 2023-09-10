using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
namespace SpaceInvader

{
    class AnimationManager
    {
        private static List<Animation> animations = new List<Animation>();

        public static List<Animation> Animations { get { return animations; } }

        public static void Update()
        {
            for (int i = 0; i < animations.Count; i++)
            {
                if (animations[i].DestroyIt) 
                {
                    animations.Remove(animations[i]);
                }
                else
                {
                    animations[i].Update();
                }
            }
        }

        public static void Draw(RenderTarget window) 
        {
            for (int i = 0; i < animations.Count; i++)
            {
                animations[i].Draw(window);
            }
        }
    }
}