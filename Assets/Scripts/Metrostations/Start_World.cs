
using UnityEngine;
using UnityEngine.U2D.Animation;


public class Start_World : MonoBehaviour
{


    API_calls sn;
    public GameObject characterOriginal;
    public SpriteLibraryAsset color1;
    public SpriteLibraryAsset color2;
    public SpriteLibraryAsset color3;
    public SpriteLibraryAsset color4;
    public SpriteLibraryAsset color5;

    

    // Start is called before the first frame update
    async void Start()
    {

        //get API SCRIPT OBJECT
        sn = gameObject.GetComponent<API_calls>();

        //api call to get questions
        var questionList = await sn.GetQuestionsByStation(9);
        Debug.Log(questionList);

        //array of colors for character
        SpriteLibraryAsset[] listOfColors= { color1, color2, color3, color4, color5 };

        int i = 0;
     

        foreach (QuestionModel question in questionList)
        {
            var position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));

            //clone object
            GameObject otherCharcClone = Instantiate(characterOriginal,position,characterOriginal.transform.rotation);

            //set colorscheme character
            otherCharcClone.gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = listOfColors[i];

            //set variables for questions
            otherCharcClone.gameObject.GetComponent<Character_base>().questionID_list= i;
            otherCharcClone.gameObject.GetComponent<Character_base>().questionID_api = question.questionID;
           
               
            i++;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
