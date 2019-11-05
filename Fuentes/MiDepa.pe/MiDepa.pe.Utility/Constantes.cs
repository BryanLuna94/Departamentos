namespace MiDepa.pe.Utility
{
    public class Constantes
    {
        public class Mensajes
        {
            public const string USUARIO_NO_EXISTE = "El usuario ingresado no existe en la base de datos";
            public const string CLAVE_USUARIO_INCORRECTA = "La clave ingresada es incorrecta";
            public const string PERFIL_YA_EXISTE = "El perfil ingresado ya existe en la base de datos";
            public const string PERFIL_TIENE_USUARIO = "Se encontró usuarios registrados con este perfil. Primero debe eliminar los usuarios";
            public const string NOMBREUSUARIO_YA_EXISTE = "El nombre de usuario ingresado ya existe en la base de datos";
            public const string USUARIO_YA_EXISTE = "El usuario ingresado ya existe en la base de datos";
            public const string DIAS_RETRASO = "Tienes {0} dias de retraso";
            public const string DIAS_FALTANTES = "Falta {0} dias para el vencimiento";
            public const string HOY_DIOPAGO = "Hoy es el día de pago";
            public const string TEXTO_AL_DIA = "Estás al día";
            public const string TEXTO_NOAL_DIA = "No estás al día";
            public const string PAGO_NOELIMINAR = "No se puede eliminar este pago";
            public const string FOTO_PAGO_OBLIGATORIO = "Debe ingresar al menos una foto del pago";

            public const string ALMACEN_TIENEUBICACIONES = "El almacén {0} no se puede eliminar porque tiene ubicaciones registradas";
            public const string ALMACEN_TIENESTOCK = "El almacén {0} no se puede eliminar porque tiene artículos en stock";
            public const string UBICACIONALMACEN_YA_EXISTE = "La ubicación en éste almacén ya existe en la base de datos";
            public const string UNIDADMEDIDA_YA_EXISTE = "La unidad de medida {0} ya existe en la base de datos";
            public const string PERSONA_YA_EXISTE = "La empresa con el N° de documento {0} ya existe en la base de datos";
            public const string PERSONA_TIENEMOVIMIENTOS = "Este empresa no se puede editar porque esta presente en los movimientos de artículos";
            public const string PERSONA_TIENEMARCA = "Este empresa no se puede editar porque ya fue registrado como fabricante de un artículo";
            public const string ARTICULO_YA_EXISTE = "La descripción y/o part# ingresados ya existen en la base de datos";
            public const string ARTICULO_TIENEMOVIMIENTOS = "No puede editar este artículo porque tiene movimientos enlazados";
            public const string MOVIMIENTO_YA_EXISTE = "El documento ingresado ya existe en la base de datos";
            public const string MOVIMIENTODETALLE_YA_EXISTE = "Esta serie ya se registró para este movimiento";
            public const string MOVIMIENTODETALLE_SALIO = "No puede editar este artículo porque tiene un movimiento enlazado";
            public const string MOVIMIENTOCABECERA_SALIO = "No puede editar este movimiento porque tiene un otro movimiento enlazado";
            public const string MARCA_YA_EXISTE = "El marca {0} ya existe en la base de datos";
            public const string MOVIMIENTO_ESTADO_DIFERENTE = "Para una salida todos los productos deben tener el mismo estado";
        }

        public class Tablas
        {
            public const string ESTADO_PAGO = "1";
            public const string TIPO_MOVIMIENTO = "2";
            public const string TIPO_NOTIFICACION = "3";
            public const string TIPO_DOCUMENTO = "4";
            public const string ESTADO_CLIENTE = "5";
            public const string ESTADO_CONTRATO = "6";
            public const string CONCEPTO = "7";
            public const string NOTIFICACION = "8";
            public const string BANCO = "9";
            public const string PAGO = "10";
            public const string PAQUETE = "11";
            public const string EVENTO = "12";

            public class TipoDocIdentidad
            {
                public const string DNI = "1";
                public const string RUC = "6";
            }

            public class TipoMovimiento
            {
                public const string INGRESO = "1";
                public const string SALIDA = "2";
            }

            public class TipoDocumento
            {
                public const string GUIAREMISION = "9";
                public const string DUA = "10";
                public const string FACTURA = "1";
                public const string BOLETAVENTA = "3";
                public const string OTROS = "99";
            }

            public class TipoMov
            {
                public const string IMPORTACION = "IMP";
                public const string EXPORTACION = "EXP";
                public const string COMPRA = "COM";
                public const string VENTA = "VEN";
                public const string DELIVERY = "DEL";
                public const string DEVOLUCION = "DEV";
            }

            public class EstadoAprobacion
            {
                public const string PENDIENTE = "1";
                public const string APROBADO = "2";
                public const string RECHAZADO = "3";
            }

        }

        public class DatosAplicacion
        {
            public const string MODULO_COMERCIAL = "1";
            public const string NOMBRE_SISTEMA = "SistemaComercial";
        }

        public class Configuracion
        {

        }

        internal const string CLAVE = "VLBJ#40#";
    }
}
