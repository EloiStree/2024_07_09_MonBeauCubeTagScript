using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonCubeGuidMono : MonoBehaviour
{
    public string m_guid = "";
    private void Reset()
    {
        RefreshGUID();

    }

    [ContextMenu("Refresh GUID")]
    private void RefreshGUID()
    {
        m_guid = Guid.NewGuid().ToString();
    }
}
