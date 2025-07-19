using UnityEngine;

public class enemyDetection : MonoBehaviour
{
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
        if (collision.tag == "Player")
        {
            Player = collision.gameObject;
            detectedFor = 6;
        }
    }
}
