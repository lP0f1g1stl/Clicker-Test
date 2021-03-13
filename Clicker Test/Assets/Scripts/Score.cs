using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Text money;
    [SerializeField] private Text score;
    [SerializeField] private GameObject mineralSpawner;

    private int curMoney = 0;
    private int curScore = 0;

    public void ChangeAmountOfMoney(int price) 
    {
        curMoney += price;
        ChangeText();
        GetComponent<Upgrades>().CheckScore(curMoney);
    }

    public void ChangeScore(int basePrice) 
    {
        curScore += basePrice;
        ChangeText();
    }
    private void ChangeText() 
    {
        money.text = "Money: " + curMoney.ToString();
        score.text = "Score: " + curScore.ToString();
    }
}
