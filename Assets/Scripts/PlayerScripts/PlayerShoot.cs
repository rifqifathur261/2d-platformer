using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shhotPoint;

    void Update()
    {
        shoot();
    }

    void shoot(){
        if(Input.GetKeyDown(KeyCode.Z)){
            Instantiate(bullet, shhotPoint.position, transform.rotation);
        }
    }
}
