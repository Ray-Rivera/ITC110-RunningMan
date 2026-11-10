using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioClip pickupSound;

    private bool didPickupAlready = false;

    public ScoreCounter LM;

    private void Start()
    {
        LM = GameObject.Find("Canvas").GetComponent<ScoreCounter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !didPickupAlready)
        {
            didPickupAlready = true;

            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            // tell the canvas about this pickup
            LM.numberOfCoins++;
            LM.coinText.SetText("Coins: " + LM.numberOfCoins);

            Destroy(gameObject);
        }
    }
}