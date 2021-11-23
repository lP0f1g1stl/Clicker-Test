using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private Renderer bgRend;

    private float speed = 0;

    void FixedUpdate()
    {
        bgRend.material.mainTextureOffset += new Vector2(0f, speed * Time.deltaTime);    
    }

    public void SetBackgroundSpeed(float bgSpeed) 
    {
        speed = bgSpeed;
    }
}
