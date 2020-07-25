using UnityEngine;

public class GameEventManager : MonoBehaviour
{

    public delegate void StartGameDelegate();
    public static StartGameDelegate OnStartGame;
    public static StartGameDelegate OnPlayerDestroyed;

    public delegate void UpdateHealthBarDelegate(float percentDamage);
    public static UpdateHealthBarDelegate OnUpdateHealthBar;    
    

    public static void StartGame()
    {
        if(OnStartGame != null) // Check for subscribers
        {
            OnStartGame();
        }
    }

    public static void UpdateHealthBar(float percentDamage)
    {
        if (OnUpdateHealthBar != null) // Check for subscribers
        {
            OnUpdateHealthBar(percentDamage);
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
