var selectOk = false;
var autocomplete = {
    iniciarSearchPersona: function (inputSearchId, inputHiddenId, onSuccessComplete) {
        autocomplete.iniciarsearch("persona", inputSearchId, inputHiddenId, autocomplete.persona.success, autocomplete.persona.selected, onSuccessComplete);
    },

    iniciarSearchUbigeoLocalidad: function (inputSearchId, inputHiddenId, onSuccessComplete, inputAnotherFilter) {
        autocomplete.iniciarsearchCustom("ubigeoLocalidad", inputSearchId, inputHiddenId, autocomplete.ubigeoLocaldad.success, autocomplete.ubigeoLocaldad.selected, onSuccessComplete, inputAnotherFilter);
    },

    iniciarSearchEquiposDisponibles: function (inputSearchId, inputHiddenId, onSuccessComplete) {
        autocomplete.iniciarsearch("equiposdisponibles", inputSearchId, inputHiddenId, autocomplete.equipo.success, autocomplete.equipo.selected, onSuccessComplete);
    },

    iniciarSearchEquiposAsignados: function (inputSearchId, inputHiddenId, onSuccessComplete) {
        autocomplete.iniciarsearch("equiposasignados", inputSearchId, inputHiddenId, autocomplete.equipo.success, autocomplete.equipo.selected, onSuccessComplete);
    },

    iniciarSearchUsuarios: function (inputSearchId, inputHiddenId, onSuccessComplete) {
        autocomplete.iniciarsearch("usuarios", inputSearchId, inputHiddenId, autocomplete.usuario.success, autocomplete.usuario.selected, onSuccessComplete);
    },

    iniciarSearchUbigeoLocalidadConcatenados: function (inputSearchId, inputHiddenId, camposCargar, onSuccessComplete, inputAnotherFilter, prevalidacionAnio) {
        autocomplete.iniciarsearchCustomConcatenado("ubigeoLocalidadConcatenados", inputSearchId, inputHiddenId, camposCargar, autocomplete.ubigeoLocaldadConcatenado.success, autocomplete.ubigeoLocaldadConcatenado.selected, onSuccessComplete, inputAnotherFilter,prevalidacionAnio);
    },

    iniciarSearchUbigeoLocalidadFiltro: function (inputSearchId, inputHiddenId, camposCargar, onSuccessComplete, inputAnotherFilter, prevalidacionAnio) {
        autocomplete.iniciarsearchCustomConcatenado("ubigeoLocalidadFiltro", inputSearchId, inputHiddenId, camposCargar, autocomplete.ubigeoLocaldadConcatenado.success, autocomplete.ubigeoLocaldadConcatenado.selected, onSuccessComplete, inputAnotherFilter, prevalidacionAnio);
    },

    iniciarSearchUbigeDistrito: function (inputSearchId, inputHiddenId, camposCargar, onSuccessComplete, inputAnotherFilter) {
        autocomplete.iniciarsearchDistrito("ubigeoDistrito", inputSearchId, inputHiddenId, camposCargar, autocomplete.ubigeoLocaldadConcatenado.success, autocomplete.ubigeoLocaldadConcatenado.selectedDistrito, onSuccessComplete, inputAnotherFilter);
    },

    iniciarsearch: function (searchType, inputSearchId, inputHiddenId, functionSuccess, functionSelected, onSuccessComplete) {
        $("#" + inputSearchId).change(function () {
            var tx = $(this).val();
            if ($.trim(tx) != "" && !selectOk) {
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            } else if ($.trim(tx) == "") {
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            }
            selectOk = false;
        });

        $["ui"]["autocomplete"].prototype["_renderItem"] = function (ul, item) {
            return $("<li></li>")
                .data("item.autocomplete", item)
                .append($("<a></a>").html(item.customHtml))
                .appendTo(ul);
        };

        var maxItems = 10;
        var minLength = 3;

        //var url = helper.urlSearchEngine;
        var url = "http://localhost:1002/SearchEngine.svc/?callback?";

        $("#" + inputSearchId).autocomplete({
            source: function (request, response) {

                var dataSend = {};
                dataSend["maximoItems"] = maxItems;
                dataSend["searchType"] = searchType;
                dataSend["filtro"] = request.term;

                $.ajax({
                    url: url,
                    dataType: "jsonp",
                    data: dataSend,
                    highlight: false,
                    success: function (data) {
                        response($.map(data, function (item) {
                            return functionSuccess(item);
                        }));
                    }
                });
                selectOk = false;
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            },
            minLength: minLength,
            select: function (event, ui) {
                if (inputHiddenId != null) {
                    functionSelected(event, ui, inputHiddenId);
                    selectOk = true;
                }
                if (onSuccessComplete != undefined) onSuccessComplete();
            },
            open: function () {
            },
            close: function () {
            }
        });
    },

    iniciarsearchCustom: function (searchType, inputSearchId, inputHiddenId, functionSuccess, functionSelected, onSuccessComplete, inputAnotherFilter) {
        $("#" + inputSearchId).change(function () {
            //;
            var tx = $(this).val();
            if ($.trim(tx) != "" && !selectOk) {
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            } else if ($.trim(tx) == "") {
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            }
            selectOk = false;
        });

        $["ui"]["autocomplete"].prototype["_renderItem"] = function (ul, item) {
            return $("<li></li>")
                .data("item.autocomplete", item)
                .append($("<a></a>").html(item.customHtml))
                .appendTo(ul);
        };

        var maxItems = 10;
        var minLength = 3;

        //var url = helper.urlSearchEngine;
        var url = "http://localhost:1002/SearchEngine.svc/?callback?";

        $("#" + inputSearchId).autocomplete({
            source: function (request, response) {

                var dataSend = {};
                dataSend["maximoItems"] = maxItems;
                dataSend["searchType"] = searchType;
                dataSend["filtro"] = request.term;
                dataSend["anioUbigeo"] = inputAnotherFilter;

                $.ajax({
                    url: url,
                    dataType: "jsonp",
                    data: dataSend,
                    highlight: false,
                    success: function (data) {
                        response($.map(data, function (item) {
                            return functionSuccess(item);
                        }));
                    }
                });
                selectOk = false;
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            },
            minLength: minLength,
            select: function (event, ui) {
                if (inputHiddenId != null) {
                    functionSelected(event, ui, inputHiddenId);
                    selectOk = true;
                }
                if (onSuccessComplete != undefined) onSuccessComplete();
            },
            open: function () {
            },
            close: function () {
            }
        });
    },

    iniciarsearchCustomConcatenado: function (searchType, inputSearchId, inputHiddenId, intputNombreCamposMostrar, functionSuccess, functionSelected, onSuccessComplete, inputAnotherFilter,prevalidacionAnio) {
        $("#" + inputSearchId).change(function () {
            //;
            var tx = $(this).val();
            if ($.trim(tx) != "" && !selectOk) {
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            } else if ($.trim(tx) == "") {
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            }
            selectOk = false;
        });

        $["ui"]["autocomplete"].prototype["_renderItem"] = function (ul, item) {
            return $("<li></li>")
                .data("item.autocomplete", item)
                .append($("<a></a>").html(item.customHtml))
                .appendTo(ul);
        };

        var maxItems = 15;
        var minLength = 3;

        //var url = helper.urlSearchEngine;
        var url = "http://localhost:1002/SearchEngine.svc/?callback?";

        $("#" + inputSearchId).autocomplete({
            source: function (request, response) {
                //;
                var dataSend = {};
                dataSend["maximoItems"] = maxItems;
                dataSend["searchType"] = searchType;
                dataSend["filtro"] = request.term;
                dataSend["anioUbigeo"] = $("#" + inputAnotherFilter).val();

                if ($("#" + inputAnotherFilter).val() === "") {
                    var formContent = $(institucion.idFormEditor);
                    helperFunctions.refreshFielValidator(formContent, prevalidacionAnio);
                } else {
                    $.ajax({
                        url: url,
                        dataType: "jsonp",
                        data: dataSend,
                        highlight: false,
                        success: function (data) {
                            response($.map(data, function (item) {
                                return functionSuccess(item);
                            }));
                        }
                    });
                    selectOk = false;
                    if (inputHiddenId != null) $("#" + inputHiddenId).val("");
                }

               
            },
            minLength: minLength,
            select: function (event, ui) {
                //;

                if (inputHiddenId != null) {
                    functionSelected(event, ui, inputHiddenId, intputNombreCamposMostrar, inputSearchId);
                    selectOk = true;
                }
                return false;

            },
            open: function () {
            },
            close: function () {
            }
        });
    },
    iniciarsearchDistrito: function (searchType, inputSearchId, inputHiddenId, intputNombreCamposMostrar, functionSuccess, functionSelected, onSuccessComplete, inputAnotherFilter) {
        $("#" + inputSearchId).change(function () {
            //;
            var tx = $(this).val();
            if ($.trim(tx) != "" && !selectOk) {
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            } else if ($.trim(tx) == "") {
                if (inputHiddenId != null) $("#" + inputHiddenId).val("");
            }
            selectOk = false;
        });

        $["ui"]["autocomplete"].prototype["_renderItem"] = function (ul, item) {
            return $("<li></li>")
                .data("item.autocomplete", item)
                .append($("<a></a>").html(item.customHtml))
                .appendTo(ul);
        };

        var maxItems = 15;
        var minLength = 3;

        //var url = helper.urlSearchEngine;
        var url = "http://localhost:1002/SearchEngine.svc/?callback?";

        $("#" + inputSearchId).autocomplete({
            source: function (request, response) {
                //;
                var dataSend = {};
                dataSend["maximoItems"] = maxItems;
                dataSend["searchType"] = searchType;
                dataSend["filtro"] = request.term;
                dataSend["anioUbigeo"] = $("#" + inputAnotherFilter).val();

                if ($("#" + inputAnotherFilter).val() === "") {
                    var formContent = $(localidad.idFormEditor);
                    helperFunctions.refreshFielValidator(formContent, "Localidad.AnioUbigeo");
                } else {
                    $.ajax({
                        url: url,
                        dataType: "jsonp",
                        data: dataSend,
                        highlight: false,
                        success: function (data) {
                            response($.map(data, function (item) {
                                return functionSuccess(item);
                            }));
                        }
                    });
                    selectOk = false;
                    if (inputHiddenId != null) $("#" + inputHiddenId).val("");
                }
            },
            minLength: minLength,
            select: function (event, ui) {
                //;

                if (inputHiddenId != null) {
                    functionSelected(event, ui, inputHiddenId, intputNombreCamposMostrar, inputSearchId);
                    selectOk = true;
                }
                return false;

            },
            open: function () {
            },
            close: function () {
            }
        });
    },


    /************************************************************************************************************************
    PERSONA
    ************************************************************************************************************************/
    persona: {
        success: function (item) {
            return {
                label: item.nombre,
                value: item.nombre,
                id: item.id,
                customHtml: autocomplete.persona.construirFila(item)
            };
        },

        construirFila: function (item) {
            var fila = "";
            fila = fila.concat(
                "<table class='search-default'>",
                "<tr>",
                "<td>", item.nombre, "</td>",
                "</tr>",
                "</table>");
            return fila;

        },
        selected: function (event, ui, inputHiddenId) {
            var idPersona = ui.item ? ui.item.id : 0;
            $("#" + inputHiddenId).val(idPersona);
        }
    },

    /************************************************************************************************************************
    UBIGEO LOCALIDAD
    ************************************************************************************************************************/
    ubigeoLocaldad: {
        success: function (item) {
            return {
                label: item.nombre,
                value: item.nombre,
                id: item.id,
                tipo: item.tipo,
                customHtml: autocomplete.ubigeoLocaldad.construirFila(item)
            };
        },

        construirFila: function (item) {
            var fila = "";
            fila = fila.concat(
                "<table class='search-default'>",
                "<tr>",
                "<td style='color:red'>", item.tipo, "</td>",
                "<td>&nbsp;</td>",
                "<td>", item.nombre, "</td>",
                "</tr>",
                "</table>");
            return fila;

        },
        selected: function (event, ui, inputHiddenId) {
            //;
            var idUbigeo = ui.item ? ui.item.id : 0;
            $("#" + inputHiddenId).val(idUbigeo);
            $('#FiltroLocalidadUbigeo_Tipo').val(ui.item.tipo);
            console.log($('#FiltroLocalidadUbigeo_Tipo').val());
        }
    },


    ubigeoLocaldadConcatenado: {
        success: function (item) {

            return {
                label: item.nombre,
                value: item.nombre,
                id: item.id,
                customHtml: autocomplete.ubigeoLocaldad.construirFila(item)
            };
        },

        construirFila: function (item) {
            var fila = "";
            fila = fila.concat(
                "<table class='search-default'>",
                "<tr>",
                "<td style='color:red'>", item.tipo, "</td>",
                "<td>&nbsp;</td>",
                "<td>", item.nombre, "</td>",
                "</tr>",
                "</table>");
            return fila;

        },
        selected: function (event, ui, inputHiddenId, intputNombreCamposMostrar, inputSearchId) {
            //;
            var idLocalidad = ui.item ? ui.item.id : 0;
            if (idLocalidad != null) {
                var data = ui.item.value.split("-");
                //;

                $("#" + intputNombreCamposMostrar.departamento).val(data[2]);
                $("#" + intputNombreCamposMostrar.provincia).val(data[3]);
                $("#" + intputNombreCamposMostrar.distrito).val(data[4]);
                $("#" + intputNombreCamposMostrar.NombreLocalidad).val(data[5]);

                var cadena = $.isNumeric($("#" + inputSearchId).val());
                if (cadena) {
                    $("#" + inputSearchId).val(data[1]);
                } else {
                    $("#" + inputSearchId).val(data[5]);
                }
            }
            //;

            $("#" + inputHiddenId).val(idLocalidad);

        },
        selectedFiltro: function (event, ui, inputHiddenId, intputNombreCamposMostrar, inputSearchId) {
            //;
            var idLocalidad = ui.item ? ui.item.id : 0;
            if (idLocalidad != null) {
                var data = ui.item.value.split("-");

                var cadena = $.isNumeric($("#" + inputSearchId).val());
                if (cadena) {
                    $("#" + inputSearchId).val(data[1]);
                } else {
                    $("#" + inputSearchId).val(data[5]);
                }
            }
            //;
            $("#" + inputHiddenId).val(idLocalidad);

        },
        selectedDistrito: function (event, ui, inputHiddenId, intputNombreCamposMostrar, inputSearchId) {
            //;
            var idUbigeo = ui.item ? ui.item.id : 0;
            if (idUbigeo != null) {
                var data = ui.item.value.split("-");

                $("#" + intputNombreCamposMostrar.departamento).val(data[2]);
                $("#" + intputNombreCamposMostrar.provincia).val(data[3]);
                $("#" + intputNombreCamposMostrar.distrito).val(data[4]);

                var cadena = $.isNumeric($("#" + inputSearchId).val());
                if (cadena) {
                    $("#" + inputSearchId).val(data[1]);
                } else {
                    $("#" + inputSearchId).val(data[4]);
                }
            }
            //;

            $("#" + inputHiddenId).val(idUbigeo);

        }
    },

    /************************************************************************************************************************
    EQUIPO
    ************************************************************************************************************************/
    equipo: {
        success: function (item) {
            return {
                label: item.tipoEquipo,
                value: item.tipoEquipo,
                id: item.id,
                customHtml: autocomplete.equipo.construirFila(item)
            };
        },

        construirFila: function (item) {
            var fila = "";
            fila = fila.concat(
                "<table class='search-itemEquipo'>",
                "<tr>",
                "<td class='C01'>", item.tipoEquipo, "</td>",
                "<td class='C02'><div>", item.codigoPatrimonial, "</div></td>",
                "<td class='C03'><div>", item.tipoMarca, "</div></td>",
                "<td class='C04'><div>", item.tipoModelo, "</div></td>",
                "<td class='C05'><div>", item.serie, "</div></td>",
                "<td class='C06'><a onclick=guiaSalida.editor.asignarEquipo('", item.id, "');>Asignar</a></td>",
                "</tr>",
                "</table>");
            return fila;

        },
        selected: function (event, ui, inputHiddenId) {
            var idPersona = ui.item ? ui.item.id : 0;
            $("#" + inputHiddenId).val(idPersona);
        }
    },

    /************************************************************************************************************************
    USUARIO
    ************************************************************************************************************************/
    usuario: {
        success: function (item) {
            return {
                label: item.login,
                value: item.login,
                id: item.id,
                customHtml: autocomplete.usuario.construirFila(item)
            };
        },

        construirFila: function (item) {
            var fila = "";
            fila = fila.concat(
                "<table class='search-itemEquipo'>",
                "<tr>",
                "<td class='C01'>", item.login, "</td>",
                "<td class='C02'><div>", item.nombres, "</div></td>",
                "</tr>",
                "</table>");
            return fila;

        },
        selected: function (event, ui, inputHiddenId) {
            var idUsuario = ui.item ? ui.item.id : 0;
            $("#" + inputHiddenId).val(idUsuario);
        }
    },

    /*****************EJEMPLOS ****************************************************************************************/

    /************************************************************************************************************************
    PERSONAL
    ************************************************************************************************************************/
    personal: {
        success: function (item) {
            return {
                label: item.nombres,
                value: item.nombres,
                id: item.id,
                customHtml: autocomplete.personal.construirFila(item)
            };
        },

        construirFila: function (item) {
            var fila = "";
            fila = fila.concat(
                "<table class='search-default search-itemPersonal'>",
                "<tr>",
                "<td class='C01'>", item.nombres, "</td>",
                "<td class='C02'>", item.cargo, "</td>",
                "<td class='C04'>", item.area, "</td>",
                "</tr>",
                "</table>");
            return fila;
        },

        selected: function (event, ui, inputHiddenId) {
            //var nombre = ui.item ? ui.item.nombre : "";
            var idJerarquia = ui.item ? ui.item.id : 0;
            $("#" + inputHiddenId).val(idJerarquia);
        },
    },

    /************************************************************************************************************************
    CONCLUSIONES
    ************************************************************************************************************************/
    conclusiones: {
        success: function (item) {
            return {
                label: item.descripcion,
                value: item.descripcion,
                id: item.id,
                customHtml: autocomplete.conclusiones.construirFila(item)
            };
        },

        construirFila: function (item) {
            var fila = "";
            fila = fila.concat(
                "<table class='search-default search-itemConclusion'>",
                "<tr>",
                "<td class='C01'>", item.numero, "</td>",
                "<td class='C02'><div>", item.descripcion, "</div></td>",
                "<td class='C03'><a onclick=recomendacionAsignacion.asignarConclusion('", item.id, "');>Asignar</a></td>",
                "</tr>",
                "</table>");
            return fila;
        },

        selected: function (event, ui, inputHiddenId) {
            var idObservacion = ui.item ? ui.item.id : 0;
            $("#" + inputHiddenId).val(idObservacion);
        }
    },

    /************************************************************************************************************************
    GENERALES
    ************************************************************************************************************************/
    parametroConEspacios: function (parametro) {
        parametro = parametro.replace(' ', '&nbsp;');
        return parametro;
    }
};