using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{
    public void Enter()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
    }
    public void Exit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }
}