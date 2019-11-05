var mensaje = {
    confirmacion: function (mensaje, functionSi, parametrosSi) {

        swal({
            title: "\u00BFDesea continuar?",
            text: mensaje,
            type: "warning",
            confirmButtonColor: "#DD6B55", 
            showCancelButton: true,
            confirmButtonText: "Si, deseo continuar!",
            cancelButtonText: "Cancelar",
            cancelButtonClass: "btn-default",
            closeOnConfirm: true
        },
            function () {
                functionSi(parametrosSi);
                //swal("Deleted!", "Your imaginary file has been deleted.", "success");
            });

        //noty220({
        //    text: mensaje,
        //    type: 'confirm',
        //    dismissQueue: true,
        //    modal: true,
        //    layout: 'center',
        //    theme: 'defaultTheme',
        //    buttons: [
        //        {
        //            addClass: 'btn btn-info',
        //            text: 'Si',
        //            onClick: function ($noty) {
        //                $noty.close();
        //                functionSi(parametrosSi);
        //            }
        //        },
        //        {
        //            addClass: 'btn btn-danger',
        //            text: 'No',
        //            onClick: function ($noty) {
        //                $noty.close();
        //            }
        //        }
        //    ]
        //});
    },
    advertencia: function (mensaje) {
        //noty220({
        //    text: mensaje,
        //    type: 'warning',
        //    dismissQueue: true,
        //    modal: true,
        //    layout: 'center',
        //    theme: 'defaultTheme',
        //    buttons: [
        //        {
        //            addClass: 'btn btn-primary',
        //            text: 'Ok',
        //            onClick: function ($noty) {
        //                $noty.close();
        //            }
        //        }
        //    ]
        //});

        $.toast({
            heading: 'Mensaje del Servidor',
            text: mensaje,
            position: 'top-right',
            //loaderBg: '#ff6849',
            hideAfter: false,
            icon: 'warning',
            stack: 6
        });
    },
    alerta: function (mensaje) {
        //noty220({
        //    text: mensaje,
        //    type: 'alert',
        //    dismissQueue: true,
        //    modal: true,
        //    layout: 'center',
        //    theme: 'defaultTheme',
        //    buttons: [
        //        {
        //            addClass: 'btn btn-primary',
        //            text: 'Ok',
        //            onClick: function ($noty) {
        //                $noty.close();
        //            }
        //        }
        //    ]
        //});

        $.toast({
            heading: 'Mensaje del Servidor',
            text: mensaje,
            position: 'top-right',
            //loaderBg: '#ff6849',
            hideAfter: false,
            icon: 'warning',
            stack: 6
        });
    },
    informacion: function (mensaje, ruta) {
        //noty220({
        //    text: mensaje,
        //    type: 'information',
        //    dismissQueue: true,
        //    modal: true,
        //    layout: 'center',
        //    theme: 'defaultTheme',
        //    buttons: [
        //        {
        //            addClass: 'btn btn-primary',
        //            text: 'Ok',
        //            onClick: function ($noty) {
        //                $noty.close();
        //                if (ruta != undefined) {
        //                    window.location = ruta;
        //                }
        //            }
        //        }
        //    ]
        //});

        $.toast({
            heading: 'Informaci\u00F3n',
            text: mensaje,
            position: 'top-right',
            //loaderBg: '#ff6849',
            hideAfter: false,
            icon: 'info',
            stack: 6
        });
    },
    notificacion: function (mensaje) {
        //noty220({
        //    text: mensaje,
        //    type: 'notification',
        //    dismissQueue: true,
        //    modal: false,
        //    maxVisible: 10,
        //    timeout: 1500,
        //    layout: 'topCenter',
        //    theme: 'defaultTheme'
        //});

        $.toast({
            heading: 'Informaci\u00F3n',
            text: mensaje,
            position: 'top-right',
            //loaderBg: '#ff6849',
            icon: 'success',
            hideAfter: 3500,
            stack: 6
        });
    },
    satisfactorio: function (mensaje) {
        //noty220({
        //    text: mensaje,
        //    type: 'success',
        //    dismissQueue: true,
        //    modal: false,
        //    maxVisible: 10,
        //    timeout: 3000,
        //    layout: 'topCenter',
        //    theme: 'defaultTheme'
        //});

        $.toast({
            heading: 'Informaci\u00F3n',
            text: mensaje,
            position: 'top-right',
            loaderBg: '#FF5733',
            icon: 'info',
            hideAfter: 3000,
            stack: 6,
        });
    }        
};