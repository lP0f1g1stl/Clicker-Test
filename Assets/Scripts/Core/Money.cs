using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private Text _money;

    [SerializeField] private Player _player;
    [SerializeField] private Upgrades _upgrades;

    [SerializeField] private ObjectsData _objectData;
    [SerializeField] private UpgradesData _upgradeData;
    [SerializeField] private PlayerData _playerData;

    private int _curMoney;

    private void Start()
    {
        _player.OnClick += AddMoney;
        _upgrades.IsClicked += RemoveMoney;
        LoadMoney();
        ChangeText();
    }
    public void AddMoney(int id)
    {
        _curMoney += _objectData.ObjectData[id].BasePrice * _upgradeData.UpgradeData[0].Amount;
        SaveMoney();
        ChangeText();
    }
    public bool RemoveMoney(int id) 
    {
        if (_curMoney >= _upgradeData.UpgradeData[id].Price)
        {
            _curMoney -= _upgradeData.UpgradeData[id].Price;
            ChangeText();
            SaveMoney();
            return true;
        }
        else return false;
    }
    private void SaveMoney()
    {
        _playerData.Money = _curMoney;
    }
    private void LoadMoney() 
    {
        _curMoney = _playerData.Money;
    }
    private void ChangeText()
    {
        _money.text = "Money: " + _curMoney.ToString();
    }
    private void OnDestroy()
    {
        _player.OnClick -= AddMoney;
        _upgrades.IsClicked -= RemoveMoney;
    }
}
