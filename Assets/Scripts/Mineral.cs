using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    [SerializeField] private int basePrice;
    [SerializeField] private int totalPrice;

    private GameObject score;
    private float speed;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("GameManager");
        Destroy(gameObject, 16);
    }
    void FixedUpdate()
    {
        gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
    }

    public void SetSpeed(float mSpeed) 
    {
        speed = mSpeed; 
    }

    public void SetPrice(int upgradeLevel) 
    {
        totalPrice = basePrice * upgradeLevel;
    }

    public void OnMouseDown()
    {
        score.GetComponent<Score>().ChangeAmountOfMoney(totalPrice);
        score.GetComponent<Score>().ChangeScore(basePrice);
        Destroy(gameObject);
    }
}
