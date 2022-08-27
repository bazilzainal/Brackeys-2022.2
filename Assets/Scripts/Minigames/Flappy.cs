using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{
    public float StartDistance;
    public float TotalDistance;
    public int NumObstacles;
    public GameObject Bird;
    public Obstacle Obstacle;

    private List<Obstacle> obstacles;
    private Vector2 birdStartPosition;
    private void Awake()
    {
        birdStartPosition = Bird.transform.position;
    }
    private void OnEnable()
    {
        if (obstacles != null)
        {
            foreach (var obstacle in obstacles)
            {
                Destroy(obstacle.gameObject);
            }
        }

        Bird.transform.position = birdStartPosition;
        Bird.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
        obstacles = new List<Obstacle>();
        for (var i = 0; i < NumObstacles; i += 1)
        {
            obstacles.Add(GenerateObstacle(StartDistance + TotalDistance / NumObstacles * i));
        }
    }

    private Obstacle GenerateObstacle(float x)
    {
        var obstacle = Instantiate(Obstacle, this.transform.position + new Vector3(x, 0, 0), Quaternion.identity, this.transform);
        obstacle.RandomizeHeight();
        return obstacle;
    }

    private void Update()
    {
        if (Bird.transform.position.x > TotalDistance)
        {
            GameManager.instance.MinigameWon();
        }
    }
}