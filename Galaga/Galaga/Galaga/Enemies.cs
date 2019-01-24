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
        Enemy[] row3;
        Enemy[] row2;
        Enemy[] row1;
        public Enemies(Texture2D a)
        {
            createEnemies();
            text = a;
        }
        public void createEnemies()
        {
            row1 = new Enemy[5];
            row2 = new Enemy[5];
            row3 = new Enemy[5];
            for (int row = 0; row < 4; row++)
            {
                for (int i = 0; i < row1.Length; i++)
                {
                    wereToGo = new Rectangle(100, 100, (224 * 3) - 100 * i, 1 + 100 * row);
                    enemyPos = new Rectangle(100, 100, -100 - 100 * i, 1);
                    row1[i] = new Enemy(wereToGo, 0, text, enemyPos);

                }
            }
        }
        public void move()
        {
            bool a = true;
                for (int i = 0; i < row1.Length; i++)
                {
                row1[i].Move();
                    row2[i].Move();
                row3[i].Move();
                
                if (row1[i] != null)
                    a = false;
                if (row2[i] != null)
                    a = false;
                if (row3[i] != null)
                    a = false;
            }
            if (a)
                createEnemies();
        }
     }
    }

