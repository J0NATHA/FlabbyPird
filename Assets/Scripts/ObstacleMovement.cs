using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.IsGameOver())
            return;

        transform.position -= new Vector3(1, 0, 0) * GameManager.Instance.obstacleSpeed * Time.fixedDeltaTime;

        if (transform.position.x <= -13f)
            Destroy(gameObject);
    }
}
