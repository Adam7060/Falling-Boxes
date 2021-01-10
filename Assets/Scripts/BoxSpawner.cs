using UnityEngine;

public class BoxSpawner : MonoBehaviour
{


    public static float fallingSpeed;
    private readonly float fallingSpeedIncrementDelay = 5f;
    private float spawnInterval, leftBorder, rightBorder, posY;
    private readonly float maxSpeed = 500f;


    void Start()
    {
        spawnInterval = 1f;

        posY = Bounds.ScreenBounds.y;
        leftBorder = - Bounds.ScreenBounds.x;
        rightBorder = Bounds.ScreenBounds.x;

        SpawnBox();
        Invoke("IncrementFallingSpeed", fallingSpeedIncrementDelay);

    }

    private void OnEnable()
    {
        fallingSpeed = 100f;
    }

    private void IncrementFallingSpeed()
    {
        fallingSpeed = fallingSpeed >= maxSpeed ? maxSpeed : fallingSpeed + 20;
        Invoke("IncrementFallingSpeed", fallingSpeedIncrementDelay);
    }

    private void SpawnBox()
    {
        GameObject box = BoxPool.Instance.GetAvailableObject();
        if (box)
        {
            box.SetActive(true);
            box.transform.position = GetRandomSpawnPosition(box);

        }
        spawnInterval = 0.3f + (10000f / (fallingSpeed * fallingSpeed));
        Invoke("SpawnBox", spawnInterval);
    }

    private Vector2 GetRandomSpawnPosition(GameObject box)
    {
        float posX = Random.Range(leftBorder, rightBorder);
        return new Vector2(posX, posY);
    }
}
