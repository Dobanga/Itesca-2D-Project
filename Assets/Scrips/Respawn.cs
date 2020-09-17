using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]Transform spawnPoint;

    int corazon=1;
    void OnCollisionEnter2D(Collision2D col){
        if(col.transform.CompareTag("Player")){
            col.transform.position = spawnPoint.position;
            Corazones.instance.ChangeCorazones(corazon);
        }
    }
}
