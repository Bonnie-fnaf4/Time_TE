using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.SceneManagement;

public class AddressablesInitializerAndLoadScene : MonoBehaviour
{
    [SerializeField] private string sceneAddress; 

    private async void Start()
    {
        AsyncOperationHandle<IResourceLocator> initHandle = Addressables.InitializeAsync(false);
        
        await initHandle.Task;

        if (initHandle.Status == AsyncOperationStatus.Succeeded)
        {
            LoadTargetScene();
        }
        else
        {
            Debug.LogError(initHandle.Status);
        }
    }

    private async void LoadTargetScene()
    {
        
        AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> sceneHandle = 
            Addressables.LoadSceneAsync(sceneAddress, LoadSceneMode.Single);

        await sceneHandle.Task;
        
        if (sceneHandle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError(sceneHandle.Status);
        }
    }
}