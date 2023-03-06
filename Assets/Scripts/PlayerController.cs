using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidBody;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpInterval;
    private float jumpCooldown;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        bool canJump = jumpCooldown <= 0 && GameManager.Instance.IsGameActive();
        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);

            if (jumpInput)
                Jump();
        }
        thisRigidBody.useGravity = GameManager.Instance.IsGameActive();
    }

    private void OnCollisionEnter(Collision collision)
    {
        thisRigidBody.velocity = Vector3.zero;
        GameManager.Instance.EndGame();
    }

    void Jump()
    {
        jumpCooldown = jumpInterval;

        thisRigidBody.velocity = Vector3.zero;
        thisRigidBody.AddForce(new Vector3(0f, jumpForce), ForceMode.Impulse);
    }
}
