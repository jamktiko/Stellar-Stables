using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallScroller : MonoBehaviour
{
    public void OnHeldUp()
    {
        StablesScroller.instance.OnHeldUp();
    }
    public void OnReleaseUp()
    {
        StablesScroller.instance.OnReleaseUp();
    }
    public void OnHeldDown()
    {
        StablesScroller.instance.OnHeldDown();
    }
    public void OnReleaseDown()
    {
        StablesScroller.instance.OnReleaseDown();
    }
}
