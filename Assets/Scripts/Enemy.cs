using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Vector3 startPosition;
    public Vector3 targetPosition;

    public float moveSpeed;
    private bool movingTowardTargetPosition;


    void Start()
    {
        //at the start fuction we set our initial start position
        startPosition = transform.position;
        movingTowardTargetPosition = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingTowardTargetPosition == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            //we are at target position
            if (transform.position == targetPosition)
            {
                movingTowardTargetPosition = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

            //we are at start position
            if (transform.position == startPosition)
            {
                movingTowardTargetPosition = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().GameOver();
        }
    }
}
