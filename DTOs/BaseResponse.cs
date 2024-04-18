namespace Ecommerce.DTOs;

public class BaseResponse<T>
{
    public string Mesaage { get; set; }
    public bool Status { get; set; }
    public T Data { get; set; }
}