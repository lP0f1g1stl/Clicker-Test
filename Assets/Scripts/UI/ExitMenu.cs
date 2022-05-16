using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    [SerializeField] private Button _accept;
    [SerializeField] private Button _close;

    private void Start()
    {
        _accept.onClick.AddListener(CloseApp);
        _close.onClick.AddListener(CloseMenu);
    }
    private void CloseApp() 
    {
        Application.Quit();
    }
    private void CloseMenu() 
    {
        gameObject.SetActive(false);
    }
}
