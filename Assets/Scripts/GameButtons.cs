using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _upgradesList;
    [SerializeField] private GameObject _acceptExit;

    public void ShowUpgrades() 
    {
        _upgradesList.SetActive(!_upgradesList.activeSelf);
    }

    public void Exit(int commId) 
    {
        switch(commId)
        {
            case 0:
                _acceptExit.SetActive(!_acceptExit.activeSelf);
                break;
            case 1:
                Application.Quit();
                break;
        }
    }
}
