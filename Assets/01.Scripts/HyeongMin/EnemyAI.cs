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
                Debug.LogError("적코인");
                Effect.instance.EffectEnd = true;

                break;
            case 1:
                    Effect.instance.GetEHand();
                Debug.LogError("적카드");
                Effect.instance.EffectEnd = true;

                break;
            case 2:
                if(EnemyHandSys.instance.handCards.Count > 0)
                {
                    Debug.Log("적사용");
                    EnemyHandSys.instance.handCards[Random.Range(0, EnemyHandSys.instance.handCards.Count)].Use(1);
                    IsCard newCard = Instantiate(Effect.instance.CardObj).GetComponent<IsCard>();
                    newCard.GetCard();
                    EnemyHandSys.instance.handCards.Add(newCard); Debug.Log("사용완료");

                    break;

                }Effect.instance.GetEHand();
                Effect.instance.EffectEnd = true;
                break;
        }
    }
}
