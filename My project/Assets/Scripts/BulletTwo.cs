using UnityEngine;

public class BulletTwo : MonoBehaviour
{
    public float speed = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 perpendicular = transform.position - player.transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * speed;
    }
}
