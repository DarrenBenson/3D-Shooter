using UnityEngine;

public class GameEventManager : MonoBehaviour
{

    public delegate void StartGameDelegate();
    public static StartGameDelegate OnStartGame;
    public delegate void TakeDamageDelegate(float percentDamage);
    public static TakeDamageDelegate OnTakeDamage;

    public static void StartGame()
    {
        if(OnStartGame != null) // Check for subscribers
        {
            OnStartGame();
        }
    }

    public static void TakeDamage(float percentDamage)
    {
        if (OnTakeDamage != null) // Check for subscribers
        {
            OnTakeDamage(percentDamage);
        }
    }

}
