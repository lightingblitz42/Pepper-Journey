using System.Collections;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public bool teleported = false;
    public Transform goTo;
    public Transform CamGoTo;
    public float blackScreen = 0;
    public float ne = 1; 
    public SpriteRenderer blackSc;
    public GameObject g;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(blackScreen > 0 || ne == -1)
        {
            blackSc.color = new Color(0, 0, 0, blackScreen);
            blackScreen -= Time.deltaTime * ne * 2;
            if(blackScreen > 1 && teleported == false)
            {
                g.transform.position = goTo.position;
                Camera.main.transform.position = new Vector3(CamGoTo.position.x, CamGoTo.position.y, -10);
                teleported = true;
            }
            if(blackScreen > 1.3f)
            {
                ne = 1;
                teleported = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ne = -1;
            g = collision.gameObject;
        }
    }
}
