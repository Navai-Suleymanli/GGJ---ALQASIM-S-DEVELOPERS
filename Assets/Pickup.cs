using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool hasLifeComponent;


    public int scoreValue = 10;  // The score that the player will receive for picking up the item

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coomponent"))
        {
            hasLifeComponent = true;
            Destroy(gameObject);
        }
    }
}