namespace ChatDev.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string message) : base(message) 
        {

        }
    }
}
