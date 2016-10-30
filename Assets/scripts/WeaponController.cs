﻿using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource AudioSource;

    void Start()
    {
        Debug.Log("weapencontroller");
        AudioSource = GetComponent<AudioSource>();
        InvokeRepeating ("Fire",delay,fireRate);
    }
    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        AudioSource.Play();
    }
}
