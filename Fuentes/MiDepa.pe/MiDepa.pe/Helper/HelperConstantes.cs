namespace MiDepa.pe.Helper
{
    public class HelperConstantes
    {
        public const string GSesionUsuario = "SessionUsuario";
        public const string GSesionDatos = "DatosSesion";
        public const string GSesionStope = "StopeSesion";
        public const string GSesionMovDiario = "MovDiarioSesion";
        public const string GSesionActividad = "ActividadSesion";
        public const string GSesionFiltrosPrograma = "FiltrosProgramaSesion";
        public const string GSesionFiltrosDetallePrograma = "FiltrosDetalleProgramaSesion";
        public const string GSesionFiltrosPago = "FiltrosPagoSesion";
        public const string GSesionFiltrosMovimiento = "FiltrosMovimiento";

        public const string GIdMonedaSoles = "001";
        public const string GIdEstadoFinalizado = "003";
        public const string GIdValorTileSbs = "INTERES_SBS";
        public const string GIdConceptoCombustible = "2301030101";

        public const string GTipoUsuarioCas = "CAS";
        public const string GTipoUsuarioCap = "CAP";
        public const string GTipoUsuarioExterno = "EXT";

        public const decimal GImpuestoMulti = 0.18M;
        public const decimal GImpuestoDiv = 1.18M;

        public class Permisos
        {
            public const int ACCESODIRECTO_NOTIFICACIONES = 2;
            public const int ACCESODIRECTO_CALENDARIO = 3;
            public const int ACCESODIRECTO_PAQUETES = 4;
            public const int ACCESODIRECTO_APROBACIONPAGOS = 5;
            public const int PUEDE_CREAREDITAR_CAMPANIA = 8;
            public const int PUEDE_ELIMINAR_CAMPANIA = 9;
        }
    }
}
