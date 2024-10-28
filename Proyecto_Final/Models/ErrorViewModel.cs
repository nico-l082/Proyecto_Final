namespace Proyecto_Final.Models
{
    public class ErrorViewModel
    {
        internal string Message;

        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
