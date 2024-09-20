using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    [SerializeField] private float goAway = 3.0f;

    private float goAwayDelta = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goAwayDelta <= goAway)
        {
        float translation = speed * Time.deltaTime;
        transform.Translate(new Vector2(0,translation));
        goAway -= 1 * Time.deltaTime;
        }
        else Destroy(gameObject);

        

    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Asteroid asteroid))
        {
            asteroid.RecieveDamage(1);
            Debug.Log("hit");
            Destroy(gameObject);
            
        }

    }
}

