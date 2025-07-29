using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public float damage = 3;
    Spellform spellform;
    public GameObject DeathEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spellform = GetComponent<Spellform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
            collision.GetComponent<Enemy>().Health -= Random.Range(Mathf.Round(damage*1.5f),Mathf.Round(damage *.5f));
            spellform.die();
        }
        if(collision.tag == "wall")
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
            spellform.die();
        }
        if (collision.tag == "Wall2" && gameObject.GetComponent<Spellform>().teleport)
        {
            spellform.die();
        }
    }
}
