﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerLooks : NetworkBehaviour
{
    public Material materialP1; 
    public Material materialP2; 
    public Material materialP3; 
    public Material materialP4; 

    public GameObject hat1;
    public GameObject hat2;
    public GameObject networkHat1;
    public GameObject networkHat2;

    [SerializeField] GamePlayer gamePlayerScript; 

    Renderer rend;


    public void Start(){
        rend = GetComponent<Renderer>();
        rend.enabled = true; 
        if(gamePlayerScript.playerNumber == 1){

            //color
            rend.sharedMaterial = materialP1;

            //camera hat 
            hat1.SetActive(true); 
            hat2.SetActive(false); 
            
            //network hat
            if(isLocalPlayer){ 
                networkHat1.SetActive(false);
            }
            else{
                networkHat1.SetActive(true);
            }
            networkHat2.SetActive(false);
        }
        else if(gamePlayerScript.playerNumber == 2){
            //color
            rend.sharedMaterial = materialP2;

            //camera hat 
            hat1.SetActive(false); 
            hat2.SetActive(true); 
            
            //network hat
            if(isLocalPlayer){ 
                networkHat2.SetActive(false);
            }
            else{
                networkHat2.SetActive(true);
            }
            networkHat1.SetActive(false);
        }
        else if(gamePlayerScript.playerNumber == 3){
            //color
            rend.sharedMaterial = materialP3;

            //camera hat 
            hat1.SetActive(true); 
            hat2.SetActive(false); 
            
            //network hat
            if(isLocalPlayer){ 
                networkHat1.SetActive(false);
            }
            else{
                networkHat1.SetActive(true);
            }
            networkHat2.SetActive(false);
        }
        else{
            //color
            rend.sharedMaterial = materialP4;

            //camera hat 
            hat1.SetActive(false); 
            hat2.SetActive(true); 
            
            //network hat
            if(isLocalPlayer){ 
                networkHat2.SetActive(false);
            }
            else{
                networkHat2.SetActive(true);
            }
            networkHat1.SetActive(false);
        }
        
    }
}
