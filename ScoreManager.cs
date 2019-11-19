﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class ScoreManager : IManager
    {
        private readonly Text _scoreText;
        private static int _score;

        public ScoreManager () {
            _scoreText = GameObject.Find("Score").GetComponent<Text>();
            UpdateScore();
        }

        public void GameStart () {
            _scoreText.enabled = true;
            _score = 0;
        }

        public void GameLose () {
            _scoreText.enabled = false;
        }

        public void GameWin()
        {
            _scoreText.enabled = true;
        }

        public void IncreaseScore (int value) {
            _score += value;
            UpdateScore();
        }

        private void UpdateScore () {
            _scoreText.text = String.Format("Score: {0:000}", _score);
        }


    }
}
