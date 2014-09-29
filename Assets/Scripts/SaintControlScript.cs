namespace Assets
{
    public class SaintControlScript : CharacterControlScript
    {
        protected override string PunchedAnimationName
        {
            get { return "SaintPunched"; }
        }

        protected override string SurvivedAnimationName
        {
            get { return "SaintSurvived"; }
        }  
    }
}