using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class ShipMover : MonoBehaviour
{
    private ScreenSyze _screenSize;
    private Rigidbody _rigidbody;
    [SerializeField]private string _horizontalAxisName, _verticalAxisName;
    private float _horizontal, _vertical;
    [SerializeField] private float _speed;


    // Start is called before the first frame update
    void Start()
    {
        _screenSize = FindObjectOfType<ScreenSyze>();   
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        _horizontal = Input.GetAxis(_horizontalAxisName);
        _vertical = Input.GetAxis(_verticalAxisName);               
    }

    private void FixedUpdate() 
    {
        Vector3 directon = new Vector3(_horizontal, 0f,_vertical);
        Move(directon);
    }

    private void Move(Vector3 directon)
    {        
        if(_screenSize.CheckPlayerPosition(transform.position))
        {
            _rigidbody.velocity = directon * _speed * Time.deltaTime;
        }
        else
        {
            _rigidbody.velocity = (Vector3.zero - transform.position) * Time.deltaTime;
        } 
        
    }  

    
}
