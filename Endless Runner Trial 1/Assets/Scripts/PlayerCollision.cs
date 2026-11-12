using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
