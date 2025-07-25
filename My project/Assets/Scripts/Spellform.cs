using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Spellform : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public List<GameObject> go = new List<GameObject>();
    public float dtimer = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == enemyTag)
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
    }
}
