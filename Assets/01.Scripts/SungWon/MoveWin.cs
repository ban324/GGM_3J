using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveWin : MonoBehaviour
{
    public RectTransform Panel;

   

    public void btn()
    {
        Panel.DOAnchorPos(new Vector2(2000,0), 0.25f);
        
    }

}
