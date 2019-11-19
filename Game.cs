using System.Collections;
using System.Collections.Generic;
using Assets.Code;
using UnityEngine;

public interface IManager
{
    void GameStart ();
    void GameLose ();
    void GameWin();
}

public class Game : MonoBehaviour
{
    public static Game Ctx;
    public ScoreManager Score { get; private set; }
    public EndGameManager EndGame { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Ctx = this;
        Score = new ScoreManager();
        EndGame = new EndGameManager();
        Score.GameStart();
        EndGame.GameStart();
    }
    
}
