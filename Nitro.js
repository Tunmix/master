#pragma strict

 var isReady : boolean;
 var vehicle : GameObject;
 var waitTime : float=4;
 var nitroTank :float = 5;
 var forceValue :float = 100;
 
 function Start() {
 isReady = true;
 }
 
 function Update() {
     if(Input.GetButton("Nitro") && isReady){
     	if(nitroTank>0){
     		vehicle.rigidbody.AddForce(transform.forward * forceValue, ForceMode.Acceleration);
     		nitroTank-=Time.deltaTime;
     	} else {
			Ready();
     	}
     }
     if(nitroTank<5){
     	nitroTank+=0.01;
     	}
 }
 
 function Ready(){
     isReady = false;
     yield WaitForSeconds(waitTime);
     isReady = true;
 }
