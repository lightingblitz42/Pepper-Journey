using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mage : Enemy
{
    public bool ally = false;
    public bool manual = false;
    public float tie = 0;

    public stageMaker stageMaker;
    public GameObject basesling;
    public GameObject spellSling;

    public int currentShot = 0;

    public List<GameObject> Spells = new List<GameObject>();
    public float spellsPerShot = 1;
    public float Charge = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(stageMaker == null)
        {
            stageMaker = GameObject.FindGameObjectWithTag("StageMaker").GetComponent<stageMaker>();
        }
        if (!manual)
        {
            attackMax = Random.Range(.8f, 3);
            if (Random.value > .6f)
            {
                Spells.Add(stageMaker.Modifiers[Random.Range(0, stageMaker.Modifiers.Count - 1)]);
            }
            for (int i = 0; i < Random.Range(2, 5); i++)
            {

                if (Random.value > .5f)
                {
                    Spells.Add(stageMaker.TierOneSpells[Random.Range(0, stageMaker.TierOneSpells.Count)]);
                }
                else if (Random.value > .1f)
                {
                    Spells.Add(stageMaker.TierTwoSpells[Random.Range(0, stageMaker.TierTwoSpells.Count)]);
                }
                else if (Random.value > 0)
                {
                    Spells.Add(stageMaker.TierThreeSpells[Random.Range(0, stageMaker.TierThreeSpells.Count)]);
                }
            }
        }
        attckTimer = attackMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentShot >= Spells.Count)
        {
            currentShot = 0;
        }
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
                    StartCoroutine(Attack(Spells[currentShot], spellSling, currentShot));
                    currentShot++;
                    if (currentShot >= Spells.Count)
                    {
                        currentShot = 0;
                    }
                }
                attckTimer = attackMax + tie;
                tie = 0;
            }
        }
        else
        {
            animator.SetBool("Casting", false);
        }
        if(Health <= 0)
        {
            int d = Random.Range(0, Spells.Count - 1);
            for(int i = 0; i < stageMaker.SpellsLetters.Count; i++)
            {
                if (Spells[d] == stageMaker.SpellsLetters[i].Spell)
                {
                    Instantiate(stageMaker.SpellsLetters[i], transform.position, Quaternion.identity);
                    break;
                }
            }
        }
        base.Update();
    }

    public IEnumerator Attack(GameObject spell, GameObject catalyst, int count)
    {
        Spellform f = spell.GetComponent<Spellform>();
        tie += f.cooldownChange;
        animator.SetBool("Casting", true);
        yield return new WaitForSeconds(Random.Range(Charge, .3f));
        animator.SetBool("Casting", false);
        GameObject spellzz = Instantiate(spell, catalyst.transform.position, Quaternion.identity);
        Spellform sp = spellzz.GetComponent<Spellform>();
        if(sp != null)
        {
            if(ally == false)
            {
                sp.enemies = true;
            }
            else
            {
                sp.ally = true;
            }
            if (sp.prongMod)
            {
                count++;
                while(count < Spells.Count)
                {

                    sp.go.Add(Spells[count]);
                    count++;
                    if (count < Spells.Count)
                    {
                        Spellform d = Spells[count].GetComponent<Spellform>();
                        if(d != null && !d.prongMod)
                        {
                            count++;
                            break;
                        }
                    }
                    
                }
            }
            if (sp.teleport)
            {
                sp.summoner = transform.root.gameObject; ;
            }
            if (sp.rotateright)
            {
                spellzz.transform.rotation = transform.rotation;
            }
        }
    }
}
