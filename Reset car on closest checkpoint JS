//29.8.2015 Jakub Ivanič JavaScript
function ResetCar(){

   var closTransform :Transform;
   var closDistance :float = 9999999999;
   var  currPos :Vector3 = transform.position;
     
     for(var trans : Transform in selected_children)
     {
        var currentDistance :float= Vector3.Distance(currPos, trans.position);
         if(currentDistance < closDistance)
         {
             closDistance = currentDistance;
             closTransform = trans;
         }
     }
 
     // Now we reset the car!
     transform.position = closTransform.position;
     transform.rotation = closTransform.rotation;
}
