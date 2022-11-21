using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour, Instances
{
    public void SetInstance()
    {
        if (instance != null) Debug.Log("Á¿µÊ");
        instance = this;
    }

    public static Effect instance;
    public bool ActEnd;
    private void Awake()
    {
        SetInstance();
    }
    public void GetCoin()
    {
        CoinsSys.instance.M_CoinUp(2);
        ActEnd = true;
    }
    public void GetHand()
    {

    }
}
