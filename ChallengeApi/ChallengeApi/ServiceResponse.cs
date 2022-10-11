namespace ChallengeApi
{
    public class ServiceResponse<TData> where TData : class
    {
        public TData? Data { get; init; }
        public bool SuccesFull { get; init; } = true;
        public string Message { get; init; } = String.Empty;
    }

    public class ServiceResponse
    {
        public bool SuccesFull { get; init; } = true;
        public string Message { get; init; } = String.Empty;
    }
}
