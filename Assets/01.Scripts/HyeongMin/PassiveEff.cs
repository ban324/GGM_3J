using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEff : MonoBehaviour, Instances
{
    public static CardEffect instance;//全屈刮 力累. 力匙腐
    public delegate void CardEff(int who, int count);
    private int disableSteal;
    public Dictionary<int, CardEff> PassiveEffs;
    private void Awake()
    {
        PassiveEffs = new Dictionary<int, CardEff>();
        
        SetInstance();
    }
    public void PassiveDic()
    {
        PassiveEffs.Add(1, StackUp);
        PassiveEffs.Add(2, StackUp);
        PassiveEffs.Add(5, (int a, int b) => { StackSys.instance.stacks[0]--; StackSys.instance.stacks[2]++; }) ;
        PassiveEffs.Add(6, TakeCoins);
        PassiveEffs.Add(8, TakeCoins);
        PassiveEffs.Add(9,  StackUp);
        PassiveEffs.Add(10, StackUp);
        PassiveEffs.Add(11, StackUp);
        PassiveEffs.Add(12, GetCoins);
        PassiveEffs.Add(13, StackUp);

    }
    public void StopSteal(int who, int turnCount)
    {
        disableSteal = turnCount;
    }
    public void GetCoins(int who, int count)
    {
        if (who == 0)
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
        if (who == 0)
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
        if (Turn.instance.state == Turn.State.Active) Effect.instance.ActEnd = true;
    }

    public void Damage(int who, int count)
    {
        if (who == 0)
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
        if (instance != null) Debug.Log("量凳");
    }
}
