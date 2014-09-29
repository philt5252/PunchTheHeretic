namespace Assets
{
    public class HereticControlScript : CharacterControlScript
    {
        protected override string PunchedAnimationName
        {
            get { return "HereticPunched"; }
        }

        protected override string SurvivedAnimationName
        {
            get { return "HereticSurvived"; }
        }
    }
}