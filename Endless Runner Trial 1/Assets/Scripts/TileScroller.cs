using UnityEngine;

public class TileScroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CompositeCollider2D collider;
    public Rigidbody2D rb;
    public float width;
    public float scrollSpeed = -6f;
    void Start()
    {
        collider = GetComponent<CompositeCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collider.bounds.size.x;
        collider.enabled = false;

        rb.linearVelocity = new Vector2(scrollSpeed, 0);
        ResetObstacle();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
            ResetObstacle();
        }
    }

    void ResetObstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(Random.Range(-width, width),0, 0);
    }
}
