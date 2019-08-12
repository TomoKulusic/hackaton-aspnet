namespace SmartHousing.API.ResponseWrapper
{
  public class ApiLoginResponse
  {

    public bool valid { get; set; }
    public string reason { get; set; }
    public ApiLoginResponse(bool valid, string reason)
    {
      this.valid = valid;
      this.reason = reason;
    }
  }
}