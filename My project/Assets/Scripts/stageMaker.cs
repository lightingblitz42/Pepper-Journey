using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class stageMaker : MonoBehaviour
{
    public List<Transform> Camps = new List<Transform>();
    public List<float> type = new List<float>();
    public float stage = 1;
    public float dif = 1;

    public List<GameObject> TierOneSpells = new List<GameObject>();
    public List<GameObject> TierTwoSpells = new List<GameObject>();
    public List<GameObject> TierThreeSpells = new List<GameObject>();

    public List<GameObject> slimes = new List<GameObject>();
    public List<GameObject> goblins = new List<GameObject>();
    //first is boss, to 4th is elites then rabble

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < Camps.Count; i++)
        {
            if(stage == 1)
            {
                if (type[i] == 0)
                {
                    StageOne(i, slimes, Random.Range(4, 8));
                }
                if (type[i] == 1)
                {
                    StageOne(i, goblins, Random.Range(3, 13));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StageOne(int index, List<GameObject> types, int amount)
    {
        GameObject elite = Instantiate(types[(int)Random.Range(.9f, 3)], Camps[index].position, Quaternion.identity);
        for(int i = 0; i < Random.Range(2, 6); i++)
        {
            Mage mage = elite.GetComponent<Mage>();
            float rand = Random.value;
            if(rand > .9f)
            {
                mage.Spells.Add(TierThreeSpells[Random.Range(0, TierOneSpells.Count - 1)]);
            }
            else if(rand > .7f)
            {
                mage.Spells.Add(TierTwoSpells[Random.Range(0, TierOneSpells.Count - 1)]);
            }
            else
            {
                mage.Spells.Add(TierOneSpells[Random.Range(0, TierOneSpells.Count -1)]);
            }

        }
        for(int i = 0; i < amount; i++)
        {
            Instantiate(types[(int)Random.Range(3.5f, types.Count - 1)], Camps[index].position, Quaternion.identity);
        }
        
    }
}
