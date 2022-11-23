using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour, Instances
{
    [SerializeField] private GameObject panel;
    public static SelectManager instance;
    public void SetInstance()
    {
        instance = this;
    }

    private void Awake()
    {
        SetInstance();
    }
    public void PanelActive(bool state)
    {
        panel.SetActive(state);
    }
}
