using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy
{
    public stageMaker stageMaker;
    public GameObject basesling;
    public GameObject spellSling;

    public List<GameObject> Spells = new List<GameObject>();
    public float spellsPerShot = 1;
    public float Charge = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackMax = Random.Range(.3f, 3);
        attckTimer = attackMax;
        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            if(Random.value > .5f)
            {
                Spells.Add(stageMaker.TierOneSpells[Random.Range(0, stageMaker.TierOneSpells.Count)]);
            }
            else if (Random.value > .3f)
            {
                Spells.Add(stageMaker.TierTwoSpells[Random.Range(0, stageMaker.TierTwoSpells.Count)]);
            }
            else if (Random.value > 0)
            {
                Spells.Add(stageMaker.TierThreeSpells[Random.Range(0, stageMaker.TierThreeSpells.Count)]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ed.detectedFor > 0)
        {
            Vector3 perpendicular = basesling.transform.position - transform.position;
            basesling.transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);

           // animator.SetBool("Casting", true);
            attckTimer -= Time.deltaTime;
            if (attckTimer < 0)
            {
                for (int i = 0; i < spellsPerShot; i++)
                {
                    StartCoroutine(Attack(Spells[Random.Range(0, Spells.Count)], spellSling));
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
        animator.SetBool("Casting", true);
        yield return new WaitForSeconds(Random.Range(Charge, .3f));
        animator.SetBool("Casting", false);
        GameObject spellzz = Instantiate(spell, catalyst.transform.position, Quaternion.identity);
        spellzz.GetComponent<Spellform>().enemies = true;
    }
}
