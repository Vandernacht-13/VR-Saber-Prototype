
using UnityEngine;

public class SaberWhoosh : MonoBehaviour
{
    private AudioSource whooshSound;
    private Vector3 previousPosition;

    public float swingSpeed = 1.5f;
    public float cooldown = 0.8f;

    private float lastWhooshTime = -10f;

    void Start()
    {
        whooshSound = GetComponent<AudioSource>();
        previousPosition = transform.position;
    }

    void Update()
    {
        float speed = Vector3.Distance(
            transform.position,
            previousPosition
        ) / Mathf.Max(Time.deltaTime, 0.0001f);

        if (speed > swingSpeed &&
            Time.time - lastWhooshTime > cooldown &&
            !whooshSound.isPlaying)
        {
            whooshSound.Play();
            lastWhooshTime = Time.time;
        }

        previousPosition = transform.position;
    }
}
