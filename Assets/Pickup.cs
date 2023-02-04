using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool hasComponent;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Component"))
        {
            hasComponent = true;
            Destroy(gameObject);
        }
    }
}
