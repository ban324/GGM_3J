using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class UIManager : MonoBehaviour
{
    #region UI ���� 

   /* public Button starBtn;
    public Button DictionaryBtn;
    public Button achievementBtn;
    public Button SettingNtn;*/

    #endregion


    private void Start()
    {
       
    }
    
    public void HomeBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void StBtn()
    {
        SceneManager.LoadScene("SoonMok");
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
