using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPrefab : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Transform _goTransform;
    private int _id;
    private bool _isActive;

    private Vector3  _speed;

    public int ID
    {
        set { _id = value; }
        get { return _id; }
    }

    public Vector3 Speed
    {
        set { _speed = value / 50; }
    }

    public Sprite Sprite
    {
        set { _spriteRenderer.sprite = value; }
    }

    public bool IsActive
    {
        set
        {
            _isActive = value;
        }
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _goTransform = GetComponent<Transform>();
    }
    public void OnEnable()
    {
        _isActive = true;
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        while (_isActive)
        {
            _goTransform.position -= _speed;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
