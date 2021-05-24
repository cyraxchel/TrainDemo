using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace cyraxchel.trainer.menu
{
    public class SimpleMenu : MonoBehaviour
    {
        public void LoadLevel(int indx)
        {
            SceneManager.LoadScene(indx);
        }
    }
}