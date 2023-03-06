using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
         if (GameManager.Instance.IsGameOver())
            return;

        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            cooldown = GameManager.Instance.obstacleInterval;
            List<GameObject> obstacle = GameManager.Instance.obstaclePrefabs;
            var position = new Vector3(13, Random.Range(GameManager.Instance.obstacleOffsetY.x, GameManager.Instance.obstacleOffsetY.y), -0.33f);
            Quaternion rotation = transform.rotation;
            Instantiate( obstacle[Random.Range(0, obstacle.Count)], position, rotation );
        }
    }
}
