using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public List<GameObject> g = new List<GameObject>();
    public List<GameObject> d = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            for(int i = 0; i < g.Count; i++)
            {
                g[i].SetActive(true);
                
            }
            for(int i = 0; i < d.Count; i++)
            {
                if (d[i] != null)
                {
                    d[i].SetActive(false);
                }

            }
        }
    }
}
