
using UnityEngine;

public class P2MovementScript : PlayerMovement
{

    void Start()
    {
        leftkey = KeyCode.LeftArrow;
        rightKey = KeyCode.RightArrow;
        jumpKey = KeyCode.UpArrow;
        hitKey = KeyCode.Keypad0;

    }
    new void Update()
    {
        base.Update();
    }


}
