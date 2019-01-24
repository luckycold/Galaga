using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Galaga
{
    class Background : Microsoft.Xna.Framework.Game
    {
        Rectangle rect;
        Color color;
        Random rand;
        int posX, posY, speed, r, g, b;
        

        public Background()
        {
            rand = new Random();
            posX = rand.Next(224*3);//make sure to check screen resolution
            posY = rand.Next(288*3);
            rect = new Rectangle(posX, posY, 3, 3);
            r = rand.Next(255);
            g = rand.Next(255);
            b = rand.Next(255);
            color = new Color(r, g, b);
            speed = rand.Next(1, 2);
        }
        public void starMove()
        {
            posY += speed;
            if (posY >= 288*3)
                posY = 0;
        }
        public int getPosX()
        {
            return posX;
        }
        public int getPosY()
        {
            return posY;
        }
        public int getWidth()
        {
            return rect.Width;
        }
        public int getHeight()
        {
            return rect.Height;
        }
        public Color getColor()
        {
            return color;
        }
    }
}