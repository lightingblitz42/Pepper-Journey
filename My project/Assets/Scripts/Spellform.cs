using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Spellform : MonoBehaviour
{
    public bool enemies = false;
    public bool spawnOnPlayer = false;
    public bool shake = false;

    public string enemyTag = "Enemy";
    public List<GameObject> go = new List<GameObject>();
    public float dtimer = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (shake)
        {
            Camera.main.GetComponent<shake>().shakee();
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
        for (int i = 0; i <  go.Count; i++)
        {
            Instantiate(go[i], transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
