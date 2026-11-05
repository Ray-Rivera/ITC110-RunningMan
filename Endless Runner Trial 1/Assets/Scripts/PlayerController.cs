using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounterReference;
    [SerializeField] private BackgroundScroller br;

    public float moveSpeed = 10.0f;
    public InputActionReference playerMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(playerMove.action.ReadValue<Vector2>() * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            if (scoreCounterReference != null)
            {
                scoreCounterReference.StopScoring();
                br.scrollSpeed = 0;
            }
        }
    }
}
