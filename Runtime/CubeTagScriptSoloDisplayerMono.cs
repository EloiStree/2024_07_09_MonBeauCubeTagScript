using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTagScriptSoloDisplayerMono : MonoBehaviour { 
    public CubeTagInResourcesMono m_source;
    public float m_timeBetweenChange = 1.0f;
    public Transform m_whereToSpawn;
    public GameObject m_created;
    public List<GameObject> m_cubes = new List<GameObject>();
    public int m_index;
    private void Awake()
    {
        RefreshList();
    }

    [ContextMenu("Refresh List")]
    private void RefreshList()
    {
        m_cubes.Clear();
        m_source.LoadResources();
        foreach (var perNameCube in m_source.m_perNameCubes)
        {
            m_cubes.AddRange(perNameCube.m_cubes);
        }
        Shuffle(m_cubes);
    }

    private void Shuffle(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    [ContextMenu("Destroy Current")]
    public void DestroyCurrent() {
        if (m_created != null)
        {
            if (Application.isPlaying)
                Destroy(m_created);
            else
                DestroyImmediate(m_created);
        }
    }

    [ContextMenu("Next")]
    public void Next()
    {

        m_index++;
        RefreshFromIndex();
    }
    [ContextMenu("Previous")]
    public void Previous()
    {

        m_index--;
        RefreshFromIndex();
    }

    private void RefreshFromIndex()
    {
        DestroyCurrent();
        if (m_index < 0)
            m_index = m_cubes.Count - 1;
        if (m_index >= m_cubes.Count)
            m_index = 0;
        if (m_cubes.Count > 0) { 
            m_created = Instantiate(m_cubes[m_index], m_whereToSpawn);
            m_created.transform.localPosition = Vector3.zero;
            m_created.transform.localRotation = Quaternion.identity;
            m_created.transform.localScale = Vector3.one;
            MonCubeCreditMono credit = m_created.GetComponent<MonCubeCreditMono>();
            if (credit != null)
            {
               string name= credit.m_firstName + " " + credit.m_lastName;
                m_created.name = name;
            }
        }
    }
}
