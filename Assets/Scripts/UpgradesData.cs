using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Data", menuName = "Upgrade Data")]
public class UpgradesData : ScriptableObject
{
    [SerializeField] private UpgradeData[] _upgradeData;

    public UpgradeData[] UpgradeData 
    {
        get { return _upgradeData; }
    }
}

[System.Serializable]
public struct UpgradeData 
{
    [SerializeField] private int _curLevel;
    [SerializeField] private int _maxLevel;
    [SerializeField] private int _basePrice;
    [SerializeField] private int _baseUpgradeAmount;
    [SerializeField] private string _description;

    public int Level 
    {
        set { _curLevel = value; }
        get { return _curLevel; }
    }
    public int MaxLevel 
    {
        get { return _maxLevel; }
    }
    public int Price 
    {
        get { return _basePrice * _curLevel; }
    }
    public int Amount 
    {
        get { return _baseUpgradeAmount * _curLevel; }
    }
    public string Description 
    {
        get { return _description; }
    }
}
