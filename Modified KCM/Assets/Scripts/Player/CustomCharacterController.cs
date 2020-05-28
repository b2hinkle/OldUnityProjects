using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;

public class CustomCharacterController : BaseCharacterController
{
    #region vars
    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    KinematicCharacterMotor motor;
    [SerializeField]
    Transform cameraTransform;

    

    [Header("Move Options")]
    public float movementSpeed = 8;
    public Vector3 gravity = new Vector3(0, -0.1f, 0);
    
    
    

    [Header("Rotation Options")]
    public float lookSpeed = 1;



    //Private variables
    private Vector3 impulseVelocity = Vector3.zero;
    private Vector3 gravityPull = Vector3.zero;
    private Vector3 move;
    


    [SerializeField]
    List<Collider> ignoredColliders = new List<Collider>();
    
    //Properties
    Vector3 CharacterLookDir
    {
        get
        {
            return new Vector3(move.x, 0, move.z);
        }
    }
    Vector3 CamRight
    {
        get
        {
            Vector3 camRight;
            camRight = cameraTransform.right;
            camRight.y = 0;
            return camRight;
        }
    }
    Vector3 CamForward
    {
        get
        {
            Vector3 camForward;
            camForward = cameraTransform.forward;
            camForward.y = 0;
            return camForward;
        }
    }
    #endregion













    public override void AfterCharacterUpdate(float deltaTime)
    {

    }

    public override void BeforeCharacterUpdate(float deltaTime)
    {

    }

    public override bool IsColliderValidForCollisions(Collider coll)
    {
        if (ignoredColliders.Contains(coll))
        {
            return false;
        }
        return true;
    }

    public override void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {

    }

    public override void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {

    }

    public override void PostGroundingUpdate(float deltaTime)
    {
        if (Motor.GroundingStatus.IsStableOnGround && !Motor.LastGroundingStatus.IsStableOnGround)
        {
            //hit ground
        }
        else if (!Motor.GroundingStatus.IsStableOnGround && Motor.LastGroundingStatus.IsStableOnGround)
        {
            //left ground from stable
        }
    }

    public override void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {

    }

    public override void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        if (CharacterLookDir != Vector3.zero)
        {
            currentRotation = Quaternion.Slerp(currentRotation, Quaternion.LookRotation(CharacterLookDir), 1 - Mathf.Exp(-lookSpeed * deltaTime));
        }
    }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        

        if (motor.GroundingStatus.IsStableOnGround)
        {
            move = (playerInput.LInputDirRawClamped.x * CamRight + playerInput.LInputDirRawClamped.z * CamForward) * movementSpeed * deltaTime;
            gravityPull = Vector3.zero;
        }
        else
        {
            gravityPull = gravityPull + gravity * deltaTime;
        }
        
        
        move = move + gravityPull;
        currentVelocity = move;
        
    }


    #region helper methods
    
    #endregion
}
