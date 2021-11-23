using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object Data", menuName = "Object Data")]
public class ObjectsData : ScriptableObject
{
    [SerializeField] private ObjectPrefab _objectPrefab;
    [SerializeField] private ObjectData[] _objectData;

    public ObjectPrefab ObjectPrefab
    {
        get { return _objectPrefab; }
    }
    public ObjectData[] ObjectData 
    {
        get { return _objectData; }
    }
}
[System.Serializable]
public struct ObjectData
{
    [SerializeField] private int _basePrice;
    [SerializeField] private Sprite _sprite;

    public int BasePrice
    {
        get { return _basePrice; }
    }

    public Sprite Sprite
    {
        get { return _sprite; }
    }
}
