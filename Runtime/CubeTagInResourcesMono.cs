using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeTagInResourcesMono : MonoBehaviour
{

    public GameObject[] m_allCubePrefabInResources;
    public List<PerNameCube> m_perNameCubes = new List<PerNameCube>();


    [System.Serializable]
    public class PerNameCube
    {
        public string m_name;
        public List<GameObject> m_cubes;
    }
    void Start()
    {
        LoadResources();
    }

    [ContextMenu("Reload from Resources Cubes")]
    public void LoadResources()
    {
        m_perNameCubes.Clear();
        m_allCubePrefabInResources = Resources.LoadAll<GameObject>("");
        m_allCubePrefabInResources= m_allCubePrefabInResources.Where(k=>k.GetComponent<MonCubeCreditMono>()!=null).ToArray();
        bool found = false;
        foreach (var cube in m_allCubePrefabInResources)
        {
            MonCubeCreditMono credit = cube.GetComponent<MonCubeCreditMono>();
            string name = string.Format("{0} {1}", credit.m_lastName.ToLower(), credit.m_firstName.ToLower());
            found = false;
            foreach (var perNameCube in m_perNameCubes)
            {
                if (perNameCube.m_name == name)
                {
                    perNameCube.m_cubes.Add(cube);
                    found = true;
                }
            }
            if (!found)
            {

                PerNameCube newPerNameCube = new PerNameCube();
                newPerNameCube.m_name = name;
                newPerNameCube.m_cubes = new List<GameObject>();
                newPerNameCube.m_cubes.Add(cube);
                m_perNameCubes.Add(newPerNameCube);
            }
        }
    }


}
