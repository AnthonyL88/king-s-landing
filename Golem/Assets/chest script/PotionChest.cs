using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionChest : MonoBehaviour
{
    //for opening and closing the chest
    private bool _isInsideTrigger = false;
    private bool _isOpen = false;
    private Animator _chestAnimatorRef;
    private static readonly int IsOpen = Animator.StringToHash("isOpen?");
    private Transform _openTextRef;
    private Transform _closeTextRef;

    // for chest loot
    public Rigidbody healthPotionRef;
    public Rigidbody shieldPotionRef;
    public Rigidbody boostPotionRef;
    private Transform _potionCreateRef;
    private Transform _keyCreateRef;
    public Rigidbody basickeyRef;
    public Rigidbody communkeyRef;
    public Rigidbody rarekeyRef;
    public Rigidbody legendarykeyRef;
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

                        int keyprob = Random.Range(1, 11);
                        if (keyprob is > 0 and < 5)
                        {
                            // create an axe
                            Rigidbody keyInstance;
                            keyInstance = Instantiate(basickeyRef, _keyCreateRef.position, _keyCreateRef.rotation) as Rigidbody;
                            keyInstance.AddForce(0f, 150f, 30f);
                        }

                        if (keyprob is > 4 and < 8)
                        {
                            Rigidbody keyInstance;
                            keyInstance = Instantiate(communkeyRef, _keyCreateRef.position, _keyCreateRef.rotation) as Rigidbody;
                            keyInstance.AddForce(0f, 150f, 30f);
                        }

                        if (keyprob is > 7 and < 10)
                        {
                            Rigidbody keyInstance;
                            keyInstance = Instantiate(rarekeyRef, _keyCreateRef.position, _keyCreateRef.rotation) as Rigidbody;
                            keyInstance.AddForce(0f, 150f, 30f);
                        }

                        if (keyprob is > 9 and < 11)
                        {
                            Rigidbody keyInstance;
                            keyInstance = Instantiate(legendarykeyRef, _keyCreateRef.position, _keyCreateRef.rotation) as Rigidbody;
                            keyInstance.AddForce(0f, 150f, 30f);
                        }

                        int potionprob = Random.Range(1, 11);

                        if (potionprob is > 2 and < 7)
                        {
                            Rigidbody healthpotionInstance;
                            healthpotionInstance = Instantiate(healthPotionRef, _potionCreateRef.position, _potionCreateRef.rotation) as Rigidbody;
                            healthpotionInstance.AddForce(0f, 150f, 30f);
                        }

                        if (potionprob is > 6 and < 10)
                        {
                            Rigidbody shieldpotionInstance;
                            shieldpotionInstance = Instantiate(shieldPotionRef, _potionCreateRef.position, _potionCreateRef.rotation) as Rigidbody;
                            shieldpotionInstance.AddForce(0f, 150f, 30f);
                        }

                        if (potionprob is > 9 and < 12)
                        {
                            Rigidbody boostpotionInstance;
                            boostpotionInstance = Instantiate(boostPotionRef, _potionCreateRef.position, _potionCreateRef.rotation) as Rigidbody;
                            boostpotionInstance.AddForce(0f, 150f, 30f);
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
        if (other.gameObject.CompareTag("PotionChest")) // can chest be opened?
        {
            _isInsideTrigger = true;
            // Refrences to the chidren of the chest base object
            Transform chestRef = other.transform.parent.Find("PotionChest");
            Animator chestAnimator = chestRef.GetComponent<Animator>();
            _chestAnimatorRef = chestAnimator;

            _keyCreateRef = other.transform.parent.Find("keyCreatepoint");
            _potionCreateRef = other.transform.parent.Find("potionCreatepoint");


            Transform OpenText = other.transform.parent.Find("open e potionchest tag");
            Transform CloseText = other.transform.parent.Find("close e potionchest tag");
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
        if (other.gameObject.CompareTag("PotionChest")) //close chest
        {
            _isInsideTrigger = false;
            _closeTextRef.gameObject.SetActive(false);
            _openTextRef.gameObject.SetActive(false);
        }
    }
}
