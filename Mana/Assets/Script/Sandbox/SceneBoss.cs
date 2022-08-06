using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace Sandbox
{

    public class SceneBoss : MonoBehaviour
    {

        [SerializeField] Image screenFade;
        [SerializeField] float fadeTime = 2;

        public void RestartLevel()
        {
            screenFade.DOFade(100, fadeTime).OnComplete(() => SceneManager.LoadScene(0));
        }
        

    }

}