using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    public EnemyAI enemyDetection;
    // Start is called before the first frame update
    /*    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerMovement>() != null)
            {
                // enemyDetection.player = collision.gameObject;
                enemyDetection.GetComponent<EnemyAI>().FaceTarget(collision.gameObject);
            }
        }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            // enemyDetection.player = collision.gameObject;
            enemyDetection.player = collision.gameObject;
            enemyDetection.GetComponent<EnemyAI>().FaceTarget(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            /*            enemyDetection.ActivateReturnToRoaming();*/
            enemyDetection.player = null;
            enemyDetection.ReturnToRoam();
        }
    }
}