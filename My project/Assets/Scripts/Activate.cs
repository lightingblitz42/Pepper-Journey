using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

public class Activate : MonoBehaviour
{
    string hex = "#675436";
    public bool hell = false;
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
        if (hell && ColorUtility.TryParseHtmlString("#FF0000", out Color myColor))
        {
            Camera.main.backgroundColor = myColor;
        }
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
