using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    private float width;
    public float scrollSpeed = -6f;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collider.size.x;
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
        transform.GetChild(0).localPosition = new Vector3(1, Random.Range(-3, 3), 0);
    }
}
