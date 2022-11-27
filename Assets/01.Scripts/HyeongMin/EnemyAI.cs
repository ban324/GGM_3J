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
    { if (Turn.instance.enemyEnd)
        {
            int x = Random.Range(0, 4);
            if(x == 0)
            {
                Effect.instance.GetECoin();
                Debug.LogError("������");
                Effect.instance.EffectEnd = true;
            }
            else if(x == 1)
            {
                Effect.instance.GetEHand();
                Effect.instance.EffectEnd = true;

            }
            else if(x == 2)
            {
                if (EnemyHandSys.instance.handCards.Count > 0)
                {
                    Debug.LogError("�����");
                    EnemyHandSys.instance.handCards[Random.Range(0, EnemyHandSys.instance.handCards.Count)].Use(1);
                    IsCard newCard = Instantiate(Effect.instance.CardObj).GetComponent<IsCard>();
                    newCard.GetCard();
                    newCard.forEnemy = true;
                    EnemyHandSys.instance.handCards.Add(newCard);
                    Debug.LogError("���Ϸ�");
                    }
                Effect.instance.GetEHand();
                Effect.instance.EffectEnd = true;

            }else if (x == 3)
            {

                Debug.LogError("���ýõ�");
                if (CoinsSys.instance.E_coin > 6)
                {
                    Effect.instance.Attack(1);
                }
                else
                {
                    Effect.instance.GetECoin();
                    Effect.instance.EffectEnd = true;
                }
            }
        }
    } 
}

