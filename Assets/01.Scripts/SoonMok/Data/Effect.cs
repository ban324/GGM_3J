using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public static Effect Instance;
    public bool ActEnd;
    private void Awake()
    {
        Instance = this;
    }
    public void GetCoin()
    {
        CoinsSys.instance.m_CoinUp(2);
        ActEnd = true;
    }
    public void GetHand()
    {

    }
}
