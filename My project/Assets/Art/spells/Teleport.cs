using UnityEngine;

public class Teleport : Spellform
{
    public GameObject teleportTo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.parent.position = transform.position;
        die();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
