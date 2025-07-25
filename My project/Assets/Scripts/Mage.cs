using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy
{
    public GameObject basesling;
    public GameObject spellSling;

    public List<GameObject> Spells = new List<GameObject>();
    public float spellsPerShot = 1;
    public float Charge = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ed.detectedFor > 0)
        {
            Vector3 perpendicular = basesling.transform.position - transform.position;
            basesling.transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);

            animator.SetBool("Casting", true);
            attckTimer -= Time.deltaTime;
            if (attckTimer < 0)
            {
                for (int i = 0; i < spellsPerShot; i++)
                {
                    StartCoroutine(Attack(Spells[Random.Range(0, Spells.Count - 1)], spellSling));
                }
                attckTimer = attackMax;
            }
        }
        else
        {
            animator.SetBool("Casting", false);
        }
        base.Update();
    }

    public IEnumerator Attack(GameObject spell, GameObject catalyst)
    {
        yield return new WaitForSeconds(Charge);
        Instantiate(spell, catalyst.transform.position, Quaternion.identity);
    }
}
