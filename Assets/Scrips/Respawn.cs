using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]Transform spawnPoint;
    [SerializeField]GameObject Sonido;

    int corazon=1;
    void OnCollisionEnter2D(Collision2D col){
        if(col.transform.CompareTag("Player")){
            Instantiate(Sonido);
            col.transform.position = spawnPoint.position;
            Corazones.instance.ChangeCorazones(corazon);
        }
    }
}
