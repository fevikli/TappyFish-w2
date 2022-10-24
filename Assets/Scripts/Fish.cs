using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    //veriables
    [SerializeField] 
    private float _speed;
    private int angle;
    private int maxAngle = 20;
    private int minAngle = -60;
    // end of veriables

    //components
    Rigidbody2D _rb;
    //end of components


    // Start is called before the first frame update
    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(_rb.velocity.x, _speed);

    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();
        FishRotation();
    }

    private void FishSwim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, 9f);
        }
    }

    private void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
