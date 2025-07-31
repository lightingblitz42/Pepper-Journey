using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public GameObject black2;
    public Camera c2;
    public GameObject c3;
    public float size = 15;
    public Camera c;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(size == 15)
        {
            black2.transform.localScale = new Vector3(58.3626328f, 23.7644234f, 17.4738426f);
        }
        else
        {
            black2.transform.localScale = new Vector3(39.2248344f, 15.9717884f, 11.7439623f);
        }
        c.orthographicSize += (size - c.orthographicSize) * Time.deltaTime;
        c2.orthographicSize += (size - c2.orthographicSize) * Time.deltaTime;
        c3.transform.localScale = new Vector3(size / 15, size / 15) ;
    }
    public void change(int d)
    {
        size = d;
    }
}
