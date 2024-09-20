using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.0f;

    [SerializeField] private float acceleration = 8.0f ;

    [SerializeField] private float torque = 15.0f;
    
    private float MAX_SPEED = 8.0f;


    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        float pDirection = Input.GetAxisRaw("Vertical");
        if (pDirection == 1)
        {
            if (speed < MAX_SPEED)
            {
                speed += acceleration * Time.deltaTime;
            }
        }
        else if (pDirection == -1)
        {
            if (speed > 0)
            {
                speed -= Mathf.Clamp(acceleration * 2 * Time.deltaTime, 0, MAX_SPEED);
            }
        }
        float translation = speed * Time.deltaTime;
        transform.Translate(new Vector2(0,translation));

        //Rotate the ship here
        float pOrientation = Input.GetAxisRaw("Horizontal");

        

        
        transform.Rotate(Vector3.back,torque * pOrientation * Time.deltaTime);

    }

    

}
