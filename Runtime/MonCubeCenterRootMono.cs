using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonCubeCenterRootMono : MonoBehaviour
{
    public Transform m_cubeRoot;
    private void Reset()
    {
        m_cubeRoot = transform;
    }
}

