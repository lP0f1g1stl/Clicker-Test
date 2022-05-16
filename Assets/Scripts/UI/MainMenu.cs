using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _upgradesList;
    [SerializeField] private GameObject _acceptExit;
    [Space]
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _upgradeButton.onClick.AddListener(ShowUpgrades);
        _exitButton.onClick.AddListener(ShowExitMenu);
    }
    public void ShowUpgrades() 
    {
        _upgradesList.SetActive(!_upgradesList.activeSelf);
    }

    public void ShowExitMenu() 
    {
       _acceptExit.SetActive(!_acceptExit.activeSelf);
    }
}
