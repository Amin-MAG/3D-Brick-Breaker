﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class BallController : MonoBehaviour
{
    public const float BallVelocity = 7.5f;
    private const float NormalMoveAmount = 0.068f;

    [Range(0f, 20f)] public float ballVelocity = 7.5f;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        var direction = new Vector3(+1, 0, -1);
        rb.velocity = direction * this.ballVelocity;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.LeftWall.ToString()))
        {
            var normal = collision.contacts[0].normal;
            Debug.Log("Angle is " + Vector3.Angle(normal, rb.velocity));

            // Set the new velocity
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(-1, 0, v.z) * ballVelocity;
        }

        if (collision.gameObject.CompareTag(Tags.RightWall.ToString()))
        {
            // Set the new velocity
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(+1, 0, v.z) * ballVelocity;
        }

        if (collision.gameObject.CompareTag(Tags.FrontWall.ToString()))
        {
            // Set the new velocity
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(v.x, 0, +1) * ballVelocity;
        }

        if (collision.gameObject.CompareTag(Tags.Rocket.ToString()))
        {
            // Set the new velocity
            var v = MovementUtility.GetVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(v.x, 0, -1) * ballVelocity;
        }

        if (collision.gameObject.CompareTag(Tags.WoodenBox.ToString()))
        {
            Debug.Log("collide");
        }
    }
    
}