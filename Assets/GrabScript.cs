using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    [SerializeField] private GameObject _grabPoint;
    [SerializeField] private GameObject _rayPoint;
    [SerializeField] private GameObject _grabedObject;
    [SerializeField] private float _rayDistance;
     private int _layerMask;
    

    private void Start()
    {
        _layerMask = LayerMask.NameToLayer("Grab");

    }
    private void Update()
    {

        RaycastHit2D _hitInfo = Physics2D.Raycast(_rayPoint.transform.position,Vector2.right, _rayDistance);
        
        if (_hitInfo.collider != null && _hitInfo.collider.gameObject.layer == _layerMask)
        {
            if (Input.GetKeyDown("e") )
            {
                Debug.Log("SSDF");
                _grabedObject = _hitInfo.collider.gameObject;
                _grabedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                _grabedObject.transform.position = _grabPoint.transform.position;
                _grabedObject.transform.SetParent(transform);
                
            }
            else
            {
                _grabedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                _grabedObject.transform.SetParent(null);
                _grabedObject = null;
            }
        }
    }
}
