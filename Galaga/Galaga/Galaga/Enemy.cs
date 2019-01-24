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
        int type;
        Texture2D tex;
        Texture2D hpDown;
        Texture2D currentTex;
        Vector2 hy;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Enemy(Rectangle wTG,int t,Texture2D tx,Rectangle enymiPs) 
        {
            wereToGo = wTG;
            type = t;
            tex = tx;
            enemyPos = enymiPs;
            currentTex = tx;
        }
        public Enemy(Rectangle wTG, int t, Texture2D tx,Texture2D hpD, Rectangle enymiPs)
        {
            wereToGo = wTG;
            type = t;
            tex = tx;
            enemyPos = enymiPs;
            hpDown = hpD;
            currentTex = tx;
        }
        public void Move()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(currentTex, enemyPos, Color.White);
            spriteBatch.End();
            if(enemyPos.X >= graphics.GraphicsDevice.Viewport.Width - enemyPos.Width && enemyPos.X != wereToGo.X)
            {
                enemyPos.X--;
            }
            if (enemyPos.X <= 0 && enemyPos.X != wereToGo.X)
            {
                enemyPos.X++;
            }
            if (enemyPos.Y <= 0 && enemyPos.Y != wereToGo.Y)
            {
                enemyPos.Y++;
            }
            if (enemyPos.Y >= graphics.GraphicsDevice.Viewport.Height - enemyPos.Height && enemyPos.Y != wereToGo.Y)
            {
                enemyPos.Y++;
            }
        }
        public Rectangle getPos()
        {
            return 
        }
    }
}

