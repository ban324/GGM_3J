using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryBtn : MonoBehaviour
{
    public Image Dictuonary;

   public void Main1()
    {
       Debug.Log("´­¸²");
       Dictuonary.gameObject.SetActive(true);
    }

    private void Start()
    {
        Dictuonary.gameObject.SetActive(false);
    }
}
