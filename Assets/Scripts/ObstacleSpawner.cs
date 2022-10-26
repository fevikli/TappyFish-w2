using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    //variables
    public float maxTime;
    private float timer;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    private float randomY;
    //end of variables

    //game objects
    public GameObject obstaclePrefab;
    //end of gameobjects


    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }
}
