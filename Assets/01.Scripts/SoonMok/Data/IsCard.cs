using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IsCard : MonoBehaviour
{   
    public int cardId;
    public int CardCost;
    public StreamReader _reader;
    public TextAsset _textAsset;

    public void GetCard()
    {
        cardId = Random.Range(0, 14);
    }
    public void Use(int who)
    {

        CardEffect.instance.ActiveEffs[cardId].Invoke(who, 1);
    }
}
