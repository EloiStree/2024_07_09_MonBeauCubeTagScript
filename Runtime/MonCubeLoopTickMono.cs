using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonCubeLoopTickMono : MonoBehaviour
{

    public float m_loopTiming = 1.0f;
    public UnityEvent m_onTick;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_loopTiming);
            yield return new WaitForEndOfFrame();
            m_onTick.Invoke();
        }
    }

}
