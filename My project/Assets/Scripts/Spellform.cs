using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Spellform : MonoBehaviour
{
    public float cooldownChange = 0;

    public bool prongMod = false;

    public bool enemies = false;
    public bool spawnOnPlayer = false;
    public bool shake = false;
    public float shakeAmount = 0;
    public float shaketimer = .5f;

    public string enemyTag = "Enemy";
    public List<GameObject> go = new List<GameObject>();
    public List<Transform> transforms = new List<Transform>();
    public float dtimer = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (transforms.Count == 0)
        {
            transforms.Add(transform);
        }
        if (shake)
        {
            StartCoroutine(Camera.main.GetComponent<shake>().shakee(shaketimer, shakeAmount));
            
            Debug.Log("sha");
        }
        
        if (spawnOnPlayer && enemies)
        {
            Debug.Log("te");
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dtimer -= Time.deltaTime;
        if(dtimer < 0)
        {
            die();
        }
    }


    public void die()
    {
        if(go.Count > 0)
        {
            for (int j = 0; j < transforms.Count; j++)
            {
                spawn(j);
            }
        }
        
        Destroy(gameObject);
    }
    public void spawn(int j)
    {
        Debug.Log(go.Count + " " + gameObject.name);
        GameObject goo = Instantiate(go[0], transforms[j].position, Quaternion.identity);
        Spellform sf = goo.GetComponent<Spellform>();
        if (sf != null)
        {
            sf.spawnOnPlayer = false;
            sf.enemies = true;
            if (sf.prongMod)
            {
               // go.RemoveAt(0);
                for (int i = 1; i < go.Count; i++)
                {
                    sf.go.Add(go[i]);
                }
            }
        }
    }
}
