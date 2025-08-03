
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellform : MonoBehaviour
{
    public GameObject da;
    public bool spawnWhileAlive = false;
    public bool col = true;

    public bool Small = true;
    public bool doneDie = false;
    public bool rotateright = false;

    public GameObject summoner;
    public bool teleport = false;
    public bool dig = false;

    public float damage = 1;

    public float cooldownChange = 0;

    public bool prongMod = false;

    public bool ally = false;
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
        if(da != null)
        {

            Instantiate(da, transform.position, Quaternion.identity);
        }
        if (dig)
        {
            diggg();
        }
        if (transforms.Count == 0)
        {
            transforms.Add(transform);
        }
        if (shake)
        {
            StartCoroutine(Camera.main.GetComponent<shake>().shakee(shaketimer, shakeAmount));
        }
        
        if (spawnOnPlayer && enemies)
        {
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (col && spawnWhileAlive)
        {
            StartCoroutine(awdaf());
        }
        dtimer -= Time.deltaTime;
        if(dtimer < 0)
        {
            if (!doneDie)
            {
                die();
            }
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
        if (teleport)
        {
            if(summoner != null)
            {
                summoner.transform.position = transform.position;
            }
        }
        Destroy(gameObject);
    }
    public void spawn(int j)
    {
        GameObject goo = Instantiate(go[0], transforms[j].position, Quaternion.identity);
        Spellform sf = goo.GetComponent<Spellform>();
        if (sf != null)
        {
            if (sf.rotateright)
            {
                goo.transform.rotation = transform.rotation;
            }
            sf.spawnOnPlayer = false;
            sf.enemies = enemies;
            sf.ally = ally;
            if (sf.prongMod)
            {
               // go.RemoveAt(0);
                for (int i = 1; i < go.Count; i++)
                {
                    sf.go.Add(go[i]);
                }
            }
            if (sf.teleport)
            {
                sf.summoner = summoner;
            }
        }
    }
    public void diggg()
    {
        Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(p.Digging());

    }
    public IEnumerator awdaf()
    {
        col = false;
        yield return new WaitForSeconds(.1f);
        col = true;
        if (go.Count > 0)
        {
            for (int j = 0; j < transforms.Count; j++)
            {
                spawn(j);
            }
        }
    }
}
