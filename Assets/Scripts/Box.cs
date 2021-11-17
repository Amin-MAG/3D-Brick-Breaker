using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Box : MonoBehaviour
{
    private const float Error = 0.15f;

    protected abstract int GetStartingHealth();

    public int health;

    public void Start()
    {
        this.health = this.GetStartingHealth();
        Debug.Log("Box");
    }

    public void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Ball.ToString()))
        {
            InvokeCollision(collision.gameObject);
            MoveBall(collision.gameObject);
            health--;
        }
    }

    protected void MoveBall(GameObject ball)
    {
        // Is it from front or back ?
        if (Math.Abs(this.transform.position.z - ball.transform.position.z) >
            this.gameObject.transform.localScale.x - Box.Error)
        {
            if (ball.transform.position.z > this.gameObject.transform.position.z)
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
                rb.velocity = new Vector3(v.x, 0, +1) * BallController.BallVelocity;
            }
            else
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
                rb.velocity = new Vector3(v.x, 0, -1) * BallController.BallVelocity;
            }
        }
        else
        {
            if (ball.transform.position.x > this.gameObject.transform.position.x)
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
                rb.velocity = new Vector3(+1, 0, v.z) * BallController.BallVelocity;
            }
            else
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
                rb.velocity = new Vector3(-1, 0, v.z) * BallController.BallVelocity;
            }
        }
    }


    protected void InvokeCollision(GameObject ball)
    {
    }
}