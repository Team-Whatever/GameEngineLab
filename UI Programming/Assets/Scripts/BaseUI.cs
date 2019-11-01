using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour, IScreenElement {
    private float m_PosX, m_PosY, m_ZOrder;
    private float m_Width, m_Height;
    private bool m_bIsVisible;
    private Anchor m_Anchor;

    private Vector2 resolution;
    private float m_ScaleX, m_ScaleY;

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
        
        m_PosX = posX;
        m_PosY = posY;
    }

    public float GetPosX(){
        return m_PosX;
    }

    public float GetPosY(){
        return m_PosY;
    }

    public void SetSize(float width, float height){
        m_Width = width;
        m_Height = height;
    }

    public float GetWidth(){
        return m_Width;
    }

    public float GetHeight(){
        return m_Height;
    }

    protected virtual void ReDraw() { }

    protected void Update()
    {
#if UNITY_EDITOR
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            // do your stuff
            if( resolution.x > 0 )
                m_Width *= Screen.width / resolution.x;
            if( resolution.y > 0 )
                m_Height *= Screen.height / resolution.y;

            resolution.x = Screen.width;
            resolution.y = Screen.height;

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
                m_PosX = m_PosX - (m_Height / 2);
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
