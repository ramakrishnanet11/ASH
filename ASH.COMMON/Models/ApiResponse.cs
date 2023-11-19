namespace ASH.COMMON.Models
{
    public class CommonResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string ErrorMessage { get; set; } = string.Empty;    
        public T Data { get; set; }
        public Exception Exception { get; set; }    
    }
}
