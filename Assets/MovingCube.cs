
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    // Speed at which the cube moves towards the player
    public float moveSpeed = 1f;

    void FixedUpdate()
    {
        // Move the cube towards the player
        transform.position += Vector3.back * moveSpeed * Time.fixedDeltaTime;
    }

    void Update()
    {
        // Remove cubes that have passed the player
        if (transform.position.z < -2f)
        {
            Destroy(gameObject);
        }
    }
}
