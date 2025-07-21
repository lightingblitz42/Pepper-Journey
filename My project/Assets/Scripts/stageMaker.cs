using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class stageMaker : MonoBehaviour
{
    public float ups = 0;

    public List<float> type = new List<float>();
    public float dif = 1;

    public Island EndIsland;
    public Island startLevel;

    public List<Island> island1Up = new List<Island>();
    public List<Island> island1Right = new List<Island>();
    public List<Island> island0Up = new List<Island>();
    public List<Island> island0Right = new List<Island>();

    public List<GameObject> TierOneSpells = new List<GameObject>();
    public List<GameObject> TierTwoSpells = new List<GameObject>();
    public List<GameObject> TierThreeSpells = new List<GameObject>();

    public List<GameObject> slimes = new List<GameObject>();
    public List<GameObject> goblins = new List<GameObject>();
    //first is boss, to 4th is elites then rabble

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        connectRight(startLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void connectRight(Island nl)
    {
       // nl.
    }
    public void connectUp(NextLevel nl)
    {

    }

    public void StageOne(int index, List<GameObject> types, int amount)
    {
        GameObject elite = Instantiate(types[(int)Random.Range(.9f, 3)], transform.position, Quaternion.identity);
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
                mage.Spells.Add(TierTwoSpells[Random.Range(0, TierTwoSpells.Count - 1)]);
            }
            else
            {
                mage.Spells.Add(TierOneSpells[Random.Range(0, TierThreeSpells.Count -1)]);
            }

        }
        //for(int i = 0; i < amount; i++)
        //{
        //    Instantiate(types[(int)Random.Range(3.5f, types.Count - 1)], Camps[index].position, Quaternion.identity);
        //}
        
    }
}
