namespace Project.Features.ColorRandomizer.Runtime
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;
    using SimpleGraphQL;
    using Base.Runtime;
    using Color = Base.Runtime.Color;
    using Random = UnityEngine.Random;

    [AddComponentMenu("Scripts/Project/Features/ColorRandomizer/ColorRandomizerSceneController")]
    public class ColorRandomizerSceneController : MonoBehaviour
    {
        #region Variables

        #region Private Variables

        [SerializeField] private Renderer cube;
        private GraphQLClient _client;
        private const string Query = @"
        {
            colors {
                name
            }
        }";

        #endregion

        #endregion

        #region Methods

        #region Private Methods

        private void Start()
        {
            _client = new GraphQLClient("http://localhost:1337/graphql");
            StartCoroutine(ChangeColorEverySecondCoroutine());
        }
        private IEnumerator ChangeColorEverySecondCoroutine()
        {
            while (true)
            {
                yield return Enumerators.TaskToIEnumerator(ChangeColorEverySecondTask());
                yield return new WaitForSeconds(1);
            }
        }
        private async Task ChangeColorEverySecondTask()
        {
            Debug.Log("Randomizing new color");
            var request = new Request {Query = Query};
            var responseType = new { colors = new[] {new {name = ""}}};
            var response = await _client.Send(() => responseType, request);
            if (response.Errors is {Length: > 0})
            {
                Debug.LogError(response.Errors);
                return;
            }
            AssignNewColor(GetRandomColorFromList(response.Data.colors));
        }
        private UnityEngine.Color GetRandomColorFromList(IReadOnlyList<dynamic> colors)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, colors.Count);
            } while (Color.HexToRGB(colors[randomIndex].name) == cube.material.color);
            return Color.HexToRGB(colors[randomIndex].name);
        }
        private void AssignNewColor(UnityEngine.Color color)
        {
            switch (cube != null)
            {
                case true:
                    cube.material.color = color;
                    break;
                default:
                    Debug.LogWarning("Warning: cube is not assigned");
                    break;
            }
        }

        #endregion

        #endregion
    }
}