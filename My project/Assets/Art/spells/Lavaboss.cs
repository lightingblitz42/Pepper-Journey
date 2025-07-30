using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Lavaboss : MonoBehaviour
{
    
    public List<Mage> d = new List<Mage>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (d[0].Health < 200)
        {
            d[4].enabled = true;
        }
        if (d[0].Health < 400)
        {
            d[3].enabled = true;
        }
         if (d[0].Health < 600)
        {
            d[2].enabled = true;
        }
         if (d[0].Health < 800)
        {
            d[5].enabled = true;
        }
         if (d[0].Health < 999)
        {
            d[1].enabled = true;
        }
    }
}
