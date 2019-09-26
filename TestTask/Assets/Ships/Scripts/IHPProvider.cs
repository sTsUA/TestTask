namespace ShipData
{
    public interface IHPProvider
    {
        float HP { get; }
        void TakeDamage(float amount);
    }
}