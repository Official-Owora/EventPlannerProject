namespace EventPlannerProject.WebAPI.Exceptions
{
    public class IdParametersBadRequestException : BadRequestException
    {
        public IdParametersBadRequestException() : base("Parameter Id is null")
        {
            
        }
    }
}
