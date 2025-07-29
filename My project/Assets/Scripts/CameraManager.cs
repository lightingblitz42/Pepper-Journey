using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject follow;

    public bool started = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            rb.linearVelocity = (follow.transform.position - transform.position) * 3f;
        }
    }
}
