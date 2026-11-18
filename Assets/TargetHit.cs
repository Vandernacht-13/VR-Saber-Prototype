
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class TargetHit : MonoBehaviour
{
    // Reference to the hit counter
    public ScoreManager scoreManager;

    // Feedback settings for evaluation
    public bool enableHaptics = true;
    public bool enableHitSound = true;

    // Controller haptics
    public HapticImpulsePlayer rightHaptics;
    public HapticImpulsePlayer leftHaptics;

    // Cube hit sound
    private AudioSource hitSound;

    // Prevent multiple hits on the same cube
    private bool hasBeenHit = false;

    void Start()
    {
        // Find the AudioSource attached to the cube
        hitSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Ignore additional collisions
        if (hasBeenHit)
            return;

        // Check whether a saber hit the cube
        bool rightSaber = other.gameObject.name == "RightSaber";
        bool leftSaber = other.gameObject.name == "LeftSaber";

        if (rightSaber || leftSaber)
        {
            hasBeenHit = true;

            // Haptic feedback
            if (enableHaptics)
            {
                if (rightSaber && rightHaptics != null)
                {
                    rightHaptics.SendHapticImpulse(0.7f, 0.15f);
                }
                else if (leftSaber && leftHaptics != null)
                {
                    leftHaptics.SendHapticImpulse(0.7f, 0.15f);
                }
            }

            // Play the hit sound
            if (enableHitSound && hitSound != null &&
                hitSound.clip != null)
            {
                // Plays independently so the cube can be destroyed
                AudioSource.PlayClipAtPoint(
                    hitSound.clip,
                    transform.position
                );
            }

            // Register one hit
            if (scoreManager != null)
            {
                scoreManager.AddPoints(1);
            }

            // Remove the cube immediately
            Destroy(gameObject);
        }
    }
}
