using System.Collections;

using UnityEngine;

public class Slime : Enemy
{
    public GameObject wall;
    public GameObject Heal;
    public bool King = false;
    public float scalePlus = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!King)
        {
            attackMax = Random.Range(2.5f, 5);

            float r = Random.Range(6f, 13f);
            transform.localScale = new Vector3(r + scalePlus, r + scalePlus);

        }
        attckTimer = attackMax;
    }

    // Update is called once per frame
    public void Update()
    {
        if (ed.detectedFor > 0 && !attacking)
        {
            Vector3 v = ed.Player.transform.position - transform.position;
            v = v.normalized;
            rb.linearVelocity = v * speed;
        }
        if (ed.detectedFor > 0)
        {
            attckTimer -= Time.deltaTime;
            if (attckTimer < 0)
            {
                StartCoroutine(Attack());
                attckTimer = attackMax;
            }
        }
        if (King && Health <= 0)
        {
            Destroy(wall);
            Instantiate(Heal, transform.position, Quaternion.identity);
        }
        base.Update();
    }
    public IEnumerator Attack()
    {
        rb.linearVelocity = (ed.Player.transform.position - transform.position).normalized * 16;
        attacking = true;
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(2.2f);
        animator.SetBool("Jump", false);
        attacking = false;
    }
    public IEnumerator explode()
    {
        animator.SetBool("Explode", true);
        yield return new WaitForSeconds(.5f);
        GetComponent<Spellform>().die();
    }
}
