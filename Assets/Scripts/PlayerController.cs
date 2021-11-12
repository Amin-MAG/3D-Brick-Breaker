using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class PlayerController : MonoBehaviour
{
    private const float NormalMoveAmount = 0.068f;

    [Range(0f, 1f)] public float leftMoveAmount = 0.068f;
    [Range(0f, 1f)] public float rightMoveAmount = -0.068f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) )
        {
            this.rightMoveAmount = -NormalMoveAmount;
            this.transform.position += new Vector3(leftMoveAmount, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) )
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
    }
}