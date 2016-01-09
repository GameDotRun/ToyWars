using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyWars
{
    class Background
    {
        // Class Variables
        private Texture2D m_image;
        private Rectangle m_imageRect;

        // Constructor
        public Background(Texture2D image)
        {
            m_image = image;
            m_imageRect = new Rectangle(0, 0, GameRoot.WIDTH, GameRoot.HEIGHT);
        }

        // Draw
        public void Draw(SpriteBatch sb)
        {
            // Draw image covering entire Game View.
            sb.Draw(m_image, m_imageRect, Color.White);
        }
    }
}
