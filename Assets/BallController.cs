using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class BallController : MonoBehaviour
{
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
            // Set the new velocity
            var v = getVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(-1 , 0, v.z) * ballVelocity;
        }

        if (collision.gameObject.CompareTag(Tags.RightWall.ToString()))
        {
            // Set the new velocity
            var v = getVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(+1 , 0, v.z) * ballVelocity;
        }

        if (collision.gameObject.CompareTag(Tags.FrontWall.ToString()))
        {
            // Set the new velocity
            var v = getVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(v.x, 0, +1) * ballVelocity;
        }

        if (collision.gameObject.CompareTag(Tags.Rocket.ToString()))
        {
            // Set the new velocity
            var v = getVelocityDirectionVector(rb.velocity);
            rb.velocity = new Vector3(v.x, 0, -1) * ballVelocity;
        }
    }

    private Vector3 getVelocityDirectionVector(Vector3 v)
    {
        var x = v.x > 0 ? +1 : -1;
        var z = v.z > 0 ? +1 : -1;

        return new Vector3(x, 0, z);
    }
}