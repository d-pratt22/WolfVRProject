using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject ranged;
    public GameObject melee;

    private InputDevice rightHand;

    private bool wasPressedLastFrame = false;

    public void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);

        if (devices.Count > 0)
        {
            rightHand = devices[0];
        }
    }

    public void Update()
    {
        if (!rightHand.isValid)
            return;

        if (rightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isPressed))
        {
            if (isPressed && !wasPressedLastFrame)
            {
                SwitchWeapon();
            }
            wasPressedLastFrame = isPressed;
        }
    }

    void SwitchWeapon()
    {
        if (ranged.activeInHierarchy)
        {
            ranged.SetActive(false);
            melee.SetActive(true);
        }
        else
        {
            RangedWeapon r = ranged.GetComponent<RangedWeapon>();
            r.canAttack = true;
            ranged.SetActive(true);
            melee.SetActive(false);
        }
    }
}
