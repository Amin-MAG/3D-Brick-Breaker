using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class BallController : MonoBehaviour
{
    private const float NormalMoveAmount = 0.068f;

    [Range(-1f, 1f)] public float leftMoveAmount = 0.068f;
    [Range(-1f, 1f)] public float rightMoveAmount = -0.068f;
    [Range(-1f, 1f)] public float frontMoveAmount = -0.068f;
    [Range(-1f, 1f)] public float backMoveAmount = 0.068f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.rightMoveAmount = -NormalMoveAmount;
            this.transform.position += new Vector3(this.leftMoveAmount, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.leftMoveAmount = NormalMoveAmount;
            this.transform.position += new Vector3(this.rightMoveAmount, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.backMoveAmount = NormalMoveAmount;
            this.transform.position += new Vector3(0, 0, this.frontMoveAmount);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.frontMoveAmount = -NormalMoveAmount;
            this.transform.position += new Vector3(0, 0, this.backMoveAmount);
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

        if (collision.gameObject.CompareTag(Tags.FrontWall.ToString()))
        {
            this.frontMoveAmount = 0;
            Debug.Log("Collision with front wall");
        }
        
        if (collision.gameObject.CompareTag(Tags.Rocket.ToString()))
        {
            this.backMoveAmount = 0;
            Debug.Log("Collision with rocket");
        }
    }
}