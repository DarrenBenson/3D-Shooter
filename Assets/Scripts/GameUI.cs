using UnityEngine;

public class GameUI : MonoBehaviour
{

    [SerializeField] private GameObject _playButton;
    private bool _isPanelVisible = true;

    private void OnEnable()
    {
        GameEventManager.OnStartGame += HidePanel;
    }

    private void OnDisable()
    {
        GameEventManager.OnStartGame -= HidePanel;
    }

    private void HidePanel()
    {
        _isPanelVisible = !_isPanelVisible;
        _playButton.SetActive(_isPanelVisible);
    }

    public void PlayGame()
    {
        GameEventManager.StartGame();
    }

}
