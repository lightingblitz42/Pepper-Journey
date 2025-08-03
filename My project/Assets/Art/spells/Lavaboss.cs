
using System.Collections.Generic;
using UnityEngine;

public class Lavaboss : MonoBehaviour
{
    public GameObject win2;
   public  GameObject Win;
    public List<Mage> d = new List<Mage>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (d[0].Health < 10)
        {
            win2.SetActive(true);
            Win.SetActive(true);
            Destroy(gameObject);
        }
        if (d[0].Health < 500)
        {
            d[4].enabled = true;
        }
        if (d[0].Health < 800)
        {
            d[3].enabled = true;
        }
         if (d[0].Health < 1200)
        {
            d[2].enabled = true;
        }
         if (d[0].Health < 1600)
        {
            d[5].enabled = true;
        }
         if (d[0].Health < 1999)
        {
            d[1].enabled = true;
        }
    }
}
