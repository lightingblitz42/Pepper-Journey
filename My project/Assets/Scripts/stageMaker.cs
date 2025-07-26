using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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
    public void ConnectIsland(Island nl)
    {
        for(int i = 1; i < nl.Exits.Count + 1; i++)
        {
            if (i == 2)
            {
                connectUp(nl);
            }
            if(i == 3)
            {
                connectRight(nl);
            }
        }
    }
    public void connectRight(Island nl)
    {
        if (island1Right.Count > 0)
        {
            int num = Random.Range(0, island1Right.Count - 1);
            Debug.Log(num);
            island1Right[num].Exits[0].goTo = nl.teleportCamera[2].transform.parent;
            island1Right[num].Exits[0].CamGoTo = nl.teleportCamera[2].transform;
            nl.Exits[2].goTo = island1Right[num].teleportCamera[0].transform.parent;
            nl.Exits[2].CamGoTo = island1Right[num].teleportCamera[0].transform;
            Island hold = island1Right[num];
            island1Right.RemoveAt(num);
            ConnectIsland(hold);
        }
        else
        {
            int num = Random.Range(0, island0Right.Count - 1);
            island0Right[num].Exits[0].goTo = nl.teleportCamera[2].transform.parent;
            island0Right[num].Exits[0].CamGoTo = nl.teleportCamera[2].transform;
            nl.Exits[2].goTo = island0Right[num].teleportCamera[0].transform.parent;
            nl.Exits[2].CamGoTo = island0Right[num].teleportCamera[0].transform;
            island0Right.RemoveAt(num);
        }
    }
    public void connectUp(Island nl)
    {
        if (ups == 1)
        {
            if (nl.Exits[1] == null)
            {
                connectUp(nl);
                return;
            }
            else
            {
                Debug.Log("did it");
                EndIsland.Exits[0].goTo = nl.teleportCamera[1].transform.parent;
                nl.Exits[1].goTo = EndIsland.teleportCamera[0].transform.parent;

                EndIsland.Exits[0].CamGoTo = nl.teleportCamera[1].transform;
                nl.Exits[1].CamGoTo = EndIsland.teleportCamera[0].transform;
            }
        }
        else if (island1Up.Count > 0)
        {
            int num = Random.Range(0, island1Up.Count - 1);
            if(nl.Exits[1] != null)
            {
                island1Up[num].Exits[0].goTo = nl.teleportCamera[1].transform.parent;
                nl.Exits[1].goTo = island1Up[num].teleportCamera[0].transform.parent;

                island1Up[num].Exits[0].CamGoTo = nl.teleportCamera[1].transform;
                nl.Exits[1].CamGoTo = island1Up[num].teleportCamera[0].transform;
                Island hold = island1Up[num];
                island1Up.RemoveAt(num);
                ConnectIsland(hold);
                
            }
        }
        else
        {
            if (nl.Exits[1] != null)
            {
                Debug.Log(island0Up.Count + " " + nl.name);
                int num = Random.Range(0, island0Up.Count - 1);
                island0Up[num].Exits[0].goTo = nl.teleportCamera[1].transform.parent;
                nl.Exits[1].goTo = island0Up[num].teleportCamera[0].transform.parent;

                island0Up[num].Exits[0].CamGoTo = nl.teleportCamera[1].transform;
                nl.Exits[1].CamGoTo = island0Up[num].teleportCamera[0].transform;
                island0Up.RemoveAt(num);
            }
        }
        ups++;
    }
}
