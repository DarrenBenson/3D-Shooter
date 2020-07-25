using UnityEngine;

public class GameEventManager : MonoBehaviour
{

    public delegate void StartGameDelegate();
    public static StartGameDelegate OnStartGame;
    public static StartGameDelegate OnPlayerDestroyed;

    public delegate void UpdateGameUIDelegate(int amount);
    public static UpdateGameUIDelegate OnUpdateHealthBar;
    public static UpdateGameUIDelegate OnUpdateScore;


    public static void StartGame()
    {
        if(OnStartGame != null) // Check for subscribers
        {
            OnStartGame();
        }
    }

    public static void UpdateHealthBar(int percentHealthRemaining)
    {
        if (OnUpdateHealthBar != null) // Check for subscribers
        {
            OnUpdateHealthBar(percentHealthRemaining);
        }
    }

    public static void UpdateScore(int scoreAmount)
    {
        if (OnUpdateScore != null) // Check for subscribers
        {
            OnUpdateScore(scoreAmount);
        }
    }

    public static void PlayerDestroyed()
    {
        if (OnPlayerDestroyed != null) // Check for subscribers
        {
            OnPlayerDestroyed();
        }
    }


}
