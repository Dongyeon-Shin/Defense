using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static bool IsContain(this LayerMask layermask, int layer)
    {
        return ((1 << layer) & layermask) != 0;
    }
}
