using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Corazones : MonoBehaviour
{
    public static Corazones instance;
    public TextMeshProUGUI text;
    int corazones=3;

    // Start is called before the first frame update
    void Start()
    {
        if(instance==null){
            instance=this;
        }
    }

    public void ChangeCorazones(int Corazon)
    {
        corazones-=Corazon;
        //score+=gemaV;
        text.text="x"+corazones.ToString();
    }
    public int VerCorazones(){
        
        return corazones;
    }
}
