var baseEditor = {
    /*    
    route: {
        area, 
        controller, 
        idTab
    },    
    metodo, 
    id,
    title,
    size   
    */
    init: function (route, id, title, size, foco, data, opcion, metodo, botonGuardarVisible, botonCancelarVisible, nombreBotonGuardar, nombreBotonCancelar, cerrarAlGuardar) {
        if (metodo == undefined) {
            metodo = "editor";
        }
        var url = "";
        if (id == undefined)
            url = route.area + "/" + route.controller + "/" + metodo + "/";
        else
            url = route.area + "/" + route.controller + "/" + metodo + "/" + id;

        var params = {
            url: url,
            data: data,
            onSuccess: function (data, textStatus, jqXhr) {
                var options = {
                    data: data,
                    size: size,
                    title: title,
                    buttonOkVisible: botonGuardarVisible,
                    buttonCerrarVisible: botonCancelarVisible,
                    nombreBotonGuardar: nombreBotonGuardar,
                    nombreBotonCancelar: nombreBotonCancelar,
                    cerrarAlGuardar: cerrarAlGuardar,
                    foco: foco
                };
                if (data.toString().indexOf("loginForm") != -1) {
                    window.location = helperConstantes.urlBase + helperConstantes.rutaLogin;
                } else {
                    baseEditor.popup(options, opcion);
                }

            }
        };
        helperAjax.sendGet(params);
    },

    initComplete: function (route, id, data, opcion, metodo) {
        debugger;
        if (metodo == undefined) {
            metodo = "editor";
        }
        var url = "";
        if (id == undefined)
            url = route.area + "/" + route.controller + "/" + metodo + "/";
        else
            url = route.area + "/" + route.controller + "/" + metodo + "/" + id;

        window.location.href = url;

        /*var params = {
            url: url,
            data: data,
            onSuccess: function (data, textStatus, jqXhr) {
                var options = {
                    data: data,
                    size: size,
                    title: title,
                    buttonOkVisible: botonGuardarVisible,
                    buttonCerrarVisible: botonCancelarVisible,
                    nombreBotonGuardar: nombreBotonGuardar,
                    nombreBotonCancelar: nombreBotonCancelar
                };
                if (data.toString().indexOf("loginForm") != -1) {
                    window.location = helperConstantes.urlBase + helperConstantes.rutaLogin;
                } else {
                    baseEditor.popup(options, opcion);
                }

            }
        };
        helperAjax.sendGet(params);*/
    },


    /*
    route: {
        area, 
        controller, 
        idTab
    },        
    width,
    title,
    buttonOkVisible, por defecto: true
    buttonOkLabel, por defecto: 'Guardar'
    buttonOkIcon, por defecto: 'glyphicon glyphicon-save'
    buttonCerrarVisible, por defecto: true
    buttonCerrarLabel, por defecto: 'Cerrar'
    buttonCerrarIcon, por defecto: 'glyphicon glyphicon-log-out'
    open: {	
        onOpen: 
        data:
    },
    onSuccess,
    metodo, 
    id
    */
    initCustom: function (options) {
        var url = "";
        if (options.metodo == undefined) {
            url = options.route.controller + "/Editor";
        }
        else {
            url = options.route.controller + "/" + options.metodo;
        }
        if (options.route.area != undefined) {
            url = options.route.area + "/" + url;
        }

        if (options.id != undefined) url = url + "/" + options.id;


        var params = {
            url: url,
            data: options.data,
            onSuccess: function (data, textStatus, jqXhr) {
                baseEditor.popup(options);
            }
        };
        helperAjax.sendGet(params);
    },

    /*
    title, onOpen, data, width,
    buttonOkVisible, por defecto: true
    buttonOkLabel, por defecto: 'Guardar'
    buttonOkIcon, por defecto: 'glyphicon glyphicon-save'
    buttonCerrarVisible, por defecto: true
    buttonCerrarLabel, por defecto: 'Cerrar'
    buttonCerrarIcon, por defecto: 'glyphicon glyphicon-log-out'
    onSuccess
    */
    popup: function (options, metodo) {
        var buttons = [];
        var buttonOkVisible = true;
        var buttonCerrarVisible = true;
        if (options.cerrarAlGuardar == undefined) options.cerrarAlGuardar = false;
        if (options.buttonOkVisible != undefined) buttonOkVisible = options.buttonOkVisible;
        if (options.nombreBotonGuardar == undefined) options.nombreBotonGuardar = "Guardar"
        if (options.nombreBotonCancelar == undefined) options.nombreBotonCancelar = "Cancelar";
        if (options.size == undefined) options.size = BootstrapDialog.SIZE_NORMAL;
        if (options.buttonCerrarVisible != undefined) buttonCerrarVisible = options.buttonCerrarVisible;
        if (buttonOkVisible == true) {
            var icon = 'ti-save';
            var label = '&nbsp;&nbsp;' + options.nombreBotonGuardar;
            if (options.buttonOkIcon != undefined) icon = options.buttonOkIcon;
            if (options.buttonOkLabel != undefined) label = options.buttonOkLabel;
            buttons.push({
                icon: icon,
                label: label,
                cssClass: 'btn-outline btn-default waves-effect waves-light',
                //hotkey: 13, // Enter.
                action: function (dialogRef) {

                    var form = dialogRef.getModalBody().find('form:first-of-type')
                    if (options.onSuccess != undefined) {
                        debugger;
                        options.onSuccess(dialogRef, form);
                    }
                    else {
                        if (options.cerrarAlGuardar == true) {
                            dialogRef.close();
                        }
                        $(form).submit();
                    }
                }
            });
        }

        if (buttonCerrarVisible == true) {
            var icon = 'glyphicon glyphicon-log-out';
            var label = '&nbsp;&nbsp;' + options.nombreBotonCancelar;
            if (options.buttonCerrarIcon != undefined) icon = options.buttonCerrarIcon;
            if (options.buttonCerrarLabel != undefined) label = options.buttonCerrarLabel;
            buttons.push({
                icon: icon,
                label: label,
                cssClass: 'btn-outline btn-default waves-effect waves-light',
                action: function (dialogRef) {
                    dialogRef.close();
                }
            });
        }

        BootstrapDialog.show({
            title: options.title,
            message: $(options.data),
            draggable: true,
            animate: true,
            //closable: true,
            closeByBackdrop: false,
            closeByKeyboard: true,
            buttons: buttons,
            size: options.size,
            onshow: function (dialogRef) {
                if (options.width != undefined) {
                    dialogRef.getModalDialog().css('width', options.width);
                }
            },
            onshown: function (dialogRef) {

                if (options.foco != undefined) {
                    $(options.foco).focus();
                }

                if (metodo != undefined) {
                    metodo();
                }
                //if (options.open != undefined) {
                //    options.open.onOpen(metodo);
                //}
            },
            onhide: function (dialogRef) {
                //alert("1");
            },
            //onhidden: function (dialogRef) {
            //    alert("2");
            //}            
        });
    },

    focus: function (formContent, idControl) {
        var control = $(formContent).find(idControl);
        $(control).focus();
        $(control).select();
    },

    popupActa: function (options, metodo) {

        if (options.size == undefined) options.size = BootstrapDialog.SIZE_NORMAL;

        BootstrapDialog.show({
            title: options.title,
            message: $(options.data),
            draggable: true,
            animate: true,
            closable: true,
            closeByBackdrop: true,
            closeByKeyboard: true,
            //buttons: buttons,
            size: options.size,
            onshow: function (dialogRef) {
                if (options.width != undefined) {
                    dialogRef.getModalDialog().css('width', options.width);
                }
            },
            onshown: function (dialogRef) {
                if (options.open != undefined) {
                    options.open.onOpen(metodo);
                }
            }
        });
    }

}