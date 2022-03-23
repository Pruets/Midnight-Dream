using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPop : MonoBehaviour
{
    void Destroy()
    {
        Destroy(gameObject);
    }
}
