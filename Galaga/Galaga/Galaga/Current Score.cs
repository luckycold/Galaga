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
    class Current_Score
    {
        String scoreText;
        int scoreNumber, enemiesDestroyed, numberOfShots, numberOfHits;
        double accuracy;

        public Current_Score()
        {
            scoreText = "1UP";
            scoreNumber = 0;
            accuracy = 0;
            numberOfShots = 0;
            numberOfHits = 0;
        }

        public void playerShot()
        {
            numberOfShots++;
        }

        public void enemyDestroyed() //Might need to change according to different types of enemies
        {
            scoreNumber += 50;
            enemiesDestroyed++;
        }

        public void enemyHit()
        {
            numberOfHits++;
        }

        public void fourthStageBonus()
        {
            numberOfHits *= 100;
            scoreNumber += numberOfHits;
        }

        public void gameOver()
        {
            scoreNumber = 0;
        }

        public int getShotsFired()
        {
            return numberOfShots;
        }

        public int getHits()
        {
            return numberOfHits;
        }

        public double getAccuracy()
        {
            //accuracy = numberOfHits / numberOfShots;
            return accuracy;
        }

        public String getCurrentScoreText()
        {
            return scoreText;
        }

        public int getCurrentScore()
        {
            return scoreNumber;
        }
    }
}
