var helperNotificacion = {
    /*************************************************************************************
   HELPER: procesamiento de mensajes de las llamadas ajax
   *************************************************************************************/

    //Procesa los mensajes ocurridos después de una llamada realizada con $.ajax
    procesarSuccessDefault: function (data, textStatus, jqXhr, messageSuccess) {
        if (data == null) {
            mensaje.satisfactorio(messageSuccess);
            return true;
        }
        if (data.tipoNotificacion == "Advertencia") {
            mensaje.advertencia(data.mensaje);
            return false;
        } else if (data.tipoNotificacion == "Informativo") {
            mensaje.informacion(data.mensaje);
            return false;
        } else if (data.tipoNotificacion == "Alerta") {
            mensaje.alerta(data.mensaje);
            return false;
        } else if (data.tipoNotificacion == "Satisfactorio") {
            if (data.mensaje != undefined) {
                mensaje.satisfactorio(data.mensaje);
            }
            return true;
        } else {
            if (messageSuccess != undefined && messageSuccess != "") {
                mensaje.satisfactorio(messageSuccess);
            }
            return true;
        }
    },

    procesarErrorDefault: function (data, textStatus, errorThrown) {
        BootstrapDialog.show({
            title: textStatus,
            type: BootstrapDialog.TYPE_DANGER,
            message: errorThrown.responseText
        });        
    }
};