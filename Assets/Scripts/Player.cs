using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<int> OnClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.GetComponent<ObjectPrefab>() && hit.collider.GetComponent<ObjectAnimation>()) 
            {
                ObjectPrefab objectPrefab = hit.collider.GetComponent<ObjectPrefab>();
                ObjectAnimation objectAnimation = hit.collider.GetComponent<ObjectAnimation>();
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
