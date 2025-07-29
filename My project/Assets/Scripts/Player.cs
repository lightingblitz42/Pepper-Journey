using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject DiggerParts;
    public bool digging = false;
    public bool immune = false;
    public bool started = false;
    public float health = 60;

    public Rigidbody2D rb;
    public GameObject follow;
    public float speed = 2;

    public bool dashDetected = false;

    public Animator animator;
    public float dashspeed = 1;

    public float dashTimer = 0;
    public float dashDuration = 0;
    public float DashMax = 1;
    public float CurrentDash = 0;
    public bool dashing = false;

    public GameObject DashAnimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            StartCoroutine(death());
        }
        if (digging)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
        if (started)
        {
            if (dashDuration > 0)
            {
                rb.linearDamping = 0;
                dashDuration -= Time.deltaTime;
            }
            else
            {
                if (dashing)
                {

                    if (animator.GetInteger("Direction") == 0)
                    {
                        if (transform.localScale.x == -1)
                        {
                            Instantiate(DashAnimation, transform.position, Quaternion.Euler(0, 0, 180));
                        }
                        else
                        {
                            Instantiate(DashAnimation, transform.position, Quaternion.Euler(0, 0, 0));
                        }
                    }
                    else if (animator.GetInteger("Direction") == 1)
                    {
                        Instantiate(DashAnimation, transform.position, Quaternion.Euler(0, 0, 90));
                    }
                    else if (animator.GetInteger("Direction") == -1)
                    {
                        Instantiate(DashAnimation, transform.position, Quaternion.Euler(0, 0, -90));
                    }
                    rb.linearDamping = 9f;
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



            if (!dashing)
            {
                animator.SetBool("Running", false);
                if (Input.GetKey(KeyCode.A))
                {
                    rb.linearVelocity = new Vector2(-speed, rb.linearVelocityY);
                    animator.SetInteger("Direction", 0);
                    animator.SetBool("Running", true);
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    animator.SetInteger("Direction", 0);
                    rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
                    animator.SetBool("Running", true);
                    transform.localScale = new Vector3(1, 1, 1);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocityX, speed);
                    animator.SetInteger("Direction", 1);
                    animator.SetBool("Running", true);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocityX, -speed);
                    animator.SetInteger("Direction", -1);
                    animator.SetBool("Running", true);
                }
            }
        }
       
    }
    public void startedd()
    {
        started = true;
        Camera.main.GetComponent<CameraManager>().started = true;
    }
    public IEnumerator death()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "damage" && immune != true)
        {
            immune = true;
            health -= collision.transform.root.GetComponent<Spellform>().damage;
            StartCoroutine(unImmune());
        }
    }
    IEnumerator unImmune()
    {
        yield return new WaitForSeconds(.2f);
        immune = false;
    }
    public IEnumerator Digging()
    {
        digging = true;
        transform.GetComponent<BoxCollider2D>().enabled = false;
        Instantiate(DiggerParts, transform.root, false);
        yield return new WaitForSeconds(2);
        transform.GetComponent<BoxCollider2D>().enabled = true;
        digging = false;
    }
    public void Dash()
    {
        if(CurrentDash < DashMax)
        {
            dashing = true;
            dashDuration = .2f;
            dashTimer = .6f;
            CurrentDash += 1;
            float dir = animator.GetInteger("Direction");
            if(dir == 0)
            {
                rb.linearVelocity = new Vector2(dashspeed * transform.localScale.x * 8, rb.linearVelocityY);
            }
            else
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, dashspeed * 8 * dir);
            }
        }
    }
}
