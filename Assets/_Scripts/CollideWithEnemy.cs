using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Saam Eeekim");
        if (collision.collider.gameObject.layer == _enemyLayer)
        {
            Debug.Log("Touched an enemy");
        }
    }
}
