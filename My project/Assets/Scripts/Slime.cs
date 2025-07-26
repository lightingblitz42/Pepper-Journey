using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackMax = Random.Range(2.5f, 5);
        attckTimer = attackMax;
        float r = Random.Range(6f, 13f);
        transform.localScale = new Vector3(r, r);
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
}
