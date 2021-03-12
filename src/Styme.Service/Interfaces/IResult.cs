namespace Styme.Service.Interfaces
{
    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }

    public interface IResult
    {
        bool Succeeded { get; set; }
    }
}
