using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelLoaderControllerV1_2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Arm;
    public GameObject Bucket;

    private Animator Arm_Animator;
    private Animator Bucket_Animator;

    const string ANIMS_ARM_UP = "Arm_MoveUp";
    const string ANIMS_ARM_DOWN = "Arm_MoveDown";
    const string ANIMS_ARM_IDLE = "Arm_Idle";

    const string ANIMS_BUCKET_UP = "Bucket_MoveUp"; 
	const string ANIMS_BUCKET_DOWN = "Bucket_MoveDown";
	
	private AnimationHandler animHandler_Arm;
	private AnimationHandler animHandler_Bucket;

	private Ray[] rays = new Ray[32];
	public float RayLength;

	public GameObject RaycastOriginsParent;
    
	[TextArea]
    public string monitor_Arm;
	[TextArea]
	public string monitor_Bucket;
    void Start()
    {
        Arm_Animator = Arm.GetComponent<Animator>();
        Bucket_Animator = Bucket.GetComponent<Animator>();
	    Arm_Animator.speed = 0;
	    
	    animHandler_Arm = new AnimationHandler(Arm_Animator,ANIMS_ARM_UP,ANIMS_ARM_DOWN,0);
	    animHandler_Bucket = new AnimationHandler(Bucket_Animator,ANIMS_BUCKET_UP,ANIMS_BUCKET_DOWN,0);
	}

    // Update is called once per frame
    void Update()
	{
		CheckCollisions();

		animHandler_Arm.UpdateHandler();
		animHandler_Bucket.UpdateHandler();
		animHandler_Arm.Debug(ref monitor_Arm);
		animHandler_Bucket.Debug(ref monitor_Bucket);
    	

	    if (Input.GetKey(KeyCode.W))
	    {
		    animHandler_Arm.MoveForward();
	    }
        
	    if (Input.GetKey(KeyCode.S))
	    {
		    animHandler_Arm.MoveBackward();
	    }
        
	    if (Input.GetKey(KeyCode.Q))
	    {
		    animHandler_Bucket.MoveForward();
	    }
        
	    if (Input.GetKey(KeyCode.E))
	    {
		    animHandler_Bucket.MoveBackward();
	    }


	    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
	    {
		    animHandler_Arm.NoMove();
		    animHandler_Bucket.NoMove();
	    }
    }

	void CheckCollisions()
    {
		//Get the Origins of the rays using the children from RaycastOriginsParent
		Transform[] RayOrigTranforms = RaycastOriginsParent.GetComponentsInChildren<Transform>();
		Debug.Log(RayOrigTranforms.Length);

		//Update every value
		for (int i = 0; i < RayOrigTranforms.Length; i++)
		{
			if (i == 0) continue;

			rays[i] = new Ray(RayOrigTranforms[i].position, RayOrigTranforms[i].TransformDirection(Vector3.back));
			Debug.DrawRay(RayOrigTranforms[i].position, RayOrigTranforms[i].TransformDirection(Vector3.back * RayLength),Color.green);

			//RaycastOrigins[i] = RayOrigTranforms[i].position;
			//RaycastDirs[i] = RayOrigTranforms[i].TransformDirection(Vector3.down);
			
			if(Physics.Raycast(rays[i],out RaycastHit hitInfo, RayLength))
            {
				//Debug.Log($"Ray[{i}]: Object Detected!");

				if (hitInfo.collider.gameObject.tag == "Ground")
                {
					//Debug.Log($"Ray[{i}]: Ground Detected!");
					animHandler_Bucket.isCollidingGround = true;
					animHandler_Arm.isCollidingGround = true;
                }

            }
            else
            {
				animHandler_Bucket.isCollidingGround = false;
				animHandler_Arm.isCollidingGround = false;
			}
		}

		


		

	}
   

   

}
