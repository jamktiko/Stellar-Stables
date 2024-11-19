using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFox : MonoBehaviour
{
    public void Collect()
    {
        FoxCounter.instance.AddFox();
        gameObject.SetActive(false);
    }
}
