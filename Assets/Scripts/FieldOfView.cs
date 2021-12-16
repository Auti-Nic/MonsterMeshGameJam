using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FieldOfView : MonoBehaviour
{

    [SerializeField] private LayerMask layerMask;
    //variables
    public float fov = 90f;
    public int raycont = 50;

    public float viewDistance = 10f;

    private Mesh mesh;
    private Vector3 origin;
    private float startAngle ; //default is 0f

    void Start()
    {

        //init variable

        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        

    }

    // Update is called once per frame
    void Update()
    {

        
        Vector3[] vectices = new Vector3[raycont + 2];
        Vector2[] uv = new Vector2[vectices.Length];
        int[] triangles = new int[raycont * 3];
        float angleIncrease = fov / raycont;
        float angle = startAngle;
        
        vectices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        

        for (int i = 0; i <= raycont; i++)
        {
            Vector3 vertex = origin + GetVectorFromAngle(angle) * viewDistance;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance,layerMask) ;
            if (raycastHit2D.collider == null)
            {
                //No Hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                //Hit, active collectable object
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

    


    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startAngle = GetAngleFromVectorFloat(aimDirection);// - fov/2f ;
    }

    //Help Functions
    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
