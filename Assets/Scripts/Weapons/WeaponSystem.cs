using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    private int _currentWeapon = 0;
    [SerializeField] private GameInput _inputs;
    [SerializeField] private WeaponModel[] _weaponModels;
    [SerializeField] private GameObject _holder;
    private GameSettings gameSettings = GameSettings.Instance;

    private float cooldownTimer = 0f;
    private float weaponSwitchCd = 1f;
    private bool canUseWeapon = true;

    private void Start()
    {
        _inputs.OnSlotsAction += SetCurrentWeapon;
    }

    private void Update()
    {
        if (!canUseWeapon)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= weaponSwitchCd)
            {
                canUseWeapon = true;
                cooldownTimer = 0f;
            }
        }
    }
    private void SetCurrentWeapon(int slotIndex)
    {
        if (!canUseWeapon) return;
        if(_currentWeapon == slotIndex) return;
        SelectWeapon(slotIndex);
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

        _currentWeapon = index;
        Instantiate(_weaponModels[_currentWeapon].Asset, _holder.transform);

        canUseWeapon = false;
    }
}