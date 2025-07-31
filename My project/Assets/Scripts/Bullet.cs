using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject lavaboss;
    public bool circle = false;
    public enemyDetect d;
    public GameObject enemy;
    public bool wait = false;
    public bool homming = false;  
    public float speed = 5;
    public Rigidbody2D rb;
    public float damage = 3;
    Spellform spellform;
    public GameObject DeathEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (homming)
        {
            transform.position += new Vector3(Random.Range(-4, 4), Random.Range(-4, 4));
            StartCoroutine(hommingg());
        }
        spellform = GetComponent<Spellform>();
        if (spellform.enemies)
        {
            GameObject player = GameObject.Find("Player");
            Vector3 perpendicular = transform.position - player.transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
            transform.position += -transform.up * Time.deltaTime * speed;
        }
        else
        {
            transform.position += -transform.up * Time.deltaTime * speed/10;
        }
        if (homming && spellform.enemies)
        {
            if(circle && spellform.summoner != null)
            {
               
                Vector3 perpendicular = transform.position - spellform.summoner.transform.position;
                Quaternion endRotation = Quaternion.LookRotation(Vector3.forward * Time.deltaTime, perpendicular);
                transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime);
            }
            else
            {
                GameObject player = GameObject.Find("Player");
                Vector3 perpendicular = transform.position - player.transform.position;
                Quaternion endRotation = Quaternion.LookRotation(Vector3.forward * Time.deltaTime, perpendicular);
                transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime);
            }

        }
        else
        {
            if (homming)
            {
                if (d != null && d.Enemy != null)
                {
                    Vector3 perpendicular = transform.position - d.Enemy.transform.position;
                    Quaternion endRotation = Quaternion.LookRotation(Vector3.forward * Time.deltaTime, perpendicular);
                    transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * 4);
                }
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spellform.enemies)
        {
            if (collision.tag == "Player")
            {
                Instantiate(DeathEffect, transform.position, transform.rotation);
                collision.GetComponent<Player>().health -= Random.Range(Mathf.Round(damage * 1.5f), Mathf.Round(damage * .5f));
                spellform.die();
            }
        }
        else
        {
            if (collision.tag == "Enemy")
            {
                Instantiate(DeathEffect, transform.position, transform.rotation);
                collision.GetComponent<Enemy>().Health -= Random.Range(Mathf.Round(damage * 1.5f), Mathf.Round(damage * .5f));
                spellform.die();
            }
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
    public IEnumerator hommingg()
    {
        wait = true;
        yield return new WaitForSeconds(1);
        wait = false;
    }
}
