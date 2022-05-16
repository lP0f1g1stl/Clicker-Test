using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    private Renderer _bgRend;

    [SerializeField] private Vector2 _speed;

    private void Awake()
    {
        _bgRend = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        _speed /= 50;
        StartCoroutine(bg());
    }
    /*void FixedUpdate()
    {
        _bgRend.material.mainTextureOffset += _speed * Time.deltaTime;    
    }*/

    private IEnumerator bg() 
    {
        while (true)
        {
            _bgRend.material.mainTextureOffset += _speed;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
