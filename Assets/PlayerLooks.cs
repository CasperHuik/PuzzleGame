using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooks : MonoBehaviour
{
    public Material materialP1; 
    public Material materialP2; 
    public Material materialP3; 
    public Material materialP4; 

    public GameObject hat1;
    public GameObject hat2;

    [SerializeField] GamePlayer gamePlayerScript; 

    Renderer rend;


    public void Start(){
        rend = GetComponent<Renderer>();
        rend.enabled = true; 
        if(gamePlayerScript.playerNumber == 1){
            rend.sharedMaterial = materialP1; 
            hat1.SetActive(true);
            hat2.SetActive(false);
        }
        else if(gamePlayerScript.playerNumber == 2){
            rend.sharedMaterial = materialP2; 
            hat1.SetActive(false);
            hat2.SetActive(true);
        }
        else if(gamePlayerScript.playerNumber == 3){
            rend.sharedMaterial = materialP3; 
            hat1.SetActive(true);
            hat2.SetActive(false);
        }
        else{
            rend.sharedMaterial = materialP4; 
            hat1.SetActive(false);
            hat2.SetActive(true);
        }
        
    }
}
