using Photon.Pun.Demo.Cockpit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/Game settings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string Gameversion = "0.0";
    public string GameVersion { get { return Gameversion; } }
    [SerializeField]
    private string _nickName = "Punfish";


     public string NickName
     {
         get
         {
             int value = UnityEngine.Random.Range(0, 9999);
             return _nickName + value.ToString();
         }
     }
}

