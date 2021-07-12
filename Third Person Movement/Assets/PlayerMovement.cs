using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            Debug.Log("jum[");
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z= Input.GetAxis("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir *= moveSpeed;
        dir.y = playerRigidbody.velocity.y;

        playerRigidbody.velocity = dir;
    }

    private void Jump()
    {
        if(CanJump())
        {
            playerRigidbody.AddForce(jumpForce * Vector3.up,ForceMode.Impulse);
        }
    }

    private bool CanJump()
    {
        Ray ray = new Ray(transform.position,Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,0.1f))
        {
            return hit.collider != null;
        }

        return false;
    }
}