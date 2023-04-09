using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //movement
    public float movementSpeed;
    public bool isFacingRight;

    // edge checker
    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask whatsGround;

    public Transform healtbarHUD;

    void Update()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        if(!thereIsGround()){
            if (isFacingRight)
            {
                healtbarHUD.localEulerAngles = Vector2.zero;
                transform.eulerAngles = Vector2.up * 180;
                isFacingRight = false;
            }else{
                healtbarHUD.localEulerAngles = Vector2.up * 180;
                transform.eulerAngles = Vector2.zero;
                isFacingRight = true;

            }
        }
    }

    bool thereIsGround(){
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, whatsGround);
    }

    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }
}
