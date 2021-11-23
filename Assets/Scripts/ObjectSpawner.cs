using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private ObjectsData _objectData;
    [SerializeField] private UpgradesData _upgradesData;
    [SerializeField] private Upgrades _upgrades;


    [SerializeField] private Vector3  _speed;
    [SerializeField] private int _baseObjectsQantity;

    private List<ObjectPrefab> _objects = new List<ObjectPrefab>();

    private int _maxLevelOfObjects;
    private float _spawnTime;
    private int curObject;

    private void Start()
    {
        _upgrades.IsUpgraded += UpdateSpawnData;
        CreateObjectPool();
        UpdateSpawnData();
        StartCoroutine(SpawnTimer());
    }
    private void SetSpawnTimeBySpeedAndQuantity() 
    { 
        _spawnTime = 2.5f /_speed.y / _objects.Count;
    }
    private void CreateObjectPool() 
    {
        for(int i = 0; i < _baseObjectsQantity; i++) 
        {
            CreateObject();
        }
    }
    private void CreateObject() 
    {
        ObjectPrefab objectPrefab = Instantiate(_objectData.ObjectPrefab, gameObject.transform);
        objectPrefab.gameObject.SetActive(false);
        _objects.Add(objectPrefab);
        objectPrefab.Speed = _speed;
    }
    private void SetObjectData(int id) 
    {
        int rand = Random.Range(0, _maxLevelOfObjects);
        _objects[id].ID = rand;
        _objects[id].Sprite = _objectData.ObjectData[rand].Sprite;
    }
    private void ChangeObjectPosition(int id) 
    {
        float rand = Random.Range(-0.5f, 0.5f);
        _objects[id].transform.position = new Vector3(rand , 1.2f, 0);
    }
    private IEnumerator SpawnTimer() 
    {
        while (true)
        {
            SetObjectData(curObject);
            ChangeObjectPosition(curObject);
            _objects[curObject].gameObject.SetActive(true);
            curObject++;
            if (curObject == _objects.Count) curObject = 0;
            yield return new WaitForSeconds(_spawnTime);
        }
    }
    private void UpdateSpawnData() 
    {
        IncreaseMaxLevelOfObject();
        IncreaseQuantityOfObjects();
    }
    private void IncreaseMaxLevelOfObject()
    {
        int maxLevelIfObjects = _upgradesData.UpgradeData[2].Amount;
        if (maxLevelIfObjects < _objectData.ObjectData.Length)
        {
            _maxLevelOfObjects = maxLevelIfObjects;
        }
        else _maxLevelOfObjects = _objectData.ObjectData.Length;
    }
    private void IncreaseQuantityOfObjects() 
    {
        if (_objects.Count < _baseObjectsQantity + _upgradesData.UpgradeData[1].Amount)
        {
            AddNewObjects(_baseObjectsQantity + _upgradesData.UpgradeData[1].Amount - _objects.Count);
            SetSpawnTimeBySpeedAndQuantity();
        }
    }

    private void AddNewObjects(int addedQuantity) 
    {
        for(int i = 0; i < addedQuantity; i++) 
        {
            CreateObject();
        }
    }
    private void OnDestroy()
    {
        _upgrades.IsUpgraded -= UpdateSpawnData;
    }
}
