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
    class End_Screen
    {
        String gameOverText, resultText, shotsFired, numOfHits, hitMissRatio;
        Current_Score cs;
        public End_Screen()
        {
            gameOverText = "Game Over";
            resultText = "-RESULTS-";

            cs = new Current_Score();
            shotsFired = "SHOTS FIRED           " + cs.getShotsFired();
            numOfHits = "NUMBER OF HITS        " + cs.getHits();
            hitMissRatio = "HIT-MISS RATIO        " + cs.getAccuracy();
        }

        public String getGameOver()
        {
            return gameOverText;
        }

        public String getResult()
        {
            return resultText;
        }

        public String getShotsFired()
        {
            return shotsFired;
        }

        public String getNumOfHits()
        {
            return numOfHits;
        }

        public String getHitMissRatio()
        {
            return hitMissRatio;
        }
        
    }
}
