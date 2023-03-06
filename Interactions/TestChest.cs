using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChest : MonoBehaviour
{
    public Rigidbody testchestref;
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
    public int Spawnonetime = 1;

    // Update is called once per frame
    void Update()
    {
        if (_isInsideTrigger == true) // is collide with chest
        {
            if (Input.GetButtonDown("E"))
            {
                _isOpen = true; // is chest open or not
                _chestAnimatorRef.SetBool(IsOpen, _isOpen); // open or close the chest with animation

                if (_isOpen && Spawnonetime == 1)
                {
                    Debug.Log("Chest Open");
                    _closeTextRef.gameObject.SetActive(true);
                    _openTextRef.gameObject.SetActive(false);

                    int weaponprob = Random.Range(1, 4);
                    if (weaponprob == 1)
                    {
                        // create an axe
                        Rigidbody axeInstance;
                        axeInstance = Instantiate(axeRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        axeInstance.AddForce(0f, 150f, 50f);
                    }

                    if (weaponprob == 2)
                    {
                        Rigidbody bowInstance;
                        bowInstance = Instantiate(bowRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        bowInstance.AddForce(0f, 150f, 50f);
                    }

                    if (weaponprob == 3)
                    {
                        Rigidbody maceInstance;
                        maceInstance = Instantiate(maceRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        maceInstance.AddForce(0f, 150f, 50f);
                    }

                    int potionprob = Random.Range(1, 10);

                    if (potionprob is > 2 and < 6)
                    {
                        Rigidbody healthpotionInstance;
                        healthpotionInstance = Instantiate(healthPotionRef, _potionCreateRef.position, _potionCreateRef.rotation) as Rigidbody;
                        healthpotionInstance.AddForce(0f, 150f, 50f);
                    }

                    if (potionprob is > 5 and < 8)
                    {
                        Rigidbody shieldpotionInstance;
                        shieldpotionInstance = Instantiate(shieldPotionRef, _potionCreateRef.position, _potionCreateRef.rotation) as Rigidbody;
                        shieldpotionInstance.AddForce(0f, 150f, 50f);
                    }

                    if (potionprob is > 8 and < 11)
                    {
                        Rigidbody boostpotionInstance;
                        boostpotionInstance = Instantiate(boostPotionRef, _potionCreateRef.position, _potionCreateRef.rotation) as Rigidbody;
                        boostpotionInstance.AddForce(0f, 150f, 50f);
                    }

                    Spawnonetime++;

                }
                else if (_isOpen == false)
                {
                    Debug.Log("Closed Chest");
                    _closeTextRef.gameObject.SetActive(false);
                    _openTextRef.gameObject.SetActive(true);
                }

            }

        }
        else
        {
            if (_isOpen)
            {
                _isOpen = false;
                _chestAnimatorRef.SetBool(IsOpen,_isOpen);
                Spawnonetime = 1;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChestB")) // can chest be opened?
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
    
    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("ChestB")) //close chest
        {
            _isInsideTrigger = false;
            _closeTextRef.gameObject.SetActive(false);
            _openTextRef.gameObject.SetActive(false);
        }
    }
}
