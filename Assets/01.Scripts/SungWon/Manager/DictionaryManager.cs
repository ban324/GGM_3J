using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DictionaryManager : MonoBehaviour
{
    public Button btn;

    public void ExitBtn()
    {
        SceneManager.LoadScene("Main");
    }


}
