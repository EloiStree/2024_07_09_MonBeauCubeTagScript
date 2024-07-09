using UnityEngine;

public class CubeTagScriptPerNameInLineDisplayerMono : MonoBehaviour
{
    public CubeTagInResourcesMono m_cubeTagInResourcesMono;

    public Transform m_container;



    [ContextMenu("Kill All")]
    public void KillChildrenInContainer() {

        Transform[] children = m_container.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            if (child != null && child.transform != null) { 
            if (child != m_container.transform) {


                if (Application.isEditor && !Application.isPlaying)
                {
                    DestroyImmediate(child.gameObject);
                }
                else { 
                    Destroy(child.gameObject);
                }


            }
            }
        }
    }

    [ContextMenu("Spawn")]
    public void Spawn() {
        KillChildrenInContainer();
        int userCount = 0;
        int cubeCount = 0;
        foreach (var perNameCube in m_cubeTagInResourcesMono.m_perNameCubes)
        {
            cubeCount = 0;
            foreach (var cube in perNameCube.m_cubes)
            {
                MonCubeCreditMono credit = cube.GetComponent<MonCubeCreditMono>();
                if(credit!=null)
                {
                    string name = string.Format("Cube {2}:{0} {1}", credit.m_lastName, credit.m_firstName, cubeCount);
                    GameObject newCube = Instantiate(cube, m_container);
                    newCube.name = name;
                    newCube.transform.localPosition = Vector3.zero;
                    newCube.transform.localRotation = Quaternion.identity;
                    newCube.transform.localScale = Vector3.one;
                    newCube.transform.localPosition += new Vector3(0,cubeCount * 2, 0 );
                    newCube.transform.localPosition += new Vector3(userCount * 2,0, 0);
                }
                cubeCount++;
            }
            userCount++;
        }
    }
}