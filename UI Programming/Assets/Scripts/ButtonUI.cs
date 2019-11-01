using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : BaseUI {
    public Anchor anchor;
    public Rect shape;
    public bool isVisible;
    private Rect oldShape;
    private Anchor oldAnchor;
    public string label;
    public delegate void clickHandler();
    public clickHandler onButtonClicked;

    // Use this for initialization
    void Start () {
        oldAnchor = anchor;
        oldShape = shape;
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

    protected override void ReDraw(){
        oldAnchor = anchor;
        oldShape = shape;
        SetPosition(shape.x, shape.y);
        SetSize(shape.width, shape.height);
        SetAnchor(anchor);
    }

    // Update is called once per frame
    void Update () {
        base.Update();
        if (oldAnchor != anchor || oldShape != shape){
            ReDraw();
        }
        else{
            oldAnchor = anchor;
            oldShape = shape;
        }

        VSetVisible(isVisible);
    }
}
