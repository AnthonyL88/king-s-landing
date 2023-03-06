using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunChest : MonoBehaviour
{
    //for opening and closing the chest
    private bool _isInsideTrigger = false;
    private bool _isOpen = false;
    private Animator _chestAnimatorRef;
    private static readonly int IsOpen = Animator.StringToHash("isOpen?");
    private Transform _openTextRef;
    private Transform _closeTextRef;
    
    // for chest loot
    public Rigidbody communaxeRef;
    public Rigidbody communbowRef;
    public Rigidbody communmaceRef;
    public Rigidbody rareaxeRef;
    public Rigidbody rarebowRef;
    public Rigidbody raremaceRef;
    public Rigidbody lengendaryaxeRef;
    public Rigidbody lengendarybowRef;
    public Rigidbody lengendarymaceRef;
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
                _isOpen = true; // is chest open or not
                _chestAnimatorRef.SetBool(IsOpen , _isOpen); // open or close the chest with animation

                if (_isOpen && _spawnonetime == 1)
                {
                    Debug.Log("Chest Open");
                    _closeTextRef.gameObject.SetActive(true);
                    _openTextRef.gameObject.SetActive(false);

                    int weaponprob = Random.Range(1, 22);
                    if (weaponprob is > 3 and < 7)
                    {
                        // create an axe
                        Rigidbody axeInstance;
                        axeInstance = Instantiate(communaxeRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        axeInstance.AddForce(0f, 150f, 50f);
                    }
                    
                    if (weaponprob is > 6 and < 10)
                    {
                        Rigidbody bowInstance;
                        bowInstance = Instantiate(communbowRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        bowInstance.AddForce(0f, 150f, 50f);
                    }

                    if (weaponprob is > 9 and < 13)
                    {
                        Rigidbody maceInstance;
                        maceInstance = Instantiate(communmaceRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        maceInstance.AddForce(0f, 150f, 50f);
                    }
                    
                    if (weaponprob is > 12 and < 15)
                    {
                        Rigidbody axeInstance;
                        axeInstance = Instantiate(rareaxeRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        axeInstance.AddForce(0f, 150f, 50f);
                    }
                    
                    if (weaponprob is > 14 and < 17)
                    {
                        Rigidbody bowInstance;
                        bowInstance = Instantiate(rarebowRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        bowInstance.AddForce(0f, 150f, 50f);
                    }
                    
                    if (weaponprob is > 16 and < 19)
                    {
                        Rigidbody maceInstance;
                        maceInstance = Instantiate(raremaceRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        maceInstance.AddForce(0f, 150f, 50f);
                    }
                    
                    if (weaponprob == 19)
                    {
                        Rigidbody axeInstance;
                        axeInstance = Instantiate(lengendaryaxeRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        axeInstance.AddForce(0f, 150f, 50f);
                    }
                    
                    if (weaponprob == 20)
                    {
                        Rigidbody bowInstance;
                        bowInstance = Instantiate(lengendarybowRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        bowInstance.AddForce(0f, 150f, 50f);
                    }
                    
                    if (weaponprob == 21)
                    {
                        Rigidbody maceInstance;
                        maceInstance = Instantiate(lengendarymaceRef, _weaponCreateRef.position, _weaponCreateRef.rotation) as Rigidbody;
                        maceInstance.AddForce(0f, 150f, 50f);
                    }

                    int potionprob = Random.Range(1, 10);

                    if (potionprob is > 2 and < 7)
                    {
                        Rigidbody healthpotionInstance;
                        healthpotionInstance = Instantiate(healthPotionRef, _potionCreateRef.position, _potionCreateRef.rotation) as Rigidbody;
                        healthpotionInstance.AddForce(0f, 150f, 50f);
                    }

                    if (potionprob is > 6 and < 10)
                    {
                        Rigidbody shieldpotionInstance;
                        shieldpotionInstance = Instantiate(shieldPotionRef, _potionCreateRef.position, _potionCreateRef.rotation) as Rigidbody;
                        shieldpotionInstance.AddForce(0f, 150f, 50f);
                    }

                    if (potionprob == 10)
                    {
                        Rigidbody boostpotionInstance;
                        boostpotionInstance = Instantiate(boostPotionRef, _potionCreateRef.position, _potionCreateRef.rotation) as Rigidbody;
                        boostpotionInstance.AddForce(0f, 150f, 50f);
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
        else
        {
            if (_isOpen)
            {
                _isOpen = false;
                _chestAnimatorRef.SetBool(IsOpen,_isOpen);
                _spawnonetime = 1;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CommunChest")) // can chest be opened?
        {
            _isInsideTrigger = true;
            // Refrences to the chidren of the chest base object
            Transform chestRef = other.transform.parent.Find("CommunChest");
            Animator chestAnimator = chestRef.GetComponent<Animator>();
            _chestAnimatorRef = chestAnimator;

            _weaponCreateRef = other.transform.parent.Find("weaponCreatepoint");
            _potionCreateRef = other.transform.parent.Find("potionCreatepoint");
            

            Transform OpenText = other.transform.parent.Find("open e communchest tag");
            Transform CloseText = other.transform.parent.Find("close e communchest tag");
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
        if (other.gameObject.CompareTag("CommunChest")) //close chest
        {
            _isInsideTrigger = false;
            _closeTextRef.gameObject.SetActive(false);
            _openTextRef.gameObject.SetActive(false);
        }
    }
}
