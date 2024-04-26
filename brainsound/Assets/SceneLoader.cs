using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadScene(string sceneName)
    {
        // Save the current player position
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);

        // Load the new scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
