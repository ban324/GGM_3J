using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSys : MonoBehaviour, Instances
{
    public void SetInstance()
    {
        if (instance != null) Debug.Log("Á¿µÊ");
        instance = this;
    }

    public static CoinsSys instance;

    public int M_coin;
    public int E_coin;
    public int M_life;
    public int E_life;

    private void Awake()
    {
        SetInstance();
    }
    public void M_CoinUp(int amount)
    {
        M_coin += amount;
    }
    public void M_lifeUp(int amount)
    {
        M_life += amount;
    }
    public void E_CoinUp(int amount)
    {
        E_coin += amount;
    }
    public void E_lifeUp(int amount)
    {
        E_life += amount;
    }
}
