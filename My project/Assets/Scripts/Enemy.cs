using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthBefore;
    public GameObject HurtText;

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
    void Awake()
    {
        healthBefore = Health;
    }

    // Update is called once per frame
    public void Update()
    {
        if(Health != healthBefore)
        {
            GameObject h = Instantiate(HurtText, new Vector3(transform.position.x + 1.5f, transform.position.y), Quaternion.identity);
            h.GetComponent<TextMeshPro>().text = "-" + (Mathf.Round((healthBefore - Health) * 10)/10).ToString();
            h.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, 1, 0);
            ed.detectedFor = 2;
            ed.Player = GameObject.FindGameObjectWithTag("Player");
        }
            healthBefore = Health;
        if (Health <= 0)
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
