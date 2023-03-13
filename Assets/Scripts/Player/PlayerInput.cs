using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerMovement pM;
    float horizontal = 0, vertical = 0;

    void Start()
    {
        pM = this.GetComponent<PlayerMovement>();
    }

    public void SetHorizontal(InputAction.CallbackContext ctx)
    {
        horizontal = ctx.ReadValue<float>();
        pM.SetInput(horizontal, vertical);
    }

    public void SetVertical(InputAction.CallbackContext ctx)
    {
        vertical = ctx.ReadValue<float>();
        pM.SetInput(horizontal, vertical);
    }
}
