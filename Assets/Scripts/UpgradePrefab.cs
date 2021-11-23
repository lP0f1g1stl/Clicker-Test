using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePrefab : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private Image _image;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Text _description;
    [SerializeField] private Text _level;
    [SerializeField] private Text _price;

    [SerializeField] private Upgrades _upgrades;
    public int ID
    {
        set { _id = value; }
    }
    public Sprite Image
    {
        set { _image.sprite = value; }
    }
    public string Description 
    {
        set { _description.text = value; }
    }
    public string Level
    {
        set { _level.text = value; }
    }
    public string Price
    {
        set { _price.text = "Price: " + value; }
    }
    public void SetUpgradesObject(Upgrades upgrades) 
    {
        _upgrades = upgrades;
    }
    public void SendId() 
    {
        _upgrades.Upgrade(_id);
    }
}
