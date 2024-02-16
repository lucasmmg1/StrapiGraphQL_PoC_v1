namespace Project.Features.ColorRandomizer.Runtime
{
    using System.Collections;
    using System.Threading.Tasks;
    using UnityEngine;
    using SimpleGraphQL;
    using Base.Runtime;
    using TMPro;

    [AddComponentMenu("Scripts/Project/Features/ColorRandomizer/ColorRandomizerSceneController")]
    public class ColorRandomizerSceneController : MonoBehaviour
    {
        #region Variables

        #region Private Variables
        
        [SerializeField] private int allowedAmountOfExceptions;
        [SerializeField] private float timeToWaitBeforeChangingColor;
        [SerializeField] private Renderer cube;
        [SerializeField] private TextMeshProUGUI colorNameTMP;
        [SerializeField] private string endpoint;
        [TextArea][SerializeField] private string query;
        private int _thrownExceptions;
        private GraphQLClient _client;

        #endregion

        #endregion

        #region Methods

        #region Private Methods

        private void Start()
        {
            _client = new GraphQLClient(endpoint);
            StartCoroutine(ChangeColorEverySecondCoroutine());
        }
        private IEnumerator ChangeColorEverySecondCoroutine()
        {
            while (true)
            {
                if (_thrownExceptions >= allowedAmountOfExceptions)
                {
                    Debug.LogError("Exceptions' limit reached. Stopping the coroutine.");
                    yield break;
                }

                var task = ChangeColorEverySecondTask();
                yield return task.ToIEnumerator();
                if (task.IsFaulted && task.Exception != null)
                {
                    var wordWithCorrectTermination = FloatExtensions.Equals(timeToWaitBeforeChangingColor, 1) ? "second" : "seconds";
                    Debug.LogError($"Exception: {task.Exception}");
                    Debug.LogWarning($"Trying again in {timeToWaitBeforeChangingColor} {wordWithCorrectTermination}");
                    _thrownExceptions++;
                }
                yield return new WaitForSeconds(1);
            }
        }
        private async Task ChangeColorEverySecondTask()
        {
            var request = new Request {Query = query};
            var responseType = new {getRandomColor = new {name = ""}};
            var color = cube.material.color;
            
            do
            {
                var response = await _client.Send(() => responseType, request);
                if (response.Errors is {Length: > 0})
                {
                    Debug.LogError(response.Errors);
                    _thrownExceptions++;
                }
                else
                {
                    color = response.Data.getRandomColor.name.ToRGBColor();
                }
            } while (color == cube.material.color);
            AssignCubeColor(color);
            AssignColorName(color.ToHexColor());
        }
        private void AssignCubeColor(Color color)
        {
            if (cube != null)
            {
                cube.material.color = color;
            }
            else
            {
                Debug.LogWarning("Warning: cube's variable not assigned");
                _thrownExceptions++;
            }
        }
        private void AssignColorName(string colorName)
        {
            if (colorNameTMP != null)
            {
                if (!colorNameTMP.gameObject.activeSelf)
                    colorNameTMP.gameObject.SetActive(true);
                
                colorNameTMP.text = $"Current color: {colorName}";
            }
            else
            {
                Debug.LogWarning("Warning: colorNameTMP's variable not assigned");
            }
        }

        #endregion

        #endregion
    }
}