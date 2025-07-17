using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject follow;
    public float speed = 2;

    public bool dashDetected = false;

    public float dashTimer = 0;
    public float dashDuration = 0;
    public float DashMax = 1;
    public float CurrentDash = 0;
    public bool dashing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dashDuration > 0 )
        {
            rb.linearDamping = 0;
            dashDuration -= Time.deltaTime;
        }
        else
        {
            if (dashing)
            {
                rb.linearDamping = 5f;
                dashing = false;
                rb.linearVelocity = rb.linearVelocity / 7;
            }
        }
        if (dashTimer <= 0)
        {
            CurrentDash = 0;
        }
        else
        {
            dashTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashDetected = true;
        }

        if (dashDetected && !dashing)
        {
            dashDetected = false;
            Dash();
        }



        if(!dashing)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.linearVelocity = new Vector2(-speed, rb.linearVelocityY);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, -speed);
            }
        }
    }

    public void Dash()
    {
        if(CurrentDash < DashMax)
        {
            dashing = true;
            dashDuration = .14f;
            dashTimer = .6f;
            CurrentDash += 1;
            rb.linearVelocity = (follow.transform.position - transform.position) * 14;
        }
    }
}
