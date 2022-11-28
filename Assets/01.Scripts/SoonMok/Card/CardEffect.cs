using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour, Instances
{

    public static CardEffect instance;
    public delegate void CardEff(int who, int count);
    public int disableSteal;
    public Dictionary<int, CardEff> ActiveEffs;//권순목 제작. 제네릭
    private void Awake()
    {
        ActiveEffs = new Dictionary<int, CardEff>();
        ActiveEffs.Add(0, (int who, int count) => {
            if (who == 0)
            {
                Effect.instance.GetHand();
                Effect.instance.GetHand();
            }
            else
            {
                Effect.instance.GetEHand();
                Effect.instance.GetEHand();
            }//권순목 제작. 람다식
        });
        ActiveEffs.Add(1, (int a, int b) =>
        {
            GetCoins(a, StackSys.instance.stacks[1]);
            StackUp(1, StackSys.instance.stacks[1]);
        });
        ActiveEffs.Add(2, (int a, int b) =>
        {
            StackUp(0, b);
            StackUp(1, -b);
        });
        ActiveEffs.Add(3, (int who, int amo) =>
        {
            if (StackSys.instance.stacks[0] > StackSys.instance.stacks[1] || StackSys.instance.stacks[2] > StackSys.instance.stacks[0])
            {
                Damage(who, amo);
            }
        });
        ActiveEffs.Add(4, Damage);
        ActiveEffs.Add(5, Damage);
        ActiveEffs.Add(6, (int who, int amo) =>
        {
            StackUp(2, -StackSys.instance.stacks[2]);
            GetCoins(who, amo);
        });
        ActiveEffs.Add(7, StopSteal);
        ActiveEffs.Add(8, (int a, int b) =>
        {
            if (StackSys.instance.stacks[0] > StackSys.instance.stacks[1])
            {
                Damage(a, b);
            }
        });
        ActiveEffs.Add(9, (int a, int b) =>
        {
            if (StackSys.instance.stacks[0] < StackSys.instance.stacks[1]&& StackSys.instance.stacks[0] < StackSys.instance.stacks[2])
            {
                StackSys.instance.stacks[0] += 5;
            }else
            if (StackSys.instance.stacks[1] < StackSys.instance.stacks[2]&& StackSys.instance.stacks[1] < StackSys.instance.stacks[0])
            {
                StackSys.instance.stacks[1] += 5;
            }else
            if (StackSys.instance.stacks[2] < StackSys.instance.stacks[1]&& StackSys.instance.stacks[2] < StackSys.instance.stacks[0])
            {
                StackSys.instance.stacks[2] += 5;
            }
        });
        ActiveEffs.Add(10, TakeCoins);
        ActiveEffs.Add(11, (int who, int amount) =>
        {
            Damage(who, 1);
            Damage(-who, 1);
            StackUp(0, StackSys.instance.stacks[0]);
        });
        ActiveEffs.Add(12, GetCoins);
        ActiveEffs.Add(13, (int who, int amount) =>
        {
            Damage(who, 1);
            StackUp(1, amount);
        });
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
        }
        else
        {
            CoinsSys.instance.E_CoinUp(count);
        }
    }
    public void TakeCoins(int who, int count)
    {
        if (disableSteal<=0)
        {
            if (who == 0)
            {
                CoinsSys.instance.M_CoinUp(count);
                CoinsSys.instance.E_CoinUp(-count);
            }
            else
            {
                CoinsSys.instance.M_CoinUp(-count);
                CoinsSys.instance.E_CoinUp(count);
            }

        }
    }
    public void StackUp(int Member, int count)
    {
        StackSys.instance.stacks[Member] += count;
    }

    public void Damage(int who, int count)
    {
        if(who == 0)
        {
            CoinsSys.instance.E_lifeUp(-count);
        }
        else
        {
            CoinsSys.instance.M_lifeUp(-count);
        }
    }

    public void SetInstance()
    {
        instance = this;
    }
}
