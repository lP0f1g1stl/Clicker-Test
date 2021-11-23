using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{
    [SerializeField] private int _animFrames;
    [SerializeField] Vector3 _deltaPos;

    private CapsuleCollider2D _capsuleCollider;
    private Transform _goTransform;
    private SpriteRenderer _goSpriteRenderer;
    private Color _color;
    private int _animFramesCounter;

    private void Awake()
    {
        _goTransform = GetComponent<Transform>();
        _goSpriteRenderer = GetComponent<SpriteRenderer>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
        _color = _goSpriteRenderer.color;
    }
    public void StartAnimation() 
    {
        _capsuleCollider.enabled = false;
        StartCoroutine(Animation());
    }

    public IEnumerator Animation() 
    {
        while (_animFramesCounter < _animFrames)
        {
            _color.a = (float)(_animFrames - _animFramesCounter) / _animFrames;
            _goSpriteRenderer.color = _color;
            _goTransform.position += _deltaPos;
            _animFramesCounter++;
            yield return new WaitForSeconds(0.02f);
        }
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        _animFramesCounter = 0;
        _color.a = 1;
        _goSpriteRenderer.color = _color;
        _capsuleCollider.enabled = true;
    }
}
