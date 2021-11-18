using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    public const float BallVelocity = 7.5f;

    public GameEvents gameEvents;

    [Range(0f, 20f)] public float ballVelocity = 7.5f;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.LeftWall.ToString()))
        {
            var normal = collision.contacts[0].normal;
            Debug.Log("Left Wall");
            Debug.Log("Angle is " + Vector3.Angle(normal, rb.velocity));
            // Set the new velocity
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(-1, 0, v.z) * ballVelocity;
        }

        if (collision.gameObject.CompareTag(Tags.RightWall.ToString()))
        {
            Debug.Log("Right Wall");
            // Set the new velocity
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(+1, 0, v.z) * ballVelocity;
        }

        if (collision.gameObject.CompareTag(Tags.FrontWall.ToString()))
        {
            Debug.Log("Front Wall");
            // Set the new velocity
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(v.x, 0, +1) * ballVelocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.DangerZone.ToString()))
        {
            this.gameEvents.onGameOver.Invoke();
        }
    }


    public void kickBall()
    {
        Debug.Log("Kicked");
        bool dir = Random.Range(-10.0f, 10.0f) > 0;
        var direction = new Vector3(dir ? -1 : +1, 0, -1);
        this.rb.velocity = direction * this.ballVelocity;
    }

    public void Stop()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
}