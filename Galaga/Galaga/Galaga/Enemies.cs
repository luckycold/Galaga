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
            row1 = new Enemy[6];
            row2 = new Enemy[6];
            row3 = new Enemy[6];
                for (int i = 0; i <6; i++)
                {
                    wereToGo = new Rectangle((224 * 3) - 110 * (i + 1), 100, 100, 100);
                    enemyPos = new Rectangle(-100 - 100 * (i + 1), 100,100,100);
                    row1[i] = new Enemy(wereToGo, text, enemyPos);
                    wereToGo = new Rectangle(0 + 110 * i , 2 + 200,100,100 );
                    enemyPos = new Rectangle((224 * 3) + 100 * (i + 1), 2 + 200,100,100);
                    row2[i] = new Enemy(wereToGo, text, enemyPos);
                    wereToGo = new Rectangle((224 * 3) - 110 * (i + 1), 3 + 300,100,100);
                    enemyPos = new Rectangle(-100 - 100 * (i + 1), 3 + 300,100,100);
                    row3[i] = new Enemy(wereToGo, text, enemyPos);

                }
        }
        public List<Rectangle> move()
        {
            List<Rectangle> eLoc = new List<Rectangle>();
            bool a = true;
                for (int i = 0; i < row1.Length; i++)
                {
                row1[i].Move();
                eLoc.Add(row1[i].getPos());
                row2[i].Move();
                eLoc.Add(row2[i].getPos());
                row3[i].Move();
                eLoc.Add(row3[i].getPos());
                if (row1[i] != null)
                    a = false;
                if (row2[i] != null)
                    a = false;
                if (row3[i] != null)
                    a = false;
            }
            if (a)
                createEnemies();
            return eLoc;
        }
     }
    }

