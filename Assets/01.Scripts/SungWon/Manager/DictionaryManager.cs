using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DictionaryManager : MonoBehaviour
{
    public void ExitBtn()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void XBtn()
    {
        SceneManager.LoadScene("Dictionary");
    }

}
