using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

public class Activate : MonoBehaviour
{
    public float dd = -1;
    public GameObject bossally;
    public bool read = false;
    public bool sign = false;
    public GameObject mage11;
    public GameObject mage22;
    public bool mage2 = false;
    public string text;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (text.Length > 1)
        {
            if (sign)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    collision.GetComponent<Player>().StartCoroutine(collision.GetComponent<Player>().tex(text));
                    read = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(dd != -1 && collision.tag == "Player")
        {
            Camera.main.GetComponent<CameraManager>().audioSource.resource = Camera.main.GetComponent<CameraManager>().d[(int)dd];
            Camera.main.GetComponent<CameraManager>().audioSource.Play();
            Destroy(gameObject);
        }
        if(bossally != null && collision.tag == "Player")
        {
            Instantiate(bossally, new Vector3(transform.position.x, transform.position.y + 15), Quaternion.identity);
            Destroy(gameObject);
        }
        if(text.Length > 1)
        {
            if (sign)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    collision.GetComponent<Player>().StartCoroutine(collision.GetComponent<Player>().tex(text));
                }
            }
            else
            {
                collision.GetComponent<Player>().StartCoroutine(collision.GetComponent<Player>().tex(text));
                if (mage2)
                {
                    mage11.SetActive(false);
                    mage22.SetActive(true);
                }
                Destroy(gameObject);
            }
        }
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
