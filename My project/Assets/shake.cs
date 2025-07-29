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
    public IEnumerator shakee(float time, float amount)
    {
        yield return new WaitForSeconds(time);
        for(int i = 0; i < 7 + amount; i++)
        {
            float randx = Random.Range(-.3f, .3f);
            float randy = Random.Range(-.3f, .3f);
            transform.position -= new Vector3(randx, randy);
            yield return new WaitForSeconds(.02f);
            transform.position += new Vector3(randx, randy);
        }
        yield return null;
    }
}
