

using UnityEngine;

public class BrokenCube : MonoBehaviour
{
    public float breakForce = 2f;

    void Start()
    {
        Rigidbody leftHalf = transform.Find("CubeHalf_Left")
            .GetComponent<Rigidbody>();

        Rigidbody rightHalf = transform.Find("CubeHalf_Right")
            .GetComponent<Rigidbody>();

        leftHalf.isKinematic = false;
        rightHalf.isKinematic = false;

        leftHalf.AddForce(Vector3.left * breakForce,
            ForceMode.Impulse);

        rightHalf.AddForce(Vector3.right * breakForce,
            ForceMode.Impulse);

        Destroy(gameObject, 3f);
    }
}
