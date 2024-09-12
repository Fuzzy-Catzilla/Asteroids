using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    
    static float MAX_SPEED = 10/1000f;


    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        Debug.Log(translation);
        transform.Translate(new Vector2(0,translation));
    }

    //General forward movement
    void speedUp()
    {
        if (speed < MAX_SPEED)
        {
        
        speed++;
        transform.Translate(new Vector2(0,speed));
        }

    }
    void slowDown()
    {
        if (speed >= 0)
        {

            transform.Translate(new Vector2(0,speed));
        }
    }

}
