
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class TargetHit : MonoBehaviour
{
    private Renderer cubeRenderer;
    private AudioSource hitSound;

    public HapticImpulsePlayer rightHaptics;
    public HapticImpulsePlayer leftHaptics;
    private bool hasBeenHit = false;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        hitSound = GetComponent<AudioSource>();
        cubeRenderer.material.color = Color.red;
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasBeenHit)
            return;

       if (other.gameObject.name == "RightSaber" ||
    other.gameObject.name == "LeftSaber")
{
    if (other.gameObject.name == "RightSaber")
    {
        rightHaptics.SendHapticImpulse(0.7f, 0.15f);
    }
    else
    {
        leftHaptics.SendHapticImpulse(0.7f, 0.15f);
    }

    StartCoroutine(HitCube());
}
    }

    IEnumerator HitCube()
    {
        hasBeenHit = true;

        hitSound.Play();

        cubeRenderer.material.color = Color.green;

        yield return new WaitForSeconds(2f);

        cubeRenderer.material.color = Color.red;

        hasBeenHit = false;
    }
}
