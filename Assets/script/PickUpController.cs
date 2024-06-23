using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Transform weaponHoldPoint; // Point where the weapon will be held
    public float dropForce = 1f; // Force applied when dropping the weapon

    private GameObject currentWeapon;
    private Rigidbody weaponRb;

    void Update()
    {
        // Check for pick up or drop input
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentWeapon == null)
            {
                TryPickUpWeapon();
            }
            else
            {
                DropWeapon();
            }
        }
    }

    void TryPickUpWeapon()
    {
        RaycastHit hit;
        // Raycast to detect weapons within 2 meters in front of the player
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            // Check if the hit object is tagged as "Weapon"
            if (hit.collider.CompareTag("Weapon"))
            {
                currentWeapon = hit.collider.gameObject;
                weaponRb = currentWeapon.GetComponent<Rigidbody>();
                if (weaponRb != null)
                {
                    // Disable weapon physics
                    weaponRb.isKinematic = true;
                    // Parent weapon to the hold point
                    currentWeapon.transform.SetParent(weaponHoldPoint);

                    // Reset weapon's local position and rotation
                    currentWeapon.transform.localPosition = Vector3.zero;
                    currentWeapon.transform.localRotation = Quaternion.identity;

                    // Enable the gun's shooting script
                    currentWeapon.GetComponent<ProjectileGun>().enabled = true;

                    // Debug messages to check the weapon's position and rotation
                    Debug.Log("Weapon picked up and parented to weaponHoldPoint");
                    Debug.Log("Weapon local position: " + currentWeapon.transform.localPosition);
                    Debug.Log("Weapon local rotation: " + currentWeapon.transform.localRotation);
                }
            }
        }
    }

    void DropWeapon()
    {
        if (currentWeapon != null)
        {
            // Unparent the weapon
            currentWeapon.transform.SetParent(null);
            // Enable weapon physics
            weaponRb.isKinematic = false;
            // Apply a slight force to drop the weapon
            weaponRb.AddForce(transform.forward * dropForce, ForceMode.VelocityChange);

            // Disable the gun's shooting script
            currentWeapon.GetComponent<ProjectileGun>().enabled = false;

            // Clear references
            currentWeapon = null;
            weaponRb = null;
        }
    }
}