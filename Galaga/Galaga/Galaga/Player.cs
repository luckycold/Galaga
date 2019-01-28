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
    class Player
    {
        Texture2D tex;
        Rectangle rect;
        double playerSpeed, xPos, yPos, seconds, startShotTime;
        int timer = 0, playerMissilesFired = 0;
        bool fireCooldown;
        
        public Player()
        {
            tex = null;
            rect = new Rectangle();
            xPos = 0;
            yPos = 0;
        }

        public Player(Texture2D texture, Rectangle rectangle)
        {
            tex = texture;
            rect = rectangle;
            xPos = rect.X;
            yPos = rect.Y;
            playerSpeed = 7;
        }

        public Texture2D Texture
        {
            get { return tex; }
            set { tex = value; }
        }

        public Rectangle Rectangle
        {
            get { return rect; }
            set { rect = value; }
        }

        public void moveLeft()
        {
            xPos -= playerSpeed;
        }

        public void moveRight()
        {
            xPos += playerSpeed;
        }

        public void shoot()
        {
            if (seconds >= startShotTime + 1)
                fireCooldown = false;
            if (!fireCooldown)
            {
                startShotTime = seconds;
                playerMissilesFired++;
                //todo Make missiles work
            }
        }

        public void explode()
        {
            //todo Use explosion animation
        }

        public void update()
        {
            timer++;
            seconds = timer / 60;
            rect = new Rectangle((int)xPos, (int)yPos, rect.Width, rect.Height);
        }
    }
}
