using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject mineralSpawner;
    [SerializeField] private GameObject upgradesList;
    [SerializeField] private GameObject acceptExit;

    private float speed = 0.1f;

    public void StartOnClick()
    {
        background.GetComponent<BackgroundScrolling>().SetBackgroundSpeed(speed);
        mineralSpawner.GetComponent<MineralSpawner>().StartStop(speed);
    }

    public void ShowUpgrades() 
    {
        upgradesList.SetActive(!upgradesList.activeSelf);
    }

    public void Exit(int commId) 
    {
        if (commId == 0)
        {
            acceptExit.SetActive(!acceptExit.activeSelf);
        }
        if (commId == 1)
        {
            Application.Quit();
        }
    }
}
