using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Axis
    #region LeftJoystick
    public float LHorizontalInput
    {
        get
        {
            return Input.GetAxis("LeftJoystickHorizontal");
        }
    }

    public float LHorizontalInputRaw
    {
        get
        {
            return Input.GetAxisRaw("LeftJoystickHorizontal");
        }
    }

    public float LVerticalInput
    {
        get
        {
            return Input.GetAxis("LeftJoystickVertical");
        }
    }

    public float LVerticalInputRaw
    {
        get
        {
            return Input.GetAxisRaw("LeftJoystickVertical");
        }
    }

    public float LVertizontalInput
    {
        get
        {
            float lVertizontalInput = Mathf.Abs(LVerticalInput) + Mathf.Abs(LHorizontalInput);
            lVertizontalInput = Mathf.Clamp(lVertizontalInput, 0, 1);

            return lVertizontalInput;
        }
    }

    public float LVertizontalInputRaw
    {
        get
        {
            float lVertizontalInputRaw = Mathf.Abs(LVerticalInputRaw) + Mathf.Abs(LHorizontalInputRaw);
            lVertizontalInputRaw = Mathf.Clamp(lVertizontalInputRaw, 0, 1);

            return lVertizontalInputRaw;
        }
    }

    public Vector3 LInputDirNonClamped
    {
        get
        {
            Vector3 lInputDirNonClamped = new Vector3(LHorizontalInput, 0, LVerticalInput);

            return lInputDirNonClamped;
        }
    }

    public Vector3 LInputDirClamped
    {
        get
        {
            Vector3 lInputDirClamped = new Vector3(LHorizontalInput, 0, LVerticalInput);
            lInputDirClamped = Vector3.ClampMagnitude(lInputDirClamped, 1);

            return lInputDirClamped;
        }
    }

    public Vector3 LInputDirRawNonClamped
    {
        get
        {
            Vector3 lInputDirRawNonClamped = new Vector3(LHorizontalInputRaw, 0, LVerticalInputRaw);

            return lInputDirRawNonClamped;
        }
    }

    public Vector3 LInputDirRawClamped
    {
        get
        {
            Vector3 lInputDirRawClamped = new Vector3(LHorizontalInputRaw, 0, LVerticalInputRaw);
            lInputDirRawClamped = Vector3.ClampMagnitude(lInputDirRawClamped, 1);

            return lInputDirRawClamped;
        }
    }
    #endregion
    #region RightJoystick
    public float RHorizontalInput
    {
        get
        {
            return Input.GetAxis("RightJoystickHorizontal");
        }
    }

    public float RHorizontalInputRaw
    {
        get
        {
            return Input.GetAxisRaw("RightJoystickHorizontal");
        }
    }

    public float RVerticalInput
    {
        get
        {
            return Input.GetAxis("RightJoystickVertical");
        }
    }

    public float RVerticalInputRaw
    {
        get
        {
            return Input.GetAxisRaw("RightJoystickVertical");
        }
    }

    public float RVertizontalInput
    {
        get
        {
            float rVertizontalInput = Mathf.Abs(RVerticalInput) + Mathf.Abs(RHorizontalInput);
            rVertizontalInput = Mathf.Clamp(rVertizontalInput, 0, 1);

            return rVertizontalInput;
        }
    }

    public float RVertizontalInputRaw
    {
        get
        {
            float rVertizontalInputRaw = Mathf.Abs(RVerticalInputRaw) + Mathf.Abs(RHorizontalInputRaw);
            rVertizontalInputRaw = Mathf.Clamp(rVertizontalInputRaw, 0, 1);

            return rVertizontalInputRaw;
        }
    }

    public Vector3 RInputDirNonClamped
    {
        get
        {
            Vector3 rInputDirNonClamped = new Vector3(RHorizontalInput, 0, RVerticalInput);

            return rInputDirNonClamped;
        }
    }

    public Vector3 RInputDirClamped
    {
        get
        {
            Vector3 rInputDirClamped = new Vector3(RHorizontalInput, 0, RVerticalInput);
            rInputDirClamped = Vector3.ClampMagnitude(rInputDirClamped, 1);

            return rInputDirClamped;
        }
    }

    public Vector3 RInputDirRawNonClamped
    {
        get
        {
            Vector3 rInputDirRawNonClamped = new Vector3(RHorizontalInputRaw, 0, RVerticalInputRaw);

            return rInputDirRawNonClamped;
        }
    }

    public Vector3 RInputDirRawClamped
    {
        get
        {
            Vector3 rInputDirRawClamped = new Vector3(RHorizontalInputRaw, 0, RVerticalInputRaw);
            rInputDirRawClamped = Vector3.ClampMagnitude(rInputDirRawClamped, 1);

            return rInputDirRawClamped;
        }
    }
    #endregion
    #region LeftTrigger
    public float LeftTriggerInput
    {
        get
        {
            return Input.GetAxis("LeftTrigger");
        }
    }

    public float LeftTriggerInputRaw
    {
        get
        {
            return Input.GetAxisRaw("LeftTrigger");
        }
    }
    #endregion
    #region RightTrigger
    public float RightTriggerInput
    {
        get
        {
            return Input.GetAxis("RightTrigger");
        }
    }

    public float RightTriggerInputRaw
    {
        get
        {
            return Input.GetAxisRaw("RightTrigger");
        }
    }
    #endregion
    #region DPad
    public float DHorizontal
    {
        get
        {
            return Input.GetAxis("DHorizontal");
        }
    }

    public float DVertical
    {
        get
        {
            return Input.GetAxis("DVertical");
        }
    }
    #endregion
    #endregion
    #region Buttons
    #region A
    public bool GetADown
    {
        get
        {
            if(Input.GetButtonDown("A"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetA
    {
        get
        {
            if(Input.GetButton("A"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetAUp
    {
        get
        {
            if(Input.GetButtonUp("A"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region B
    public bool GetBDown
    {
        get
        {
            if (Input.GetButtonDown("B"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetB
    {
        get
        {
            if (Input.GetButton("B"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetBUp
    {
        get
        {
            if (Input.GetButtonUp("B"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region X
    public bool GetXDown
    {
        get
        {
            if(Input.GetButtonDown("X"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetX
    {
        get
        {
            if(Input.GetButton("X"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetXUp
    {
        get
        {
            if(Input.GetButtonUp("X"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region Y
    public bool GetYDown
    {
        get
        {
            if(Input.GetButtonDown("Y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetY
    {
        get
        {
            if(Input.GetButton("Y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetYUp
    {
        get
        {
            if(Input.GetButtonUp("Y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region LeftBumper
    public bool GetLeftBumperDown
    {
        get
        {
            if(Input.GetButtonDown("LeftBumper"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetLeftBumper
    {
        get
        {
            if (Input.GetButton("LeftBumper"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetLeftBumperUp
    {
        get
        {
            if (Input.GetButtonUp("LeftBumper"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region RightBumper
    public bool GetRightBumperDown
    {
        get
        {
            if (Input.GetButtonDown("RightBumper"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetRightBumper
    {
        get
        {
            if (Input.GetButton("RightBumper"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetRightBumperUp
    {
        get
        {
            if (Input.GetButtonUp("RightBumper"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region LeftJoystick
    public bool GetLeftJoystickDown
    {
        get
        {
            if (Input.GetButtonDown("LeftJoystick"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetLeftJoystick
    {
        get
        {
            if (Input.GetButton("LeftJoystick"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetLeftJoystickUp
    {
        get
        {
            if (Input.GetButtonUp("LeftJoystick"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region RightJoystick
    public bool GetRightJoystickDown
    {
        get
        {
            if (Input.GetButtonDown("RightJoystick"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetRightJoystick
    {
        get
        {
            if (Input.GetButton("RightJoystick"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetRightJoystickUp
    {
        get
        {
            if (Input.GetButtonUp("RightJoystick"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region Select
    public bool GetSelectDown
    {
        get
        {
            if (Input.GetButtonDown("Select"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetSelect
    {
        get
        {
            if (Input.GetButton("Select"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetSelectUp
    {
        get
        {
            if (Input.GetButtonUp("Select"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #region Start
    public bool GetStartDown
    {
        get
        {
            if (Input.GetButtonDown("Start"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetStart
    {
        get
        {
            if (Input.GetButton("Start"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool GetStartUp
    {
        get
        {
            if (Input.GetButtonUp("Start"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
    #endregion
}