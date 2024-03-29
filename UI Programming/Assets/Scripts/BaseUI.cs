﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour, IScreenElement {
    // public properties
    public Anchor anchor;
    public Rect shape;
    private Anchor oldAnchor;
    private Rect oldShape;

    // internal properties
    private float m_PosX, m_PosY, m_ZOrder;
    private float m_Width, m_Height;
    private bool m_bIsVisible;
    private Anchor m_Anchor;

    private Vector2 resolution;
    protected float m_ScaleX, m_ScaleY;

    public enum Anchor{
        Top_Left,
        Bottom_Left,
        Top_Right,
        Bottom_Right,
        Centre,
        Bottom_Centre,
        Top_Centre,
        Left_Centre,
        Right_Centre
    }


    public BaseUI(){
        oldAnchor = anchor;
        oldShape = shape;

        m_bIsVisible = true;
        m_PosX = m_PosY = 0;
        m_Width = 100;
        m_Height = 100;
        m_ScaleX = 1.0f;
        m_ScaleY = 1.0f;
        m_Anchor = Anchor.Top_Left;

#if UNITY_EDITOR
        resolution = new Vector2(Screen.width, Screen.height);
#endif
    }

    public void SetPosition(float posX, float posY){
        
        m_PosX = posX * m_ScaleX;
        m_PosY = posY * m_ScaleY;
    }

    public float GetPosX(){
        return m_PosX;
    }

    public float GetPosY(){
        return m_PosY;
    }

    public void SetSize(float width, float height){
        m_Width = width * m_ScaleX;
        m_Height = height * m_ScaleY;
    }

    public float GetWidth(){
        return m_Width;
    }

    public float GetHeight(){
        return m_Height;
    }

    public virtual void ReDraw() {
        oldAnchor = anchor;
        oldShape = shape;
        SetPosition(shape.x, shape.y);
        SetSize(shape.width, shape.height);
        SetAnchor(anchor);
    }

    protected void Update()
    {
        if (oldAnchor != anchor || oldShape != shape)
        {
            ReDraw();
        }
        else
        {
            oldAnchor = anchor;
            oldShape = shape;
        }

#if UNITY_EDITOR
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            // do your stuff
            if(Screen.width > 0 )
                m_ScaleX = Screen.width / resolution.x;
            if(Screen.height > 0 )
                m_ScaleY = Screen.height / resolution.y;

            ReDraw();
        }
#endif
    }

    public void SetAnchor(Anchor anchor){
        m_Anchor = anchor;

        switch (m_Anchor){
            case Anchor.Top_Left:
                // ...
                break;

            case Anchor.Top_Right:
                m_PosX = m_PosX-m_Width;
                break;

            case Anchor.Top_Centre:
                m_PosX = m_PosX - (m_Width / 2);
                break;

            case Anchor.Bottom_Left:
                m_PosY = m_PosY-m_Height;
                break;

            case Anchor.Bottom_Right:
                m_PosX = m_PosX - m_Width;
                m_PosY = m_PosY - m_Height;
                break;

            case Anchor.Bottom_Centre:
                m_PosX = m_PosX - (m_Width / 2);
                m_PosY = m_PosY - m_Height;
                //...
                break;

            case Anchor.Left_Centre:
                m_PosY = m_PosY - (m_Height / 2);
                break;

            case Anchor.Right_Centre:
                m_PosX = m_PosX - m_Width;
                m_PosY = m_PosY - (m_Height / 2);
                //...
                break;

            case Anchor.Centre:
                m_PosX = m_PosX - (m_Width / 2);
                m_PosY = m_PosY-(m_Height / 2);
                
                break;
        }
    }

    public bool VIsVisible(){ 
        return m_bIsVisible; 
    }

    public void VSetVisible(bool visible){
        m_bIsVisible = visible;
    } 

    public float VGetZOrder(){
        return m_ZOrder;
    }
    public void VSetZOrder(float zOrder){
        m_ZOrder = zOrder;
    }
}
