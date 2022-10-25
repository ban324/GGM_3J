using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    #region UI 선언 

    //public Button starBtn;
    //public Button achievementBtn;
    public Button DictionaryBtn;
    public GameObject Dictionary;

    #endregion

    public GameObject DictionaryWin;
    public Vector2 OriginPos;

    protected bool isUI;

    private void Start()
    {

        OriginPos = new Vector2(0, 0);
    }

    public void DicBtn()
    {
        isUI = false;

        DictionaryWin.transform.DOMove(OriginPos, 1);

        VisiableUI();

        Debug.Log("버튼 작동");
    }

    public void VisiableUI()
    {
        if (isUI)
        {
            Dictionary.SetActive(true);
        }
        else
        {
            Dictionary.SetActive(false);
        }
    }
}
