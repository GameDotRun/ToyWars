using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyWars
{
    static class Art
    {
        // Class Variables used to store Texture and Font data.
        public static Texture2D Background { get; private set; }

        public static SpriteFont DebugFont { get; private set; }


        public static void Load(ContentManager content)
        {
            // Load Images
            Background = content.Load<Texture2D>("Art/Images/Background");
            // Load Fonts
            DebugFont = content.Load<SpriteFont>("Art/Fonts/DebugFont");
        }
    }
}
