using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ScoreSystem
{
    public class ScoreSystem : MonoBehaviour
    {
        public Text ScoreInGame;
        public Text ScoreInPanel;
        public Text Highscore;
        public static int ScoreValue = 0;
        private bool isHighScoreReached;
        private void Start()
        {
            ScoreInGame.GetComponent<Text>();
            ScoreInPanel.GetComponent<Text>();
            Highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        }
        private void Update()
        {
            ScoreInPanel.text = "Score : " + ScoreValue.ToString();
            ScoreInGame.text = "Score : " + ScoreValue.ToString();
            if (ScoreValue > PlayerPrefs.GetInt("HighScore", 0))
            {
                if (isHighScoreReached == false)
                {
                    isHighScoreReached = true;
                    Highscore.text = "High Score : " + ScoreValue.ToString();
                }
                PlayerPrefs.SetInt("HighScore", ScoreValue);
            }
        }
    }
}