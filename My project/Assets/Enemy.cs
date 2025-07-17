using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enemyDetection ed;
    public GameObject Player;
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
        if(ed.detectedFor > 0 && !attacking)
        {
            Vector3 v = Player.transform.position - transform.position;
            v = v.normalized;
            rb.linearVelocity = v * speed;
        }
    }
}
