using UnityEngine;

public class PushController : MonoBehaviour
{
    public float speed = 10f;

    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask boxMask;

    private GameObject boxObject;
    #region Unity Methods


    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnAttachParent(hit);
        }

        if (hit.collider != null && hit.collider.CompareTag("Pushable") && Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Space))
        {
            boxObject = hit.collider.gameObject;
            boxObject.transform.parent = this.transform;

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            UnAttachParent(hit);
        }
    }
    #endregion

    private void UnAttachParent(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            boxObject = hit.collider.gameObject;
            boxObject.transform.parent = null;
        }
    }
}
