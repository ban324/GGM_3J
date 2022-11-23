using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour, Instances
{

    public static CardEffect instance;//권순목 제작. 제네릭
    public delegate void CardEff(int who, int count);
    private int disableSteal;
    public Dictionary<int, CardEff> ActiveEffs;
    private void Awake()
    {
        ActiveEffs = new Dictionary<int, CardEff>();
        ActiveEffs.Add(0, (int who, int count) => {
            if (who == 0)
            {
                CoinsSys.instance.M_CoinUp(count);
                Debug.Log("asdf");
                Effect.instance.ActEnd = true;
            }
            else
            {
                CoinsSys.instance.E_CoinUp(count);
            }//권순목 제작. 람다식
        });
        ActiveEffs.Add(1, GetCoins);
        ActiveEffs.Add(2, TakeCoins);
        ActiveEffs.Add(4, Damage);
        ActiveEffs.Add(3, Damage);
        ActiveEffs.Add(5, new CardEff(TakeCoins));
        ActiveEffs.Add(6, GetCoins);
        ActiveEffs.Add(7, StopSteal);
        ActiveEffs.Add(8, Damage);
        ActiveEffs.Add(9, GetCoins);
        ActiveEffs.Add(10, TakeCoins);
        ActiveEffs.Add(11, GetCoins);
        ActiveEffs.Add(12, GetCoins);
        ActiveEffs.Add(13, GetCoins);
        SetInstance();
    }

    public void StopSteal(int who, int turnCount)
    {
        disableSteal = turnCount;
    }
    public void GetCoins(int who, int count)
    {
        if(who == 0)
        {
            CoinsSys.instance.M_CoinUp(count);
            Effect.instance.ActEnd = true;
        }
        else
        {
            CoinsSys.instance.E_CoinUp(count);
        }
    }
    public void TakeCoins(int who, int count)
    {
        if(who == 0)
        {
            CoinsSys.instance.M_CoinUp(count);
            CoinsSys.instance.E_CoinUp(-count);
            Effect.instance.ActEnd = true;
        }
        else
        {
            CoinsSys.instance.M_CoinUp(-count);
            CoinsSys.instance.E_CoinUp(count);
        }
    }
    public void StackUp(int Member, int count)
    {
        StackSys.instance.stacks[Member] += count;
        if (Turn.instance.state == Turn.State.Effect) Effect.instance.ActEnd = true;
    }

    public void Damage(int who, int count)
    {
        if(who == 0)
        {
            CoinsSys.instance.E_lifeUp(-count);
            Effect.instance.ActEnd = true;
        }
        else
        {
            CoinsSys.instance.M_lifeUp(count);
        }
    }

    public void SetInstance()
    {
        if (instance != null) Debug.Log("좆됨");
        instance = this;
    }
}
