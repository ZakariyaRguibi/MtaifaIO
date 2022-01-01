
using UnityEngine;

public class P1MovementScript : PlayerMovement
{
    void Start()
    {
        leftkey = KeyCode.Q;
        rightKey = KeyCode.D;
        jumpKey = KeyCode.W;
        hitKey = KeyCode.J;
    }
    new void Update()
    {
        base.Update();
    }

}
