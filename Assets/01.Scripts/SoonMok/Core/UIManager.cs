using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] TextMeshProUGUI m_Cointxt;
    [SerializeField] TextMeshProUGUI e_Cointxt;
    [SerializeField] TextMeshProUGUI m_lifetxt;
    [SerializeField] TextMeshProUGUI e_lifetxt;

    [SerializeField] private GameObject _selectPanel;
    [SerializeField] private List<GameObject> _UIObjs;
    
    private void Awake()
    {
        Instance = this;
        _UIObjs.Add(_selectPanel);
        foreach(GameObject obj in _UIObjs)
        {
            obj.SetActive(false);
        }
    }
    public void SetPanel(bool status)
    {
        _selectPanel.SetActive(status);
    }

    public void SetText_mC(int amount)
    {
        m_Cointxt.text = amount.ToString();
    }
    public void SetText_eC(int amount)
    {
        e_Cointxt.text = amount.ToString();
    }
    public void SetText_mL(int amount)
    {
        m_lifetxt.text = amount.ToString();
    }
    public void SetText_eL(int amount)
    {
        e_lifetxt.text = amount.ToString();
    }
}
