using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EffectBase : ScriptableObject
{
    delegate void Effect(int Power, int target);
    
}
