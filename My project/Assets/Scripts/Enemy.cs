using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathAnim;

    public Animator animator;
    public float Health = 3;
    public enemyDetection ed;
    public Rigidbody2D rb;
    public float speed = 5;

    public float attckTimer = 4;
    public float attackMax = 4;
    public bool attacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if(Health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        GameObject ded = Instantiate(deathAnim,transform.position, Quaternion.identity);
        ded.transform.localScale = transform.localScale;
        Destroy(gameObject);
    }
}
