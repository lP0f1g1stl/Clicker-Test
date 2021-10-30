using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private int[,] valuesOfUpgrades = new int[3, 3];

    [SerializeField] private Text[] descOfLevels = new Text[3];
    [SerializeField] private Text[] descOfPrices = new Text[3];

    private int money;

    void Start() 
    {
        valuesOfUpgrades[0, 0] = 1;
        valuesOfUpgrades[1, 0] = 1;
        valuesOfUpgrades[2, 0] = 1;

        valuesOfUpgrades[0, 1] = 1;
        valuesOfUpgrades[1, 1] = 1;
        valuesOfUpgrades[2, 1] = 1;

        valuesOfUpgrades[0, 2] = 10;
        valuesOfUpgrades[1, 2] = 10;
        valuesOfUpgrades[2, 2] = 3;
    }

    public void SetUpgradeLevel(int upgradeId) 
    {
        if (money >= valuesOfUpgrades[upgradeId, 1] && valuesOfUpgrades[upgradeId, 0] < valuesOfUpgrades[upgradeId, 2]) 
        {
            GetComponent<Score>().ChangeAmountOfMoney(-valuesOfUpgrades[upgradeId, 1]);
            valuesOfUpgrades[upgradeId, 0] += 1;
            valuesOfUpgrades[upgradeId, 1] *= 2;
            descOfLevels[upgradeId].text = valuesOfUpgrades[upgradeId, 0].ToString();
            descOfPrices[upgradeId].text = valuesOfUpgrades[upgradeId, 1].ToString();
            GetUpgradeValue(upgradeId);
        }
    }

    public void CheckScore(int cMoney) 
    {
        money = cMoney;
    }

    private void GetUpgradeValue( int upgradeId) 
    {
        if (upgradeId == 0) 
        {
            GetComponent<MineralSpawner>().SetSpawnSpeed();
        }
        if (upgradeId == 1) 
        {
            GetComponent<MineralSpawner>().SetPriceOfUpgrade(valuesOfUpgrades[upgradeId, 0]);
        }
        if (upgradeId == 2) 
        {
            GetComponent<MineralSpawner>().SetMineralSpawnTier(valuesOfUpgrades[upgradeId, 0]);
        }
    }
}
