using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEff : MonoBehaviour, Instances
{
    public static PassiveEff instance;
    public delegate void CardEff(int who, int count);
    private int disableSteal;
    public Dictionary<int, CardEff> PassiveEffs;//È«Çü¹Î Á¦ÀÛ. Á¦³×¸¯ ÇÔ¼ö
    private void Awake()
    {
        PassiveEffs = new Dictionary<int, CardEff>();
        
        SetInstance();
    }
    public void UsePassive(int who)
    {
        if(who == 0)
        {
            for (int i = 0; i < HandSys.instance.handCards.Count; i++)
            {
                if (PassiveEffs.ContainsKey(i))
                {
                    int j = 0;
                    switch (i)
                    {
                        case 6: j = 1 + StackSys.instance.stacks[2]; break;
                        case 8: j = StackSys.instance.stacks[0] - StackSys.instance.stacks[1]; break;
                        case 10: j = (int)(CoinsSys.instance.E_coin + CoinsSys.instance.M_coin) / 2; break;
                        case 11: j = (EnemyHandSys.instance.handCards.Count + HandSys.instance.handCards.Count) / 2; break;
                        default: j = 1; break;
                    }
                    PassiveEffs[i].Invoke(who, j);
                }
            }

        }if(who ==1)
        {
            for (int i = 0; i < EnemyHandSys.instance.handCards.Count; i++)
            {
                if (PassiveEffs[i] != null)
                {
                    int j = 0;
                    switch (i)
                    {
                        case 6: j = 1 + StackSys.instance.stacks[2]; break;
                        case 8: j = StackSys.instance.stacks[0] - StackSys.instance.stacks[1]; break;
                        case 10: j = (int)(CoinsSys.instance.E_coin + CoinsSys.instance.M_coin) / 2; break;
                        case 11: j = (EnemyHandSys.instance.handCards.Count + HandSys.instance.handCards.Count) / 2; break;
                        default: j = 1; break;
                    }
                    PassiveEffs[i].Invoke(who, j);
                }
            }

        }
    }
    public void PassiveDic()
    {
        PassiveEffs.Add(1, StackUp);
        PassiveEffs.Add(2, StackUp);
        PassiveEffs.Add(5, (int a, int b) => { StackSys.instance.stacks[0]--; StackSys.instance.stacks[2]++; });
        PassiveEffs.Add(6, TakeCoins);
        PassiveEffs.Add(8, (int a, int b) => { if (StackSys.instance.stacks[1] < StackSys.instance.stacks[0]) TakeCoins(a, b); });
        PassiveEffs.Add(9,  StackUp);
        PassiveEffs.Add(10, StackUp);
        PassiveEffs.Add(11, StackUp);
        PassiveEffs.Add(12, GetCoins);
        PassiveEffs.Add(13, StackUp);

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


    public void SetInstance()
    {
        if (instance != null) Debug.Log("Á¿µÊ");
        instance = this;
    }
}
