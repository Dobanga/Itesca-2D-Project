
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTime : MonoBehaviour
{
    
    [SerializeField]
    float lifeTime=9f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
