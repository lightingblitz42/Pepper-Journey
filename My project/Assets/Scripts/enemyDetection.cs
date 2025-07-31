using UnityEngine;

public class enemyDetection : MonoBehaviour
{
    public bool ally = false;
    public float detectedFor = 0;
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectedFor -= Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ally)
        {
            if (collision.tag == "Enemy")
            {
                Player = collision.gameObject;
                detectedFor = 1;
            }
        }
        else
        {
            if (collision.tag == "Player")
            {
                Player = collision.gameObject;
                detectedFor = 1;
            }
        }
    }
}
