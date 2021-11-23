using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] minerals;
    [SerializeField] private bool started = false;

    private float mineralSpeed;
    private int priceLevel = 1;
    private int mineralLevel = 0;

    private float spawnTime = 100;
    private int time = 0;

   void FixedUpdate() 
    { 
        if (started != false) 
        {
            if (time >= spawnTime)
            {
                int rand = Random.Range(0, mineralLevel);
                MineralSpawn(rand);
                time = 0;
            }
            time++;
        }
    }

    public void StartStop(float speed) 
    {
        started = !started;
        mineralSpeed = -speed * 1.75f;
    }
    private void MineralSpawn(int mineralID) 
    {
        float xPos = Random.Range(-0.5f, 0.5f);
        GameObject mineral = Instantiate(minerals[mineralID], new Vector3(xPos, 1, -1), Quaternion.identity);
        mineral.GetComponent<Mineral>().SetSpeed(mineralSpeed);
        mineral.GetComponent<Mineral>().SetPrice(priceLevel);
    }
    public void SetSpawnSpeed() 
    { 
        spawnTime = spawnTime * 0.9f;
    }

    public void SetPriceOfUpgrade(int uLevel) 
    {
        priceLevel = uLevel;
    }

    public void SetMineralSpawnTier(int uLevel) 
    {
        mineralLevel = uLevel;
    }
}
