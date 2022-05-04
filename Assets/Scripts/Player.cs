using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D myRig;
    public float jump;
    public SpriteRenderer sr;
    public int score;
    public UI ui;

    private void FixedUpdate()
    {
        float xinput = Input.GetAxis("Horizontal");

        myRig.velocity = new Vector2(xinput * MoveSpeed, myRig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && IsOnTheGround())
        {
            myRig.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        if (myRig.velocity.x > 0)
        {
            sr.flipX = false;
        }
        else if(myRig.velocity.x < 0)
        {
            sr.flipX = true;
        }
    }


    bool IsOnTheGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0,-1f,0), Vector2.down, 0.2f);

        return hit.collider != null;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        ui.SetScoreText(score);
    }
}
