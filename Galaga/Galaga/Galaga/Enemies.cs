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
    class Enemies
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int xVel;
        int yVel;
        Rectangle enemyPos;
        Rectangle wereToGo;
        int formation;
        Texture2D text;
        public Enemies(int ran)
        {
            formation = ran;
        }
        public void createEnemies()
        {
            Enemy[] row1 = new Enemy[5];
            for (int i = 0; i < row1.Length; i++)
            {
                wereToGo = new Rectangle(100,100,(224 * 3) - enemyPos.X,1);
                row1[i] = new Enemy(wereToGo, 0, text , enemyPos);

            }
        }
    }
}
