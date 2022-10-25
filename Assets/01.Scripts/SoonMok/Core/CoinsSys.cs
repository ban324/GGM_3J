using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSys : MonoBehaviour
{
    public static CoinsSys instance;

    public int M_coin;
    public int E_coin;
    public int M_life;
    public int E_life;

    private void Awake()
    {
        instance = this;
    }
    public void m_CoinUp(int amount)
    {
        M_coin += amount;
        UIManager.Instance.SetText_mC(M_coin);
    }
    public void m_lifeUp(int amount)
    {
        M_life += amount;
        UIManager.Instance.SetText_mL(M_life);

    }
    public void e_CoinUp(int amount)
    {
        E_coin += amount;
        UIManager.Instance.SetText_eC(E_coin);

    }
    public void e_lifeUp(int amount)
    {
        E_life += amount;
        UIManager.Instance.SetText_eL(E_life);

    }
}
