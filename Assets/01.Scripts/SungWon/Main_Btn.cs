using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Btn : MonoBehaviour
{
    public Button btn;

    public Sprite On;
    public Sprite Off;

    public AudioSource click;


    private void Start()
    {
        click = gameObject.AddComponent<AudioSource>();
    }

    public void MouseEnter()
    {
      
        this.btn.GetComponent<Image>().sprite = On;
       
        
    }

    public void MouseExit()
    {
        this.btn.GetComponent<Image>().sprite = Off;
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("SoonMok");
    }
    public void DictionaryBtn()
    {
        SceneManager.LoadScene("Dictionary");
    }
}
