using UnityEngine;

public class PushController : MonoBehaviour
{
    public float speed = 10f;

    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask boxMask;
    [SerializeField] private float thrust = 1f;
    
    private GameObject boxObject;
    private int dir = 0;
    #region Unity Methods
    private void Update()
    {
        float hz = Input.GetAxis("Horizontal");
        if(hz>0)
        {
            dir = 1;
        }
        if (hz < 0)
        {
            dir = -1;
        }

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * dir, distance, boxMask);

        if (hit.collider != null && hit.collider.CompareTag("Pushable") && Input.GetKey(KeyCode.Q))
        {            
            boxObject = hit.collider.gameObject;

            Rigidbody2D rb2D = boxObject.GetComponent<Rigidbody2D>();
            Vector2 side=Vector2.zero;

            float playerX = transform.position.x;
            float objectX = boxObject.transform.position.x;

            if (playerX < objectX)
            {
                side = Vector2.right;
            }

            if (playerX > objectX)
            {
                side = Vector2.left;
            }

            rb2D.AddForce(side * thrust);
        }
    }
    #endregion

}
