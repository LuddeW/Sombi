using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Sombi
{
    class HighscoreManager
    {
        public static int score;
        List<int> highScores;

        public List<int> HighScores
        {
            get { return highScores; }
            set { }
        }

        public HighscoreManager()
        {
            LoadContent();
        }

        private void LoadContent()
        {
            score = 0;
            highScores = new List<int>();
        }

        public void Update()
        {

        }

        public void WriteScore()
        {
            string textScore = score.ToString();
            StreamWriter file = new StreamWriter(@"Content\Highscore.txt");
            file.WriteLine(textScore);
            file.Close();
        }

        public void ReadScore()
        {
            StreamReader file = new StreamReader(@"Content\Highscore.txt");
            while (!file.EndOfStream)
            {
                string test = file.ReadLine();
                int testInt = Int32.Parse(test);
                highScores.Add(testInt);
            }
            file.Close();
        }
    }
}
