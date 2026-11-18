
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class CubeSpawner : MonoBehaviour
{
    public GameObject targetCubePrefab;

    // Spawn one cube every 2 seconds
    public float spawnInterval = 2f;

    // Enable or disable feedback for evaluation
    public bool enableHaptics = true;
    public bool enableHitSound = true;

    // Existing references
    public ScoreManager scoreManager;
    public HapticImpulsePlayer rightHaptics;
    public HapticImpulsePlayer leftHaptics;

    private float nextSpawnTime;

    void Start()
    {
        // First cube appears after 2 seconds
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Spawn cubes independently of music
        if (Time.time >= nextSpawnTime)
        {
            SpawnCube();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnCube()
    {
        // Choose one of three lanes
        int randomLane = Random.Range(0, 3);

        float xPosition = (randomLane - 1) * 0.6f;

        Vector3 spawnPosition = new Vector3(
            xPosition, 1.3f, 8f
        );

        // Create the cube
        GameObject newCube = Instantiate(
            targetCubePrefab,
            spawnPosition,
            Quaternion.identity
        );

        // Connect feedback and hit counter
        TargetHit targetHit = newCube.GetComponent<TargetHit>();

        if (targetHit != null)
        {
            targetHit.scoreManager = scoreManager;
            targetHit.rightHaptics = rightHaptics;
            targetHit.leftHaptics = leftHaptics;
            targetHit.enableHaptics = enableHaptics;
            targetHit.enableHitSound = enableHitSound;
        }
    }
}
