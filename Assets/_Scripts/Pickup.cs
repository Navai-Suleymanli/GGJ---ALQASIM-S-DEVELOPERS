using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Pickup : MonoBehaviour
{
    public bool hasComponent;
   
    public int collectedCompoinentCount = 0;
    public GameObject tree;
    [SerializeField] GameObject _waterDrop1;
    [SerializeField] GameObject _waterDrop2;
    [SerializeField] GameObject _waterDrop3;



    private void Start()
    {

    }


    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("WaterComponent"));

        

        if (collider != null)
        {
            Destroy(collider.gameObject);

            collectedCompoinentCount++;
            Debug.Log(collectedCompoinentCount);
            if (collectedCompoinentCount == 1)
            {
                _waterDrop1.SetActive(true);
            }

            if (collectedCompoinentCount == 2)
            {

                _waterDrop2.SetActive(true);
            }

            if (collectedCompoinentCount == 3)
            {
                 _waterDrop3.SetActive(true);
            }
            
            
           
           
           

            // UpdateScore(collectedCompoinentCount);
        }

        Collider2D collider2 = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Tree"));      
        
        if (collider2 != null && Input.GetKeyDown(KeyCode.E) && collectedCompoinentCount == 3)
        {
            Destroy(collider2.gameObject);
            Instantiate(tree, collider2.transform.position, collider2.transform.rotation);
        }
    }

}
