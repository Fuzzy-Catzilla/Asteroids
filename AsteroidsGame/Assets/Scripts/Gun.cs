using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private Transform Ship;
    private float coolDownDelta = 0.0f;
    [SerializeField] private float shotCoolDown = 0.25f;

    void Start()
    {
        Ship = GetComponentInParent<Transform>();
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space) && coolDownDelta <= 0)
        {
            coolDownDelta = shotCoolDown;
            Instantiate(bullet , transform.position, Ship.rotation);
            
        }
        
        else coolDownDelta -= Time.deltaTime;

    }
}
