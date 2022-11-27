using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardData : MonoBehaviour
{
    [SerializeField] private UnityEngine.Object _csvFile;
    StreamReader Datas;
    public List<string[]> effects;//권순목 제작. 제네릭
    private string effectLine; 
    private void Awake()
    {
        effects = new List<string[]>();
        Datas = new StreamReader(Application.dataPath + "/"+_csvFile.name+".csv");
        while (true)
        {//권순목 제작. 예외처리
            try
            {
                effectLine = Datas.ReadLine();
                if (effectLine == ",,,,,,,,,,,,,")
                {
                    continue;
                }
                    effects.Add(effectLine.Split(","));
                if (!(effectLine == null))
                {
                }
                else effectLine.Remove(effectLine.Length -1);
            }
            catch (NullReferenceException ex)
            {
                break;
            }
        }
    }
}
