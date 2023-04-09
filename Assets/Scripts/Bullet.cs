using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake() {
        Destroy(gameObject, destroyTime);
    }
    public float speed, damage, destroyTime;
   
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);     
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            other.transform.parent.GetComponent<EnemyHealth>().takeDamage(damage);
            Destroy(gameObject);
        }else if(other.CompareTag("Environtment")){
            Destroy(gameObject);
        }
    }
}
