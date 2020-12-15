namespace Tienda_Inventario_SharedKernel.Core
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}