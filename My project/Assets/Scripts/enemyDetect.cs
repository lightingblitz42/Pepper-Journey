using UnityEngine;

public class enemyDetect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic float detectedFor = 0;
    public GameObject Enemy;
    public bool called = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!called && collision.tag != "Finish")
        {
            Enemy = collision.gameObject;
            called = true;
        }
    }
}
