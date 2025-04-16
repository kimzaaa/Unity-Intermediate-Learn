using UnityEngine;
using System.Collections;

public class InterFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeDuration = 1f;

    [SerializeField] private bool _isShown;
    /*
    IEnumerator Fade(){
        float alpha = _isShown ? 0f : 1f; //if _isShown is true, alpha = 0, else alpha = 1
        if(_isShown){
          while(alpha < 1f){
            alpha += Time.deltaTime * _fadeSpeed; //increase alpha by fadeSpeed
            _canvasGroup.alpha = alpha; //set the alpha of the canvas group
            yield return null; //wait for the next frame

          }       
        }
        else{
            while(alpha > 0f){
                alpha -= Time.deltaTime * _fadeSpeed; //decrease alpha by fadeSpeed
                _canvasGroup.alpha = alpha; //set the alpha of the canvas group
                yield return null; //wait for the next frame
            } 
        }

        yield return new WaitForSeconds(0.5f); //wait for 0.1 seconds
        Debug.Log("Fade complete!"); //log the message
    }
    */
    [ContextMenu("Toggle UI")]
    public void ToggleUI(){
        _isShown = !_isShown; 

        _canvasGroup.Fade(_isShown,_fadeDuration); //call the Fade method from the ExtensionMethod class
    }
}
