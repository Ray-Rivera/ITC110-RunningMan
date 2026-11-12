using System.Collections;
using UnityEngine;

public class Score2x : MonoBehaviour
{
    [SerializeField] ScoreCounter SC;
    private bool didPickupAlready = false;
    private bool isPowerupActive = false;
    public float duration = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp") && !didPickupAlready)
        {
            didPickupAlready = true;
            ActivatePowerUp();
            Destroy(other.gameObject);
            

        }
    }

    public void ActivatePowerUp()
    {
        if (isPowerupActive)
        {
            // If already active, you can either restart the timer or ignore it
            StopAllCoroutines();
        }

        StartCoroutine(PowerUpRoutine());
    }

    private IEnumerator PowerUpRoutine()
    {
        ApplyPowerUp();

        yield return new WaitForSeconds(duration);

        disablePowerUp();
    }

    private void ApplyPowerUp()
    {
        SC.pointsPerSecond *= 2;
        SC.scoreText.color = Color.yellow;
    }

    private void disablePowerUp()
    {
        SC.pointsPerSecond /= 2;
        SC.scoreText.color = Color.white;
    }

}
