using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    #region UI ���� 

   /* public Button starBtn;
    public Button DictionaryBtn;
    public Button achievementBtn;
    public Button SettingNtn;*/

    #endregion

    public Image DictionaryWin;
    public Vector2 OriginPos;

    private void Start()
    {
        OriginPos = new Vector2(0, 0);

        DictionaryWin.GetComponent<RectTransform>();

    }

    public void DicBtn()
    {
        DictionaryWin.rectTransform.DOMove(OriginPos, 1);
        Debug.Log("����");
    }

    public void StBtn()
    {
        Debug.Log("���� ����");
    }
    
    public void SettBtn()
    {
        Debug.Log("����");
    }
    
    public void AchiveBtn()
    {
        Debug.Log("��������");
    }

    
}
