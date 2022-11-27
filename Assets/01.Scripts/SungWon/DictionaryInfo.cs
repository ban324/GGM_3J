using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DictionaryInfo : MonoBehaviour
{
    public Sprite Card1;
    public Image info;

    public RectTransform Panel;

    private void Start()
    {
        Panel.DOAnchorPos(new Vector2(2000, 0), 0.25f);
    }

    public void Card_1()
    {
        Panel.DOAnchorPos(new Vector2(0,0), 0.25f);      
        info.GetComponent<Image>().sprite = Card1;
    }

    
}
