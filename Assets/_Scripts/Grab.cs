using UnityEngine;

public class Grab : MonoBehaviour
{
    private bool isGrabbing;
    private bool isLefted;
    private bool isRighted;
    public bool isJumping;
    private bool hasJumped;
    private GameObject grabbedObject;
    private float grabbedObjectSize;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isGrabbing)
            {
                Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Grabbable"));

                if (collider != null)
                {
                    grabbedObject = collider.gameObject;
                    grabbedObjectSize = collider.bounds.size.x;
                    isGrabbing = true;
                }
            }
            else
            {
                isGrabbing = false;
                grabbedObject = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            isGrabbing = false;
        }
        Collider2D yerC = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Ground Layer"));
        if (yerC != null)
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }





        if (isGrabbing)
        {
  
            if (Input.GetKey(KeyCode.RightArrow) && !isJumping)
            {
                Vector3 grabPosition = transform.position;
                grabPosition.x += grabbedObjectSize;
                grabbedObject.transform.position = grabPosition;
                isRighted = true;
                isLefted = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && !isJumping)
            {
                Vector3 grabPosition = transform.position;
                grabPosition.x -= grabbedObjectSize;
                grabbedObject.transform.position = grabPosition;
                isLefted = true;
                isRighted = false;
            }
            if (isLefted && !isJumping)
            {
                Vector3 grabPosition = transform.position;
                grabPosition.x -= grabbedObjectSize;
                grabbedObject.transform.position = grabPosition;
            }
            if (isRighted && !isJumping)
            {
                Vector3 grabPosition = transform.position;
                grabPosition.x += grabbedObjectSize;
                grabbedObject.transform.position = grabPosition;
            }


        }
        
    }

    
}

