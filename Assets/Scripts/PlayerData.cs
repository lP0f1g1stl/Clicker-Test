using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
     [SerializeField] private int _score;
     [SerializeField] private int _money;

    public int Score 
    {
        set { _score = value; }
        get { return _score; }
    }

    public int Money
    {
        set { _money = value; }
        get { return _money; }
    }
}
