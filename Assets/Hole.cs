using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
 
   void OnTriggerEnter2D(Collider2D col){
       Ball.setDead(true);
   }
}
