using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour, Instances
{
    public static EnemyAI instance;

    public void SetInstance()
    {
        instance = this;
    }
    private void Awake()
    {
        SetInstance();
    }
    public void Enemy()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                Effect.instance.GetECoin();
                break;
            case 1:
                    Effect.instance.GetEHand();
                    break;
            case 2:
                if(EnemyHandSys.instance.handCards.Count > 0)
                {
                    EnemyHandSys.instance.handCards[Random.Range(0, EnemyHandSys.instance.handCards.Count)].Use(1);
                    Effect.instance.GetEHand();
                    break;

                }goto case 1;
        }

    }
}
