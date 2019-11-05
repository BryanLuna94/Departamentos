namespace MiDepa.pe.DataTypes
{
    public class Edificio_CuentaBancaria
    {
        public int CuentaBancariaId { get; set; }
        public int EdificioId { get; set; }
        public int BancoId { get; set; }
        public string NumeroCuenta { get; set; }
        public string Titular { get; set; }
    }
}
