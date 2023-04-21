using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private bool _isInsideTrigger = false;
    private bool _isOpen = false;
    private Animator _chestAnimatorRef;
    private static readonly int IsOpen = Animator.StringToHash("isOpen?");
    private Transform _openTextRef;
    private Transform _closeTextRef;
    public Rigidbody axeRef;
    //private Transform _axeCreateRef;
    public Rigidbody bowRef;
    //private Transform _bowCreateRef;
    public Rigidbody maceRef;
    //private Transform _maceCreateRef;
    private Transform _weaponCreateRef;
    public Rigidbody healthPotionRef;
    public Rigidbody shieldPotionRef;
    public Rigidbody boostPotionRef;
    private Transform _potionCreateRef;
    private int _spawnonetime = 1; // prevent from spawning infite loot

    // Update is called once per frame
    void Update()
    {
        if (_isInsideTrigger == true) // is collide with chest
        {
            if (Input.GetButtonDown("E"))
            {
                if (checkkey.list2[2] == true)
                {
                    _isOpen = true; // is chest open or not
                    _chestAnimatorRef.SetBool(IsOpen, _isOpen); // open or close the chest with animation

                    if (_isOpen && _spawnonetime == 1)
                    {
                        Debug.Log("Chest Open");
                        _closeTextRef.gameObject.SetActive(true);
                        _openTextRef.gameObject.SetActive(false);

                        int weaponprob = Random.Range(1, 4);
                        if (weaponprob == 1)
                        {
                            // create an axe
                            Rigidbody axeInstance;
                            //axeInstance = PhotonNetwork.Instantiate(axeRef, transform.position, _weaponCreateRef.rotation) as Rigidbody;
                            //axeInstance.AddForce(0f, 150f, 50f);
                        }

                        if (weaponprob == 2)
                        {
                            Rigidbody bowInstance;
                            //bowInstance = PhotonNetwork.Instantiate(bowRef, transform.position, Quaternion.identity);
                            //bowInstance.AddForce(0f, 150f, 50f);
                        }

                        if (weaponprob == 3)
                        {
                            Rigidbody maceInstance;
                            //maceInstance = PhotonNetwork.Instantiate(maceRef, transform.position, Quaternion.identity);
                            //maceInstance.AddForce(0f, 150f, 50f);
                        }

                        int potionprob = Random.Range(1, 10);

                        if (potionprob is > 2 and < 6)
                        {
                            Rigidbody healthpotionInstance;
                            //healthpotionInstance = PhotonNetwork.Instantiate(healthPotionRef, transform.position, Quaternion.identity);
                            //healthpotionInstance.AddForce(0f, 150f, 50f);
                        }

                        if (potionprob is > 5 and < 8)
                        {
                            Rigidbody shieldpotionInstance;
                            //shieldpotionInstance = PhotonNetwork.Instantiate(shieldPotionRef, transform.position, Quaternion.identity);
                            //shieldpotionInstance.AddForce(0f, 150f, 50f);
                        }

                        if (potionprob is > 8 and < 11)
                        {
                            Rigidbody boostpotionInstance;
                            //boostpotionInstance = PhotonNetwork.Instantiate(boostPotionRef, transform.position, Quaternion.identity);
                            //boostpotionInstance.AddForce(0f, 150f, 50f);
                        }

                        _spawnonetime++;
                    }
                    else if (_isOpen == false)
                    {
                        Debug.Log("Closed Chest");
                        _closeTextRef.gameObject.SetActive(false);
                        _openTextRef.gameObject.SetActive(true);
                    }
                }

            }

        }
        else
        {
            if (_isOpen)
            {
                _isOpen = false;
                _chestAnimatorRef.SetBool(IsOpen, _isOpen);
                _spawnonetime = 1;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chest")) // can chest be opened?
        {
            _isInsideTrigger = true;
            // Refrences to the chidren of the chest base object
            Transform chestRef = other.transform.parent.Find("ChestA");
            Animator chestAnimator = chestRef.GetComponent<Animator>();
            _chestAnimatorRef = chestAnimator;

            _weaponCreateRef = other.transform.parent.Find("weaponCreatepoint");
            _potionCreateRef = other.transform.parent.Find("potionCreatepoint");


            Transform OpenText = other.transform.parent.Find("open e chestA tag");
            Transform CloseText = other.transform.parent.Find("close e chestA tag");
            _openTextRef = OpenText;
            _closeTextRef = CloseText;

            if (_isOpen)
            {
                Debug.Log("Chest Open");
                _closeTextRef.gameObject.SetActive(true);
                _openTextRef.gameObject.SetActive(false);
            }
            else if (_isOpen == false)
            {
                Debug.Log("Closed Open");
                _closeTextRef.gameObject.SetActive(false);
                _openTextRef.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Chest")) //close chest
        {
            _isInsideTrigger = false;
            _closeTextRef.gameObject.SetActive(false);
            _openTextRef.gameObject.SetActive(false);
        }
    }
}