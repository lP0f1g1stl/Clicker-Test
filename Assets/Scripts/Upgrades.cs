using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Upgrades : MonoBehaviour
{
    [SerializeField] UpgradePrefab _upgradePrefab;
    [SerializeField] GameObject _upgradesList;
    [SerializeField] UpgradesData _upgradesData;

    private List<UpgradePrefab> _objects = new List<UpgradePrefab>();

    public delegate bool OnUpgradeButtonClick(int id);
    public event OnUpgradeButtonClick IsClicked;

    public Action IsUpgraded;

    private void Start()
    {
        CreateUpgradesList();
    }
    public void Upgrade(int id)
    {
        if (_upgradesData.UpgradeData[id].Level < _upgradesData.UpgradeData[id].MaxLevel)
        {
            var check = IsClicked?.Invoke(id);
            if (check == true)
            {
                _upgradesData.UpgradeData[id].Level += 1;
                IsUpgraded?.Invoke();
                ChangeUpgradeUI(id);
            }
        }
    }
    private void CreateUpgradesList() 
    { 
        for (int i = 0; i < _upgradesData.UpgradeData.Length; i++) 
        {
            CreateUpgradeUI(i);
        }
    }
    private void CreateUpgradeUI(int id) 
    {
        UpgradePrefab upgradeUI = Instantiate(_upgradePrefab, _upgradesList.transform);
        _objects.Add(upgradeUI);
        SetUpgradeData(id);
        SetUpgradeUIPosition(id);
    }
    private void SetUpgradeData(int id) 
    {
        _objects[id].ID = id;
        _objects[id].SetUpgradesObject(this);
        ChangeUpgradeUI(id);
    }
    private void ChangeUpgradeUI(int id) 
    {
        _objects[id].Description = _upgradesData.UpgradeData[id].Description;
        _objects[id].Level = _upgradesData.UpgradeData[id].Level.ToString();
        _objects[id].Price = _upgradesData.UpgradeData[id].Price.ToString();
    }
    private void SetUpgradeUIPosition(int id) 
    {
        _objects[id].gameObject.transform.localPosition = new Vector3(0, -100 - 200 * id, 0);
    }
}
