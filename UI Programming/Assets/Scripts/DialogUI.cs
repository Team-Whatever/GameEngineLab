using System;
using System.Collections.Generic;
using UnityEngine;

class DialogUI : BaseUI
{
    public bool isVisible;

    public string label;
    private GUIStyle labelStyle;
    public ButtonUI yesButton;
    public ButtonUI noButton;

    // Use this for initialization
    void Start()
    {
        SetPosition(shape.x, shape.y);
        SetSize(shape.width, shape.height);
        SetAnchor(anchor);

        label = "Wanna be happy?";
        labelStyle = new GUIStyle();
        labelStyle.fontSize = 20;
        labelStyle.normal.textColor = Color.white;
        labelStyle.alignment = TextAnchor.MiddleCenter;

        yesButton.shape.Set( GetPosX() + GetWidth() * 0.3f, GetPosY() + GetHeight() * 0.7f, GetWidth() * 0.2f, GetHeight() * 0.15f );
        yesButton.anchor = Anchor.Centre;
        yesButton.label = "YES";
        yesButton.onButtonClicked = OnYesClicked;

        noButton.shape.Set( GetPosX() + GetWidth() * 0.7f, GetPosY() + GetHeight() * 0.7f, GetWidth() * 0.2f, GetHeight() * 0.15f );
        noButton.anchor = Anchor.Centre;
        noButton.label = "NO";
        noButton.onButtonClicked = OnNoClicked;
    }

    private void OnGUI()
    {
        if (VIsVisible())
        {
            GUI.Label(new Rect( GetPosX() + GetWidth() * 0.25f, GetPosY() + GetHeight() * 0.3f, GetWidth() * 0.5f, GetHeight() * 0.3f ), label, labelStyle);
            GUI.Box(new Rect(GetPosX(), GetPosY(), GetWidth(), GetHeight()), "");
        }
    }

    public override void ReDraw()
    {
        base.ReDraw();

        yesButton.ReDraw();
        //yesButton.shape.Set( GetPosX() + GetWidth() * 0.3f, GetPosY() + GetHeight() * 0.7f, GetWidth() * 0.2f, GetHeight() * 0.15f );
        noButton.ReDraw();
        //noButton.shape.Set( GetPosX() + GetWidth() * 0.7f, GetPosY() + GetHeight() * 0.7f, GetWidth() * 0.2f, GetHeight() * 0.15f );
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        VSetVisible(isVisible);
    }

    void OnYesClicked()
    {
        Debug.Log("YES");
    }

    void OnNoClicked()
    {
        Debug.Log("NO");
    }
}

