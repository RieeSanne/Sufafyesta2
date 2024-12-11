 using UnityEngine;
        using System.Collections;
        
        public class CameraScript : MonoBehaviour 
        {
        	Transform playerTransform;
        	
        	Vector3 cameraOrientationVector = new Vector3 (0, 6, -12f);
        	

void Start () 
	{
		
		
		
		playerTransform = GameObject.Find ("Player").transform;
	}
        	
        void LateUpdate () 
        	{
        		
        		transform.position = playerTransform.position + cameraOrientationVector;
        		
        	}
        }