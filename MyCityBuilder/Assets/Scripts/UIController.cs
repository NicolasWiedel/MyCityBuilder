using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Action OnBuildAreaHandler;
    private Action OnCancelActionHandler;

    public Button buildResidentialAreaBtn;
    public Button cancelActionBtn;
    public GameObject cancelActionPanel;

    // Start is called before the first frame update
    void Start()
    {
        cancelActionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void AddListenerOnBuildAreaEvent(Action listener)
    {
        OnBuildAreaHandler += listener;
    }
    public void RemoveListenerOnBuildAreaEvent(Action listener)
    {
        OnBuildAreaHandler -= listener;
    }
    public void AddListenerOnCancelActionEvent(Action listener)
    {
        OnCancelActionHandler += listener;
    }
    public void RemoveListenerOnCancelActionEven(Action listener)
    {
        OnCancelActionHandler += listener;
    }
}
