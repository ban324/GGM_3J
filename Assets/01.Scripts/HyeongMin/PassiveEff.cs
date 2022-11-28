using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEff : MonoBehaviour, Instances
{
    public static PassiveEff instance;
    public delegate void CardEff(int who, int count);
    private int disableSteal;
    public Dictionary<int, CardEff> PassiveEffs;//홍형민 제작. 제네릭 함수
    private void Awake()
    {
        PassiveEffs = new Dictionary<int, CardEff>();
        PassiveDic();
        SetInstance();
    }
    public void UsePassive(int who)
    {
        Debug.Log(Turn.instance.state);
        if (who == 0)
        {
            for (int i = 0; i < HandSys.instance.handCards.Count; i++)
            {
                    int k = HandSys.instance.handCards[i].cardId;
                if (PassiveEffs.ContainsKey(k))
                {
                    int j = 0;
                    switch (k)
                    {
                        case 0: j = 1; break;

                        case 1: who = 1; j = Random.Range(0,4); break;
                        case 2: who = 0; j = 1; break;
                        case 4: j = 2; break;
                        case 5: j = 2; break;

                        case 6: j = 2 ; break;
                        case 8: j = 1; break;
                        case 9: who = 1; j = 1; break;
                        case 10: who = 0; j = CoinsSys.instance.E_coin / 10; break;
                        case 11: j = 1; break;
                        case 12: j = Random.Range(0,4); break;
                        case 13: who = 1; j = 1; break;
                        default: j = 1; break;
                    }
                    PassiveEffs[k]?.Invoke(who, j);
                }
            }

        }
        if (who == 1)
        {
            for (int i = 0; i < EnemyHandSys.instance.handCards.Count; i++)
            {
                    int k = EnemyHandSys.instance.handCards[i].cardId;
                if (PassiveEffs.ContainsKey(k))
                {
                    int j = 0;
                    switch (k)
                    {
                        case 0: j = 1; break;
                        case 1: who = 1; j = Random.Range(0,4); break;
                        case 2: who = 1; j = 1; break;
                        case 4: j = 2; break;
                        case 5: j = 2; break;
                        case 6: j = 2; break;
                        case 8: j = 1;break;
                        case 9: who = 1; j = 1; break;
                        case 10: who = 0; j = CoinsSys.instance.E_coin / 10; break;
                        case 11: j =1; break;
                        case 12: j = Random.Range(0, 4); break;
                        case 13: who = 1; j = 1; break;
                        default: j = 1; break;
                    }
                    PassiveEffs[k].Invoke(who, j);
                }
            }

        }
    }
    public void PassiveDic()
    {
        PassiveEffs.Add(0, (int a, int b) =>
        {
            if (a == 0)
            {
                if (CoinsSys.instance.E_coin > CoinsSys.instance.M_coin) TakeCoins(a, b);

            }
            else if (a == 1)
            {
                if (CoinsSys.instance.M_coin > CoinsSys.instance.E_coin) TakeCoins(a, b);
            }
        }); 
        PassiveEffs.Add(1, StackUp);
        PassiveEffs.Add(2, (int who, int amount) =>
        {
            StackUp(0, amount);
            GetCoins(who, amount);
        });
        PassiveEffs.Add(4, (int who, int amount) =>
        {
            if (who == 0)
            {
                if (CoinsSys.instance.M_coin < StackSys.instance.stacks[0])
                {
                    StackUp(0, amount);
                }
            }
        });
        PassiveEffs.Add(5, (int a, int b) => { StackUp(0,-1);  StackUp(2, 2); Debug.Log("무당"); });
        PassiveEffs.Add(6, (int a, int b) =>
        {
            if (StackSys.instance.stacks[2] > StackSys.instance.stacks[0])
            {
                GetCoins(a, b);
            }
        });
        PassiveEffs.Add(8, (int a, int b) => { if (StackSys.instance.stacks[1]> StackSys.instance.stacks[0]) TakeCoins(a, b); });
        PassiveEffs.Add(9, (int a, int b) => { StackUp(0,1); StackUp(1,1); StackUp(2, 1); });
        PassiveEffs.Add(10, StackUp);
        PassiveEffs.Add(11, (int a, int b) =>
        {
            if (StackSys.instance.stacks[2] < StackSys.instance.stacks[0])
            {
                StackUp(2, StackSys.instance.stacks[0] / 2);
            }
        });
        PassiveEffs.Add(12, GetCoins);
        PassiveEffs.Add(13, StackUp);

    }
    public void GetCoins(int who, int count)
    {
        if (who == 0)
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
    public void StackUp(int Member, int count)
    {
        StackSys.instance.stacks[Member] += count;
    }


    public void SetInstance()
    {
        instance = this;
    }
    private void Update()
    {
    }
}
