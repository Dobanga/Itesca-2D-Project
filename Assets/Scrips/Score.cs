using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if(instance==null){
            instance=this;
        }
    }

    public void ChangeScore(int gemaV)
    {
        score+=gemaV;
        text.text="x"+score.ToString();
    }
    public int VerScore(){
        
        return score;
    }

}
