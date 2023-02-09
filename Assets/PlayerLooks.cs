using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooks : MonoBehaviour
{
    public Material materialP1; 
    public Material materialP2; 
    public Material materialP3; 
    public Material materialP4; 

    [SerializeField] GamePlayer gamePlayerScript; 

    Renderer rend;


    public void Start(){
        rend = GetComponent<Renderer>();
        rend.enabled = true; 
        if(gamePlayerScript.playerNumber == 1){
            rend.sharedMaterial = materialP1; 
        }
        else if(gamePlayerScript.playerNumber == 2){
            rend.sharedMaterial = materialP2; 
        }
        else if(gamePlayerScript.playerNumber == 3){
            rend.sharedMaterial = materialP3; 
        }
        else{
            rend.sharedMaterial = materialP4; 
        }
        
    }
}
