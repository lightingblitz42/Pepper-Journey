using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float timerMax = 2;
    public float reloadTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reloadTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && reloadTimer <= 0)
        {
            reloadTimer = timerMax;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
