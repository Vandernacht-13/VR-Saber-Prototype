
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class StarfieldGenerator : MonoBehaviour
{
    public int starCount = 400;
    public float skyRadius = 80f;
    public float starSize = 0.12f;

    void Start()
    {
        Random.InitState(12345);

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[starCount * 4];
        int[] triangles = new int[starCount * 6];

        for (int i = 0; i < starCount; i++)
        {
            Vector3 direction = Random.onUnitSphere;

            // Keep stars above the horizon.
            direction.y = Mathf.Abs(direction.y);
            direction.Normalize();

            Vector3 position = direction * skyRadius;

            // Face each star towards the centre.
            Vector3 right = Vector3.Cross(Vector3.up, direction).normalized;

            if (right.sqrMagnitude < 0.001f)
                right = Vector3.right;

            Vector3 up = Vector3.Cross(direction, right).normalized;

            int v = i * 4;
            int t = i * 6;

            vertices[v] = position - right * starSize - up * starSize;
            vertices[v + 1] = position + right * starSize - up * starSize;
            vertices[v + 2] = position + right * starSize + up * starSize;
            vertices[v + 3] = position - right * starSize + up * starSize;

            triangles[t] = v;
            triangles[t + 1] = v + 2;
            triangles[t + 2] = v + 1;

            triangles[t + 3] = v;
            triangles[t + 4] = v + 3;
            triangles[t + 5] = v + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}

