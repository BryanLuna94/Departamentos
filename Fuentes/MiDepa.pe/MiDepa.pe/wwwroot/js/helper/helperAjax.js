var helperAjax = {
    //Obtiene la Url absoluta apartir de la url relativa, si el aplicativo tiene un nombre este se agrega como parte de la URL
    obtenerUrlAbsoluta: function (urlRelativa) {
        //        urlRelativa = urlRelativa.toLowerCase();
        var nombreAplicativo = helperConstantes.nombreAplicativo.toLowerCase();
        if (nombreAplicativo == "") {
            return helperConstantes.urlBase + "/" + urlRelativa;
        } else {
            if (urlRelativa.indexOf(nombreAplicativo) > -1)
                return helperConstantes.urlBase + "/" + nombreAplicativo + "/" + urlRelativa.replace(nombreAplicativo + "/", "");
            nombreAplicativo = helperConstantes.nombreAplicativo.toUpperCase();
            if (urlRelativa.indexOf(nombreAplicativo) > -1)
                return helperConstantes.urlBase + "/" + nombreAplicativo + "/" + urlRelativa.replace(nombreAplicativo + "/", "");
            return helperConstantes.urlBase + "/" + nombreAplicativo + "/" + urlRelativa;
        }
    },

    /*************************************************************************************
    HELPER: llamadas ajax
    *************************************************************************************/

    /*PARAMS

    encoding: 
    cache: 
    esUrlAbsoluta:  true/false
    url:         url relativa en formato --> xxxx/xxx
    data:             Se usa para especificar datos a mandar.

    tab: {
        title: titulo del tab, (Indica si debe agregarse un tab y ponerse el contenido ahí) si el valor es true no se toma en cuenta updateTargetId
    }

    updateTargetId:   id del objeto que se actualiza con la data devuelta por la llamada.    
    loadingElementId: id del objeto que se muetsra mientas se realiza la llamada
    mostrarAnimacion: indica si se muestra la animacion, por defecto es true
    messageSuccess: Mensaje cuando la operacion es satisfactoria

    onBeforeSend:  Permite llamar una función antes de mandar el objeto ajax.
    onComplete:    Es una funcion que se ejecuta cuando el llamado al ajax esta completo. Permite saber si fue existoso
    onSuccess:     Función para ejecutar código al ser exitoso un llamado.
    onSuccessComplete:     Función para ejecutar código al ser exitoso un llamado. (Este se ejecuta al final)
    onFailure:     función que se ejecuta cuando la llamada genera un error.
    onBegin:       función que se ejecuta cuando se inicia la llamada.
    onError:       Se ejecuta si ocurre un error al llamar el archivo. Devuelve 3 parametros: El objeto, un string con el error, y un objeto adicional de error, si este ocurre.

    idWrapperEditor: Fomrulario desde donde se realiza la llmada, si este se especifica se cierra
    */

    sendGet: function (params) {
        params.type = "GET";

        if (params.messageConfirmation != undefined) {
            mensaje.confirmacion(params.messageConfirmation, helperAjax.ejecutar, params);
        } else {
            helperAjax.ejecutar(params);
        }
    },

    sendPost: function (params) {
        params.type = "POST";
        if (params.processData === false) {
            if (params.messageConfirmation != undefined) {
                mensaje.confirmacion(params.messageConfirmation, helperAjax.ejecutarArchivo, params);
            } else {
                helperAjax.ejecutarArchivo(params);
            }
        } else {
            if (params.messageConfirmation != undefined) {
                mensaje.confirmacion(params.messageConfirmation, helperAjax.ejecutar, params);
            } else {
                helperAjax.ejecutar(params);
            }
        }
    },

    ejecutar: function (params) {

        params.cache = false;

        if (params.addTab == undefined) params.addTab = false;
        if (params.encoding == undefined) params.encoding = "UTF-8";
        if (params.mostrarAnimacion == undefined) params.mostrarAnimacion = true;
        if (params.async == undefined) params.async = true;
        if (params.loadingElementId == undefined) params.loadingElementId = "#id-layout-processing";

        var url = "";
        if (params.esUrlAbsoluta == undefined || params.esUrlAbsoluta == false) {
            url = helperAjax.obtenerUrlAbsoluta(params.url);
        } else {
            url = params.url;
        }

        $.ajax({
            cache: params.cache,
            async: params.async,
            url: url,
            type: params.type,
            encoding: params.encoding,
            data: params.data,
            beforeSend: function () {
                if (params.mostrarAnimacion == true) {
                    $(params.loadingElementId).show();
                }
            },
            complete: function (jqXhr, textStatus) {
                if (params.mostrarAnimacion == true) {
                    $(params.loadingElementId).hide();
                }

                if (params.onComplete != undefined) {
                    params.onComplete(jqXhr, textStatus);
                }
            },
            success: function (data, textStatus, jqXhr) {
                var success = helperNotificacion.procesarSuccessDefault(data, textStatus, jqXhr, params.messageSuccess);
                if (success == true) {
                    /*Si los parametros tiene funcion success*/
                    if (params.onSuccess != undefined) {
                        params.onSuccess(data, textStatus, jqXhr);
                    }

                    //Si existe formulario, lo cierra
                    if (params.idWrapperEditor != undefined) {
                        $.each(BootstrapDialog.dialogs, function (id, dialog) {
                            var form = $("div#" + id + " " + params.idWrapperEditor);
                            if (form.length > 0) {
                                if (params.close == undefined || params.close === true)
                                    dialog.close();
                            }
                        });
                    }

                    if (params.close === true) {
                        $.each(BootstrapDialog.dialogs, function (id, dialog) {
                            if (params.formCerrar != undefined) {
                                if (dialog.options.title == params.formCerrar) {
                                    dialog.close();
                                }
                            } else {
                                dialog.close();
                            }
                        });
                    }


                    if (params.tab != undefined) {
                        var title = "";
                        if (params.tab.title != undefined) title = params.tab.title;
                        helperTabs.add(title, data, params.tab.idTab);
                    }
                    else if (params.updateTargetId != undefined) {
                        $(params.updateTargetId).html(data);
                        if (params.onSuccessComplete != undefined) {
                            params.onSuccessComplete(data);
                        }
                    }

                    if (params.onSuccessComplete != undefined) {
                        params.onSuccessComplete(data);
                    }

                }
            },
            error: function (jqXhr, textStatus, errorThrown) {
                if (params.onError != undefined) {
                    params.onError(jqXhr, textStatus, errorThrown);
                }
                else {
                    helperNotificacion.procesarErrorDefault(jqXhr, textStatus, jqXhr);
                }
            }
        });
    },

    ejecutarArchivo: function (params) {
        params.cache = false;

        if (params.addTab == undefined) params.addTab = false;
        if (params.mostrarAnimacion == undefined) params.mostrarAnimacion = true;
        if (params.loadingElementId == undefined) params.loadingElementId = "#id-layout-processing";
        if (params.processData == undefined) params.processData = true;
        if (params.contentType == undefined) params.contentType = true;

        var url = "";
        if (params.esUrlAbsoluta == undefined || params.esUrlAbsoluta == false) {
            url = helperAjax.obtenerUrlAbsoluta(params.url);
        } else {
            url = params.url;
        }

        $.ajax({
            cache: params.cache,
            url: url,
            type: params.type,
            data: params.data,
            contentType: params.contentType,
            processData: params.processData,
            beforeSend: function () {
                if (params.mostrarAnimacion == true) {
                    $(params.loadingElementId).show();
                }
            },
            complete: function (jqXhr, textStatus) {
                if (params.mostrarAnimacion == true) {
                    $(params.loadingElementId).hide();
                }

                if (params.onComplete != undefined) {
                    params.onComplete(jqXhr, textStatus);
                }
            },
            success: function (data, textStatus, jqXhr) {
                var success = helperNotificacion.procesarSuccessDefault(data, textStatus, jqXhr, params.messageSuccess);
                if (success == true) {
                    /*Si los parametros tiene funcion success*/
                    if (params.onSuccess != undefined) {
                        params.onSuccess(data, textStatus, jqXhr);
                    }

                    //Si existe formulario, lo cierra
                    if (params.idWrapperEditor != undefined) {
                        $.each(BootstrapDialog.dialogs, function (id, dialog) {
                            var form = $("div#" + id + " " + params.idWrapperEditor);
                            if (form.length > 0) {
                                if (params.close == undefined || params.close === true)
                                    dialog.close();

                            }
                        });
                    }

                    if (params.close === true) {
                        $.each(BootstrapDialog.dialogs, function (id, dialog) {
                            if (params.formCerrar != undefined) {
                                if (dialog.options.title == params.formCerrar) {
                                    dialog.close();
                                }
                            } else {
                                dialog.close();
                            }
                        });
                    }

                    if (params.tab != undefined) {
                        var title = "";
                        if (params.tab.title != undefined) title = params.tab.title;
                        helperTabs.add(title, data, params.tab.idTab);
                    }
                    else if (params.updateTargetId != undefined) {
                        $(params.updateTargetId).html(data);
                    }

                    if (params.onSuccessComplete != undefined) {
                        params.onSuccessComplete(data);
                    }

                    if (params.recargar == true) {
                        location.reload(true);
                    }
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {
                if (params.onError != undefined) {
                    params.onError(jqXhr, textStatus, errorThrown);
                }
                else {
                    helperNotificacion.procesarErrorDefault(jqXhr, textStatus, jqXhr);
                }
            }
        });
    },


    downloadArchivo: function (url) {
        var idContenedor = "iframeDownloadFile_QW123_LKI098";
        var contenedor = $("body").find("#" + idContenedor);
        if (contenedor.length == 0) {
            var iframe = "<iframe id='" + idContenedor + "' src='" + url + "' style='display:none'></iframe>";
            $("body").append(iframe);
        } else {
            $(contenedor).attr("src", url);
        }
        //e.stopPropagation();
    },

    downloadStorageEngine: function (idArchivo) {
        var url = helperConstantes.urlStorageEngine + "/download/idArchivo/" + idArchivo;

        var idContenedor = "iframeDownloadFile_QW123_LKI098";
        var contenedor = $("body").find("#" + idContenedor);
        if (contenedor.length == 0) {
            var iframe = "<iframe id='" + idContenedor + "' src='" + url + "' style='display:none'></iframe>";
            $("body").append(iframe);
        } else {
            $(contenedor).attr("src", url);
        }

        return false;
    },

    uploadStorageEngine: function (params) {
        var url = helperConstantes.urlStorageEngine + "/" + params.url;
        $.ajaxFileUpload(
            {
                url: url,
                secureuri: false,
                fileElementId: params.fileElementId,
                dataType: 'json',
                success: function (data, status) {
                    if (params.success != undefined)
                        params.success(data, status);
                    else {
                        helperNotificacion.procesarSuccessDefault(data, status);
                    }

                },
                error: function (data, status, e) {
                    helperNotificacion.procesarErrorDefault("", "", e);
                }
            }
        );
        return false;
    },

    esIE: function () {
        return navigator.userAgent.indexOf("MSIE") > 0;
    }
};