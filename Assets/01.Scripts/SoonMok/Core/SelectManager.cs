using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour, Instances
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject ActiveButton;
    [SerializeField] private GameObject KillButton;

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
        if (state)
        {

            if (CoinsSys.instance.M_coin < 2)
            {
                ActiveButton.SetActive(false);
            }
            else ActiveButton.SetActive(true);
            if (CoinsSys.instance.M_coin > 6)
            {
                KillButton.SetActive(true);
            }
            else KillButton.SetActive(false);
        }
    }

}
