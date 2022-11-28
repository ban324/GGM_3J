using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IsCard : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public bool forEnemy;
    public int cardId;
    public int CardCost;
    public StreamReader _reader;
    public TextAsset _textAsset;

    private void Awake()
    {
        GetCard();
    }
    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void GetCard()
    {
        cardId = Random.Range(0, 14);
    }

    public void ChangeSprite(int id)
    {
        _spriteRenderer.sprite = Turn.instance?.Sprites[id];
        Debug.Log(Turn.instance.Sprites[id]);
    }

    public void Use(int who)
    {
        CoinsSys.instance.M_CoinUp(-2);
        ChangeSprite(cardId);
        switch (cardId)
        {
            case 0: CardEffect.instance.ActiveEffs[cardId].Invoke(who, 1); break;
            case 1:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, StackSys.instance.stacks[1]);
                break;
            case 2:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, StackSys.instance.stacks[1]);
                break;
            case 3:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, 1); 
                break;
            case 4:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, 1);
                break;
            case 5:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who == 0 ? 1 : 0, -1);
                break;
            case 6:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who,2);
                break;
            case 7:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, 3);
                break;
            case 8:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, 1);
                break;
            case 9:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, StackSys.instance.stacks[0]);
                break;
            case 10:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, 1 + StackSys.instance.stacks[0]);
                break;
            case 11:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, StackSys.instance.stacks[0] - StackSys.instance.stacks[1]); ;   
                break;
            case 12:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, (CoinsSys.instance.M_coin + CoinsSys.instance.E_coin)/2);
                CardEffect.instance.ActiveEffs[cardId].Invoke(who * -1, (CoinsSys.instance.M_coin + CoinsSys.instance.E_coin)/2);
                Debug.Log((CoinsSys.instance.M_coin + CoinsSys.instance.E_coin) / 2 +" "+ who);
                break;
            case 13:
                CardEffect.instance.ActiveEffs[cardId].Invoke(who, StackSys.instance.stacks[0]);
                break;
            default:
                break;
        }
        if(who == 0) HandSys.instance.handCards.RemoveAt(HandSys.instance.handCards.IndexOf(this));
        else EnemyHandSys.instance.handCards.RemoveAt(EnemyHandSys.instance.handCards.IndexOf(this));
        UseCardEff.instance.UseEffect(this);
        if (who == 0) Effect.instance.ActEnd = true;
    }
}
