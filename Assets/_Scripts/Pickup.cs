using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pickup : MonoBehaviour
{
    public bool hasComponent;
    public TextMeshProUGUI compCount;
    public int collectedCompoinentCount = 0;
    public GameObject tree;
   




    private void Start()
    {

    }



    

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("WaterComponent"));

        compCount.text = "Components Collected " + collectedCompoinentCount;

        if (collider != null)
        {
            Destroy(collider.gameObject);

            collectedCompoinentCount++;

            // UpdateScore(collectedCompoinentCount);
        }

        Collider2D collider2 = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Tree"));      
        
        if (collider2 != null && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collider2.gameObject);
            Instantiate(tree, collider2.transform.position, collider2.transform.rotation);
        }
    }




}
