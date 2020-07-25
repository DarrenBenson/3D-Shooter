﻿using UnityEngine;

public class GameUI : MonoBehaviour
{

    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _playerSpawner;

    private void OnEnable()
    {
        GameEventManager.OnStartGame += ShowGameUI;
        GameEventManager.OnPlayerDestroyed += ShowMainMenu;
    }

    private void OnDisable()
    {
        GameEventManager.OnStartGame -= ShowGameUI;
        GameEventManager.OnPlayerDestroyed -= ShowMainMenu;
    }

    private void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        _mainMenu.SetActive(true);
        _gameUI.SetActive(false);
    }

    private void ShowGameUI()
    {
        _mainMenu.SetActive(false);
        _gameUI.SetActive(true);
        Instantiate(_playerPrefab, _playerSpawner.transform.position, _playerSpawner.transform.rotation);
    }

}
