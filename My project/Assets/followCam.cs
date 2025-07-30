using UnityEngine;

public class followCam : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
    }
}
