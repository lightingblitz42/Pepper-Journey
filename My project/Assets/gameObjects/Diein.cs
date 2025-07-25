using UnityEngine;

public class Diein : MonoBehaviour
{
    public float timerr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerr -= Time.deltaTime;
        if(timerr < 0)
        {
            Destroy(gameObject);
        }
    }
}
