using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class PlayerController : MonoBehaviour
{
    private const float NormalMoveAmount = 0.2f;

    [Range(0f, 1f)] public float leftMoveAmount = 0.2f;
    [Range(-1f, 0f)] public float rightMoveAmount = -0.2f;


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.rightMoveAmount = -NormalMoveAmount;
            this.transform.position += new Vector3(leftMoveAmount, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.leftMoveAmount = NormalMoveAmount;
            this.transform.position += new Vector3(rightMoveAmount, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.LeftWall.ToString()))
        {
            this.leftMoveAmount = 0;
            Debug.Log("Collision with left wall");
        }

        if (collision.gameObject.CompareTag(Tags.RightWall.ToString()))
        {
            this.rightMoveAmount = 0;
            Debug.Log("Collision with left wall");
        }

        if (collision.gameObject.CompareTag(Tags.Ball.ToString()))
        {
            Debug.Log("Player");
            MoveBall(collision.gameObject);
        }
    }

    protected void MoveBall(GameObject ball)
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
        // Is it from front or back ?
        if (Math.Abs(this.transform.position.z - ball.transform.position.z) >
            this.gameObject.transform.localScale.z / 2)
        {
            float collisionPlace = this.transform.position.x - ball.transform.position.x;
            if (ball.transform.position.z > this.gameObject.transform.position.z)
            {
                rb.velocity = new Vector3(collisionPlace > 0 ? -1 : +1, 0, -1) * BallController.BallVelocity;
            }
            else
            {
                rb.velocity = new Vector3(collisionPlace > 0 ? -1 : +1, 0, -1) * BallController.BallVelocity;
            }
        }
        else
        {
            if (ball.transform.position.x > this.gameObject.transform.position.x)
            {
                rb.velocity = new Vector3(+1, 0, -1) * BallController.BallVelocity;
            }
            else
            {
                rb.velocity = new Vector3(-1, 0, -1) * BallController.BallVelocity;
            }
        }
    }
}