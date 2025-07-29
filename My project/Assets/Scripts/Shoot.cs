using NUnit.Framework;
using System.Collections.Generic;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;


public class Shoot : MonoBehaviour
{
    public List<GameObject> Spells = new List<GameObject>();
    public int count = 0;
    public float timerMax = 2;
    public float reloadTimer = 0;
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = transform.root.gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= Spells.Count)
        {
            Debug.Log(count + "dd");
            count = 0;
        }
        reloadTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && reloadTimer <= 0 && !player.digging)
        {
            
            reloadTimer = timerMax;
            GameObject spellzz = Instantiate(Spells[count], transform.position, Quaternion.identity);
            Spellform sp = spellzz.GetComponent<Spellform>();
            count++;
            if (sp != null)
            {
                sp.enemies = false;
                if (sp.prongMod)
                {
                    Debug.Log(count);
                    while (count < Spells.Count)
                    {
                        Debug.Log(count + "d");
                        sp.go.Add(Spells[count]);
                        count++;
                        if (count < Spells.Count)
                        {
                            Spellform d = Spells[count].GetComponent<Spellform>();
                            if (d != null && !d.prongMod)
                            {
                                sp.go.Add(Spells[count]);
                                count++;
                                break;
                            }
                        }
                        
                    }
                }
                if (sp.teleport)
                {
                    sp.summoner = transform.root.gameObject;
                }
                if (sp.rotateright)
                {
                    spellzz.transform.rotation = transform.rotation;
                }
            }
        }
    }
}
