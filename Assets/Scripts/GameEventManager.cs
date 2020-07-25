using UnityEngine;

public class GameEventManager : MonoBehaviour
{

    public delegate void StartGameDelegate();
    public static StartGameDelegate OnStartGame;

    public static void StartGame()
    {
        Debug.Log("StartGame");
        if(OnStartGame != null) // Check for subscribers
        {
            OnStartGame();
        }
    }

}
