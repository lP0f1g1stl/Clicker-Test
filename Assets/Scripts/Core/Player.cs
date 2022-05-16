using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Action<int> OnClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.TryGetComponent(out ObjectPrefab objectPrefab) && hit.collider.TryGetComponent(out ObjectAnimation objectAnimation))
            {
                GetHitObject(objectPrefab, objectAnimation);
            }
        }
    }

    private void GetHitObject(ObjectPrefab objectPrefab, ObjectAnimation objectAnimation)
    {
        objectPrefab.IsActive = false;
        objectAnimation.StartAnimation();
        int id = objectPrefab.ID;
        OnClick?.Invoke(id);
    }
}
