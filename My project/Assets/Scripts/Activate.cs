using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

public class Activate : MonoBehaviour
{
    public float dt = 0;
    public CameraSize c;
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
        if (hell && ColorUtility.TryParseHtmlString("#675034", out Color myColor) && collision.tag == "Player")
        {
            Camera.main.backgroundColor = myColor;
        }
        if(collision.tag == "Player")
        {
            if(dt != 0)
            {
                c.size = dt;
            }
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
