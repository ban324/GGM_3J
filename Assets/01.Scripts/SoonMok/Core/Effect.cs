using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public bool ActEnd;
    public void ActSet(bool status)
    {
        ActEnd = status;
    }
}
