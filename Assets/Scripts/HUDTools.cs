using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//various cool and handy functions I've put together to do HUD stuff
//by Endimyonn, version 1.2

public class HUDTools : MonoBehaviour
{
    //Fade an image in for a set amount of time
    ///<summary>Fade in a UI image over a given time, hold it for a given time, then fade it out over a given time.</summary>
    ///<typeparam name = "argSubject">The image to fade in</summary>
    ///<typeparam name = "argStay">How long the image should remain faded in</typeparam>
    ///<typeparam name = "argFadeIn">How long the image should take to fade in</typeparam>
    ///<typeparam name = "argFadeOut">How long the image should take to fade out</typeparam>
    public static IEnumerator ImageFlash(Image argSubject, float argStay, float argFadeIn, float argFadeOut)
    {
        //Debug.Log("hudflash stage1");
        float timerValue = 0f;

        argSubject.color = new Color(argSubject.color.r,argSubject.color.g,argSubject.color.b,0f);
        while (timerValue < argFadeIn)
        {
            timerValue += Time.deltaTime;
            float setAlpha = Mathf.Lerp(0f, 1f, timerValue / argFadeIn);
            argSubject.color = new Color(argSubject.color.r,argSubject.color.g,argSubject.color.b, setAlpha);
            yield return new WaitForEndOfFrame();
            //Debug.Log("stage1 iteration completed - timervalue: " + timerValue + ", setAlpha: " + setAlpha + ", argSubject alpha: " + argSubject.color.a + ", deltatime: " + Time.deltaTime);
        }

        //Debug.Log("hudflash stage2");
        timerValue = 0f;
        yield return new WaitForSeconds(argStay);

        while (timerValue < argFadeOut)
        {
            timerValue += Time.deltaTime;
            float setAlpha = Mathf.Lerp(1f, 0f, timerValue / argFadeOut);
            Color setColor = new Color(argSubject.color.r,argSubject.color.g,argSubject.color.b, setAlpha);
            argSubject.color = setColor;
            yield return new WaitForEndOfFrame();
            //Debug.Log("stage2 iteration completed - timervalue: " + timerValue + ", setAlpha: " + setAlpha + ", argSubject alpha: " + argSubject.color.a + ", deltatime: " + Time.deltaTime);
        }
        //Debug.Log("hudflash stage3");
    }

    ///<summary>Fade in a UI image over a given time.</summary>
    ///<typeparam name = "argSubject">The image to fade in</summary>
    ///<typeparam name = "argFadeTime">How long the image should take to fade in</typeparam>
    public static IEnumerator ImageFadeIn(Image argSubject, float argFadeTime)
    {
        float timerValue = 0f;

        //make sure the object is enabled, then set its alpha to 0
        argSubject.enabled = true;
        argSubject.GetComponent<Image>().enabled = true;
        argSubject.color = new Color(argSubject.color.r,argSubject.color.g,argSubject.color.b,0f);

        //fade it in over time
        while (timerValue < argFadeTime)
        {
            timerValue += Time.deltaTime;
            float setAlpha = Mathf.Lerp(0f, 1f, timerValue / argFadeTime);
            argSubject.color = new Color(argSubject.color.r,argSubject.color.g,argSubject.color.b, setAlpha);
            yield return new WaitForEndOfFrame();
        }
        yield return 0;
    }

    ///<summary>Fade out a UI image over a given time.</summary>
    ///<typeparam name = "argSubject">The image to fade out</summary>
    ///<typeparam name = "argFadeTime">How long the image should take to fade out</typeparam>
    public static IEnumerator ImageFadeOut(Image argSubject, float argFadeTime)
    {
        float timerValue = 0f;

        //fade out over time
        while (timerValue < argFadeTime)
        {
            timerValue += Time.deltaTime;
            float setAlpha = Mathf.Lerp(1f, 0f, timerValue / argFadeTime);
            argSubject.color = new Color(argSubject.color.r,argSubject.color.g,argSubject.color.b, setAlpha);
            yield return new WaitForEndOfFrame();
        }
    }

    ///<summary>Fade in a UI slider over a given time.</summary>
    ///<typeparam name = "argSubject">The slider to fade in</summary>
    ///<typeparam name = "argFadeTime">How long the slider should take to fade in</typeparam>
    public static IEnumerator SliderFadeIn(Slider argSubject, float argFadeTime)
    {
        float timerValue = 0f;
        Image sliderBG = argSubject.transform.GetChild(0).GetComponent<Image>();
        Image sliderFG = argSubject.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();

        //make sure the object is enabled, then set its alpha to 0
        argSubject.enabled = true;
        sliderBG.enabled = true;
        sliderFG.enabled = true;
        sliderBG.color = new Color(sliderBG.color.r,sliderBG.color.g,sliderBG.color.b,0f);
        sliderFG.color = new Color(sliderFG.color.r,sliderFG.color.g,sliderFG.color.b,0f);

        //fade it in over time
        while (timerValue < argFadeTime)
        {
            timerValue += Time.deltaTime;
            float setAlpha = Mathf.Lerp(0f, 1f, timerValue / argFadeTime);
            sliderBG.color = new Color(sliderBG.color.r,sliderBG.color.g,sliderBG.color.b, setAlpha);
            sliderFG.color = new Color(sliderFG.color.r,sliderFG.color.g,sliderFG.color.b, setAlpha);
            yield return new WaitForEndOfFrame();
        }
        yield return 0;
    }

    ///<summary>Fade out a UI slider over a given time.</summary>
    ///<typeparam name = "argSubject">The slider to fade out</summary>
    ///<typeparam name = "argFadeTime">How long the slider should take to fade out</typeparam>
    public static IEnumerator SliderFadeOut(Slider argSubject, float argFadeTime)
    {
        float timerValue = 0f;
        Image sliderBG = argSubject.transform.GetChild(0).GetComponent<Image>();
        Image sliderFG = argSubject.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();

        //fade out over time
        while (timerValue < argFadeTime)
        {
            timerValue += Time.deltaTime;
            float setAlpha = Mathf.Lerp(1f, 0f, timerValue / argFadeTime);
            sliderBG.color = new Color(sliderBG.color.r,sliderBG.color.g,sliderBG.color.b, setAlpha);
            sliderFG.color = new Color(sliderFG.color.r,sliderFG.color.g,sliderFG.color.b, setAlpha);
            yield return new WaitForEndOfFrame();
        }
    }

    #if UNITY_EDITOR
    ///<summary>Draw a string in-editor at a given position.</summary>
    ///<typeparam name = "argText">The text to draw</typeparam>
    ///<typeparam name = "argPosition">World position for the text to render at</typeparam>
    ///<typeparam name = "argColor">Text color</typeparam>
    public static void DrawString(string argText, Vector3 argPosition, Color argColor)
    {
		UnityEditor.Handles.BeginGUI();

		GUI.color = argColor;
        
		UnityEditor.SceneView sceneView = UnityEditor.SceneView.currentDrawingSceneView;
		Vector3 screenPosition = sceneView.camera.WorldToScreenPoint(argPosition);
		Vector2 size = GUI.skin.label.CalcSize(new GUIContent(argText));
		GUI.Label(new Rect(screenPosition.x - (size.x / 2), -screenPosition.y + sceneView.position.height + 4, size.x, size.y), argText);
		UnityEditor.Handles.EndGUI();
	}
    #endif
}
