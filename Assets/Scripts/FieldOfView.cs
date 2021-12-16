using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FieldOfView : MonoBehaviour
{

    
    //variables
    public float fov = 90f;
    public int raycont = 50;

    public float viewDistance = 10f;


    private float angleIncrease;
    private Mesh mesh;

    void Start()
    {

        //init variable
        

        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 origin = Vector3.zero;
        
        Vector3[] vectices = new Vector3[raycont + 2];
        Vector2[] uv = new Vector2[vectices.Length];
        int[] triangles = new int[raycont * 3];
        angleIncrease = fov / raycont;

        vectices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        float angle = fov;

        for (int i = 0; i <= raycont; i++)
        {
            Vector3 vertex = origin + GetVectorFromAngle(angle) * viewDistance;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance);
            if (raycastHit2D.collider == null)
            {
                //No Hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                //Hit
                vertex = raycastHit2D.point;
            }


            vectices[vertexIndex] = vertex;

            if (i > 0)
             {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;

            }

            vertexIndex++;
            angle -= angleIncrease;
        }

       

        mesh.vertices = vectices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }


    //Help Functions
    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

}
