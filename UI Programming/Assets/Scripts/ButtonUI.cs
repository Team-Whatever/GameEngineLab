using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : BaseUI {
    public bool isVisible;
    public string label;
    public delegate void clickHandler();
    public clickHandler onButtonClicked;

    // Use this for initialization
    void Start () {
        SetPosition(shape.x, shape.y);
        SetSize(shape.width, shape.height);
        SetAnchor(anchor);
	}

    private void OnGUI()
    {
        if (VIsVisible()){
            if (GUI.Button(new Rect(GetPosX(), GetPosY(), GetWidth(), GetHeight()), label)){
                //Debug.Log("Button pressed!");
                if( onButtonClicked != null )
                    onButtonClicked();
            }
        }
    }

    // Update is called once per frame
    void Update () {
        base.Update();

        VSetVisible(isVisible);
    }
}
