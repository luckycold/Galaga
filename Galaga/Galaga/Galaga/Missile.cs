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
    class Missile
    {
        private float rotation;
        private Texture2D texture;
        private bool enemyMissile;
        private int velocity;
        private Rectangle missileRect;
        private Vector2 origin;

        //default constructor
        public Missile()
        {
            texture = null;
            rotation = 0;
            enemyMissile = false;
            velocity = 0;
            origin = new Vector2();
            missileRect = new Rectangle();
        }

        //constructor that contains parameters for texture, a bool determining if it was shot by an enemy or the player, a rectangle, and the vector2 for corresponding rotations
        public Missile(Texture2D texture, bool enemyMissile, Rectangle missileRect, Vector2 origin)
        {
            this.texture = texture;
            this.enemyMissile = enemyMissile;
            this.missileRect = missileRect;
            this.origin = origin;
            if (enemyMissile)
            {
                rotation = MathHelper.ToRadians(180);
                velocity = 15;
            }
            else
            {
                rotation = 0;
                velocity = -15;
            }
        }

        //property for the origin, used to draw the missile in the main
        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        //property for velocity
        public int Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        //property rectangle, used to draw the missile in the main
        public Rectangle Rectangle
        {
            get { return missileRect; }
            set { missileRect = value; }
        }

        //property for texture, used to draw the missile in the main
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        //property for rotation, which is either 0 or 180 depending on who fired it, used to draw the missile in the main
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        //accessor method returning a bool that is true if the missile was shot by an enemy; prevents missiles shot by player blowing player up
        public bool isEnemyMissile()
        {
            return enemyMissile;
        }

        //returns true if the missile is on screen, false if not; for cleaning up missiles that moved off screen
        public bool isOnScreen(GraphicsDeviceManager graphics)
        {
            return !(missileRect.Y + missileRect.Height <= 0 || missileRect.Y >= graphics.PreferredBackBufferHeight);
        }

        //movement of missile, use in update method of main
        public void update()
        {
            missileRect.Y += velocity;
        }
    }
}
