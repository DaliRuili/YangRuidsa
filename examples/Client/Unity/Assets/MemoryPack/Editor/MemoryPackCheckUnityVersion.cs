using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

internal class MemoryPackCheckUnityVersion
{
    [InitializeOnLoadMethod]
    private static void OnInitializeOnLoad()
    {
#if !UNITY_2022_3_OR_NEWER
        Debug.LogError("MemoryPack支持的最低版本为Unity2022.3.12f1");
#endif
    }
}
