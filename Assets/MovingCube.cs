
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public float moveSpeed = 1f;

    void FixedUpdate()
    {
        transform.position += Vector3.back * moveSpeed * Time.fixedDeltaTime;
    }

    void Update()
{
    if (transform.position.z < -2f)
    {
        Destroy(gameObject);
    }
}
}

