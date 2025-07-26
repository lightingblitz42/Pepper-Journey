using System.Collections;
using UnityEngine;

public class shake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator shakee()
    {
        for(int i = 0; i < 5; i++)
        {
            float randx = Random.Range(-33, 33);
            float randy = Random.Range(-33, 33);
            transform.position -= new Vector3(randx, randy);

            yield return new WaitForSeconds(.01f);
            transform.position += new Vector3(randx, randy);
        }
        yield return null;
    }
}
