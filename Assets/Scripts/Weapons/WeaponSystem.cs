using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    private ushort _currentWeapon = 0;
    [SerializeField] private GameInput _inputs;
    [SerializeField] private WeaponModel[] _weaponModels;
    [SerializeField] private GameObject _holder;

    private float cooldownTimer = 0f;
    private float weaponSwitchCd = 1f;
    private bool canUseWeapon = true;

    private void Update()
    {
        // Check if the cooldown period has passed
        if (!canUseWeapon)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= weaponSwitchCd)
            {
                canUseWeapon = true;
                cooldownTimer = 0f;
            }
        }

        // Check for input or conditions to use the weapon
        if (canUseWeapon)
        {

            // Call the method or perform the action for the weapon
            SetCurrentWeapon();

            // Set the cooldown


        }
    }
    private void SetCurrentWeapon()
    {
        if (_inputs.IsSlot1)
        {
            _currentWeapon = 0;
            SelectWeapon(_currentWeapon);
        }

        if (_inputs.IsSlot2)
        {
            _currentWeapon = 1;
            SelectWeapon(_currentWeapon);
        }
    }

    private void SelectWeapon(int index)
    {
        if (transform.childCount > 0)
        {
            foreach (Transform child in _holder.transform)
            {
                Destroy(child.gameObject);
            }
        }

        GameObject weapon = Instantiate(_weaponModels[_currentWeapon].Asset, _holder.transform);


        canUseWeapon = false;
    }
}