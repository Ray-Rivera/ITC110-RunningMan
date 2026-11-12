using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerControllerWORKONLY : MonoBehaviour
{
    public float moveSpeed = 10.0f;

    public InputActionReference playerMove;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(playerMove.action.ReadValue<Vector2>() * moveSpeed * Time.deltaTime);
    }
}
