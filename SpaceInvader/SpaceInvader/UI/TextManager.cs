﻿using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace SpaceInvader
{
    class TextManager
    {
        private const string FONT_PATH = "Assets/Fonts/";
        public static Font font;
        private static List<Text> texts = new List<Text>();
        public static void loadFont(string fontFamily) 
        {
            font = new Font(FONT_PATH + fontFamily + ".ttf"); 
        }
        public static void TypeText(string text, int value, uint fontSize, Color fontColor, Vector2f position)
        {
            Text textContent = new Text(text + value.ToString(), font, fontSize);
            textContent.Position = position;
            textContent.FillColor = fontColor;
            texts.Add(textContent);
        }
        public static void TypeString(string text, uint fontSize, Color fontColor, Vector2f position)
        {
            Text textContent = new Text(text, font, fontSize);
            textContent.Position = position;
            textContent.FillColor = fontColor;
            texts.Add(textContent);
        }
        public static void Draw(RenderTarget window) 
        {
            for (int i = 0; i < texts.Count; i++)
            {
                window.Draw(texts[i]);
                texts.Remove(texts[i]);
            }
        }

    }
}