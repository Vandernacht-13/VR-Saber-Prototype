
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class TargetHit : MonoBehaviour
{
    public ScoreManager scoreManager;

    public GameObject brokenCubePrefab;

    private Renderer cubeRenderer;
    private AudioSource hitSound;

    public bool enableHaptics = true;
    public bool enableHitSound = true;

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
        if (enableHaptics)
        {
            if (other.gameObject.name == "RightSaber")
            {
                rightHaptics.SendHapticImpulse(0.7f, 0.15f);
            }
            else
            {
                leftHaptics.SendHapticImpulse(0.7f, 0.15f);
            }
        }

        StartCoroutine(HitCube());
    }
}

    IEnumerator HitCube()
    {
        hasBeenHit = true;

        scoreManager.AddPoints(10);

        // hitSound.Play();

        if (enableHitSound)
{
    hitSound.Play();
}

        cubeRenderer.material.color = Color.green;

        Instantiate(brokenCubePrefab, transform.position, transform.rotation);
        cubeRenderer.enabled = false;
        GetComponent<MovingCube>().enabled = false;
        Destroy(gameObject, 1f);

        yield return new WaitForSeconds(2f);

        cubeRenderer.material.color = Color.red;
        cubeRenderer.enabled = true;

        hasBeenHit = false;
    }
}
