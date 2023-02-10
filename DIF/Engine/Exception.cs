namespace Engine
{
    public class EngineException : ApplicationException
    {
        public EngineException(string Message) : base(Message) { }
    }

    public class UnknownException : EngineException
    {
        public UnknownException() : base("Unknown exception!") { }
    }
}
