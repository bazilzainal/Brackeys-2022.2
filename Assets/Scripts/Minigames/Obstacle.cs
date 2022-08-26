using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject BottomObstacle;
    public GameObject TopObstacle;
    public float MaxHeight;
    public float MinOffset;
    public Vector2 HoleSizeRange;
    public void RandomizeHeight()
    {
        var holeSize = UnityEngine.Random.Range(HoleSizeRange.x, HoleSizeRange.y);
        var holeHeight = UnityEngine.Random.Range(MinOffset, MaxHeight - MinOffset);

        SetupObstacle(BottomObstacle, (holeHeight - holeSize / 2f) / 2f, holeHeight - holeSize / 2f);
        var topHeight = MaxHeight - holeHeight - holeSize / 2f;
        SetupObstacle(TopObstacle, holeHeight + topHeight / 2f + holeSize / 2f, topHeight);

    }

    private static void SetupObstacle(GameObject obstacle, float yPosition, float height)
    {
        var tempPosition = obstacle.transform.position;
        tempPosition.y = yPosition;
        obstacle.transform.position = tempPosition;

        var scale = obstacle.transform.localScale;
        scale.y = height;
        obstacle.transform.localScale = scale;
    }
}