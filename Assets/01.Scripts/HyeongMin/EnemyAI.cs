using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : EnemyHandSys, Instances
{ 
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
                EnemyHandSys.instance.handCards[Random.Range(0, EnemyHandSys.instance.handCards.Count - 1)].Use(1);
                Effect.instance.GetEHand();
                break;
        }
    }
}
