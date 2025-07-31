using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    public Vector2 GetMovementInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
