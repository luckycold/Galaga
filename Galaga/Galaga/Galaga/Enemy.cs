using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Galaga
{
    class Enemy
    {
        int xVel;
        int yVel;
        Rectangle enemyPos;
        Rectangle wereToGo;
        Texture2D tex;
        Texture2D hpDown;
        Texture2D currentTex;
        Vector2 hy;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Enemy(Rectangle wTG,Texture2D tx,Rectangle enymiPs) 
        {
            wereToGo = wTG;
            tex = tx;
            enemyPos = enymiPs;
            currentTex = tx;
        }
        public Enemy(Rectangle wTG, Texture2D tx,Texture2D hpD, Rectangle enymiPs)
        {
            wereToGo = wTG;
            tex = tx;
            enemyPos = enymiPs;
            hpDown = hpD;
            currentTex = tx;
        }
        public void Move()
        {
            if(enemyPos.X > wereToGo.X )
            {
                enemyPos.X--;
            }
            if (enemyPos.X < wereToGo.X )
            {
                enemyPos.X++;
            }
            if (enemyPos.Y < wereToGo.Y)
            {
                enemyPos.Y++;
            }
            if (enemyPos.Y > wereToGo.Y)
            {
                enemyPos.Y--;
            }
        }
        public Rectangle getPos()
        {
            return enemyPos;
        }
    }
}

