
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class CubeSpawner : MonoBehaviour
{
    public GameObject targetCubePrefab;
    public float spawnInterval = 3f;
    public bool enableHaptics = true;
    public bool enableHitSound = true;
    public AudioSource musicSource;

    public ScoreManager scoreManager;
    public HapticImpulsePlayer rightHaptics;
    public HapticImpulsePlayer leftHaptics;

    private float timer = 0f;

    void Update()
    {
       if (musicSource == null || !musicSource.isPlaying)
    return;

float musicTime = musicSource.time;

if (musicTime < timer)
    timer = 0f;

if (musicTime >= timer + spawnInterval)
{
    SpawnCube();
    timer = musicTime;
}
    }

    void SpawnCube()
    {
        int randomLane = Random.Range(0, 3);

float xPosition = (randomLane - 1) * 0.6f;

Vector3 spawnPosition = new Vector3(xPosition, 1.3f, 8f);

        GameObject newCube = Instantiate(
            targetCubePrefab,
            spawnPosition,
            Quaternion.identity
        );

        TargetHit targetHit = newCube.GetComponent<TargetHit>();

        targetHit.scoreManager = scoreManager;
        targetHit.rightHaptics = rightHaptics;
        targetHit.leftHaptics = leftHaptics;
        targetHit.enableHaptics = enableHaptics;
        targetHit.enableHitSound = enableHitSound;
    }
}

