using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Danger"));



        if (collider != null)
        {
            Destroy(gameObject);
            Application.Quit();
        }

    }

}

