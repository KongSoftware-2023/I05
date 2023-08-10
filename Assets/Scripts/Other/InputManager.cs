using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] protected Vector3 mouseworldPosition;
    public Vector3 MouseworldPosition => mouseworldPosition;
    [SerializeField] protected bool onFring;

    public bool OnFring { get => onFring; }

    [SerializeField]protected Camera camera;

    private void Awake()
    {
        InputManager.instance = this;
    }
    private void Update()
    {
        //this.GetMouseDow();
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
    }
    protected virtual void GetMousePos()
    {
        this.mouseworldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }
    //protected virtual void GetMouseDow()
    //{
    //    this.onFring = Input.GetAxis("Fire1");
    //}
    public  bool GetMouseUp()
    {
        this.onFring = false;
        return Input.GetMouseButtonUp(0);
    }
    public bool GetMouse()
    {
        this.onFring = true;
        return Input.GetMouseButton(0);
    }
    public bool GetMouseDown()
    {
        return Input.GetMouseButtonDown(0);
    }
}
