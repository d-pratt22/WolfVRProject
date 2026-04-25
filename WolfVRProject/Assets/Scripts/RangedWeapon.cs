using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class RangedWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileVelocity = 20f;
    public int cooldown = 4;
    private GameObject projectile;
    private Rigidbody rb;
    public bool canAttack = true;

    public Renderer weaponRenderer;
    public Color flashColor = Color.green;
    public float flashDuration = .2f;

    private Color originalColor;

    private InputDevice rightHand;

    void Start()
    {
        originalColor = weaponRenderer.material.color;

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);

        if (devices.Count > 0)
        {
            rightHand = devices[0];
        }
    }

    void Update()
    {
        if (!rightHand.isValid)
            return;

        // Read trigger value
        if (rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed) && isPressed && canAttack)
        {
            Attack(gameObject);
            StartCoroutine(AttackCooldown());
        }
    }

    public void Attack(GameObject parentHand)
    {
        Vector3 spawnPosition = parentHand.transform.position + parentHand.transform.forward * 1f;
        Quaternion rotation = parentHand.transform.rotation * Quaternion.Euler(90f, 0f, 0f);
        projectile = Instantiate(projectilePrefab, spawnPosition, rotation);
        rb = projectile.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        projectile.transform.parent = null;
        rb.AddForce(parentHand.transform.forward * projectileVelocity, ForceMode.Impulse);

    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
        StartCoroutine(FlashColor());
    }

    IEnumerator FlashColor()
    {
        weaponRenderer.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        weaponRenderer.material.color = originalColor;
    }
}
