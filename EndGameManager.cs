using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class EndGameManager : IManager
    {
        private readonly Text _loseText;
        private readonly Text _winText;

        public EndGameManager()
        {
            _loseText = GameObject.Find("Game Over").GetComponent<Text>();
            _winText = GameObject.Find("Win").GetComponent<Text>();

        }

        public void GameStart()
        {
            _loseText.enabled = false;
            _winText.enabled = false;
        }

        public void GameLose()
        {
            _loseText.enabled = true;
        }

        public void GameWin()
        {
            _winText.enabled = true;
        }
        
        
        
    }
}
