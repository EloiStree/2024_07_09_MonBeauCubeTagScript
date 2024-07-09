using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonCubeAwakeTickMono : MonoBehaviour
{
    public UnityEvent m_onAwake;
    public UnityEvent m_onStart;
     void Awake()
    {
        m_onAwake.Invoke(); 
    }
    void Start()
    {
        m_onStart.Invoke();
    }

   
}
