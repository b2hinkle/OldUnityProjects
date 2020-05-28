﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace KinematicCharacterController
{
    [CustomEditor(typeof(KinematicCharacterMotor))]
    public class KinematicCharacterMotorEditor : Editor
    {
        protected virtual void OnSceneGUI()
        {            
            KinematicCharacterMotor motor = (target as KinematicCharacterMotor);
            if (motor)
            {
                Vector3 characterBottom = motor.transform.position + (motor.StepCapsule.center + (-Vector3.up * (motor.StepCapsule.height * 0.5f)));

                Handles.color = Color.yellow;
                Handles.CircleHandleCap(
                    0, 
                    characterBottom + (motor.transform.up * motor.MaxStepHeight), 
                    Quaternion.LookRotation(motor.transform.up, motor.transform.forward), 
                    motor.StepCapsule.radius + 0.1f, 
                    EventType.Repaint);
            }
        }
    }
}