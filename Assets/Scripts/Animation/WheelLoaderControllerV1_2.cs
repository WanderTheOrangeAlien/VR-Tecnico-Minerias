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
    
    public string monitor;
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
    	
		animHandler_Arm.UpdateHandler();
		animHandler_Bucket.UpdateHandler();
    	

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
   

   

}
