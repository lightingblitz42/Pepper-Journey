using System.Collections;
using TMPro;
using UnityEngine;

public class death : MonoBehaviour
{
    public bool win = false;
    public TextMeshProUGUI te;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (win)
        {
            StartCoroutine(dd("You --- won"));
        }
        else
        {
            StartCoroutine(dd("you______died"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator dd(string d)
    {
        for(int i = 0; i < d.Length; i++)
        {
            te.text += d[i];
            yield return new WaitForSeconds(.4f);
        }
    }
}
