var programacion = {
    idFormGrid: "#programacionGridForm",
    idFormEditor: "#programacionEditorForm",
    idFormEditorDetalle: "#programacionEditorDetalleForm",
    idFormEditorArchivo: "#archivosForm",
    idFormEditorArticulo: "#articuloEditorForm",
    updateTargetIdGrid: "#programacion-wrapper",
    updateTargetIdGridDetalle: "#programacionDetalle-wrapper",
    updateTargetIdGridArchivo: "#archivos-wrapper",

    grid: {

        load: function () {

            var formContent = $(programacion.idFormGrid);
            helperFunctions.datepicker(formContent);

            $("#Filtro_Correlativo").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    baseGrid.find(route.programacion, programacion.idFormGrid, "Refrescar", programacion.updateTargetIdGrid);
                }
            });

            baseGrid.init(route.programacion, programacion.idFormGrid, programacion.updateTargetIdGrid, programacion.editor.init);
        },

        tabla: function () {
            $(".select-prog").click(function (e) {
                programacion.grid.seleccionarProg(this);
            });

            $(".select-arrib").click(function (e) {
                programacion.grid.seleccionarArribo(this);
            });
        },

        validarHora: function () {
            var resultado = "OK";
            var options = {
                onSuccessComplete: function (data) {
                    resultado = data;
                    return resultado;
                }
            };
            baseGrid.ejecutar(route.programacion, "ValidarHora", undefined, undefined, undefined, $(programacion.idFormGrid).serialize(), undefined, options.onSuccessComplete, "", undefined, undefined, undefined, false);
            return resultado;
        },

        quitarProgramacion: function (id) {
            baseGrid.ejecutar(route.programacion, "QuitarTripulacion", id, programacion.idFormGrid, programacion.updateTargetIdGrid, undefined, "¿Está seguro que desea quitar el bus y chofer de esta programación?");
        },

        seleccionarProg: function (fila) {

            var filaSeleccionadaArribo = $("#tblListaArribo").find(".success");
            var filaSeleccionadaItinerario = $("#tblListaItinerario").find(".success");
            var tipoAsignar = $("#hdnTipoReem").val();

            if (filaSeleccionadaArribo.length == 1) {
                var codigoProgramacion = $(fila).find(".cod-prog").val();
                if (codigoProgramacion == 0) return;
                $("#CodigoProgramacion").val(codigoProgramacion);
                var validaHora = programacion.grid.validarHora();
                if (validaHora == "OK") {
                    programacion.grid.asignarTripulacion();
                } else {
                    mensaje.satisfactorio("validaHora");
                }
                return;
            } else if (filaSeleccionadaArribo.length == 0) {
                if (filaSeleccionadaItinerario.length == 0) {
                    var codigoProgramacion = $(fila).find(".cod-prog").val();
                    if (codigoProgramacion == 0) return;
                    $(fila).addClass("success");
                    $("#CodigoProgramacionPadre").val(codigoProgramacion);
                    $("#Tipo").val(tipoAsignar);
                    mensaje.satisfactorio("Seleccione la fila que desea reemplazar");
                } else {
                    if ($(fila).hasClass("success")) {
                        $(fila).removeClass("success");
                        $("#CodigoProgramacionPadre").val("0");
                        $("#Tipo").val("");
                        mensaje.satisfactorio("Programación deseleccionada");
                    } else {
                        var codigoProgramacion = $(fila).find(".cod-prog").val();
                        if (codigoProgramacion == 0) return;
                        $("#CodigoProgramacion").val(codigoProgramacion);
                        var validaHora = programacion.grid.validarHora();
                        if (validaHora == "OK") {
                            programacion.grid.asignarTripulacion();
                        } else {
                            general.clave.init();
                        }

                    }
                }
            }
        },

        seleccionarArribo: function (fila) {
            var filaSeleccionadaArribo = $("#tblListaArribo").find(".success");
            var filaSeleccionadaItinerario = $("#tblListaItinerario").find(".success");
            var tipoReemplazar = $("#hdnTipoAsig").val();

            if (filaSeleccionadaItinerario.length > 0) {
                return;
            }

            if (filaSeleccionadaArribo.length == 0) {
                var codigoProgramacion = $(fila).find(".cod-prog").val();
                if (codigoProgramacion == 0) return;
                $("#CodigoProgramacionPadre").val(codigoProgramacion);
                $("#Tipo").val(tipoReemplazar);
                $(fila).addClass("success");
                mensaje.satisfactorio("Seleccione la programación a la que desea asignar");
            } else if (filaSeleccionadaArribo.length == 1) {
                if ($(fila).hasClass("success")) {
                    $(fila).removeClass("success");
                    $("#CodigoProgramacionPadre").val("0");
                    $("#Tipo").val("");
                    mensaje.satisfactorio("Arribo deseleccionado");
                }
            }
        },

        asignarTripulacion: function () {
            baseGrid.ejecutar(route.programacion, "AsignarTripulacion", undefined, programacion.idFormGrid, programacion.updateTargetIdGrid, $(programacion.idFormGrid).serialize(), "¿Está seguro que desea asignar esta programación?");
        },

        exportar: function () {
            var form = $(programacion.idFormGrid);
            var url = $("#hdnURLExportar").val();
            form.attr('action', url);
            form.submit();
        },

        paginarParcial: function () {
            $('#tblLista').DataTable({
                "paging": true,
                "lengthChange": false,
                "searching": false,
                "ordering": true,
                "order": [],
                "info": true,
            });
        },

        eliminar: function (id) {
            baseGrid.ejecutar(route.programacion, "eliminar", id, programacion.idFormGrid, programacion.updateTargetIdGrid, undefined, "¿Está seguro que desea eliminar este programacion?");
        }
    },

    editor: {

        init: function (id, tipo, form) {
            id = id + "|" + tipo + "|" + form;

            var options = {
                onSuccessComplete: function (data) {
                    window.location = data;
                }
            };
            baseGrid.ejecutar(route.programacion, "RedirectEditor", id, undefined, undefined, undefined, undefined, options.onSuccessComplete, "");
        },

        load: function () {
            var formContent = $(programacion.idFormEditor);
            var canal1 = $("#programacionExt_tiCodCan").val();
            helperFunctions.datepicker(formContent);

            $("#programacion_iCodPer").change(function (e) {
                programacion.editor.comboDirecciones();
            });

            $(".btn-imp").click(function (e) {
                programacion.editor.imprimirGuia();
            });

            $(".btn-cerrar").click(function (e) {
                programacion.editor.cerrar();
            });

            $(".btn-adjunto").click(function (e) {
                programacion.archivos.init();
            });

            $(".select2").select2();

            $(formContent).find(".btn-editor").click(function (e) {
                $("#hdnNuevoArt").val("1");
                var codigoStope = $(formContent).find("#programacion_iCodCabMov").val();
                if (codigoStope === "0") {
                    return;
                }

                programacion.editorDetalle.init(0);
            });

            programacion.editor.canal(1, canal1);

            var options = {
                onSuccessComplete: function (response, data) {
                    response($.map(data, function (item) {
                        return { label: item.Descripcion, value: item.Descripcion, captura: item.Codigo };
                    }))
                },
                select: function (event, ui) {
                    var codigo = ui.item.captura;
                    $("#programacionExt_iCodPer").val(codigo);
                }
            };
            baseGrid.autocomplete(route.persona, "ListaPersonas_Auto", "programacionDto_PersonaExt", options.onSuccessComplete, options.select);

            $("#programacionDto_PersonaExt").keydown(function (e) {
                if (e.keyCode == 8) {
                    $("#programacionExt_iCodPer").val("");
                }
            });

            programacion.editor.comboDirecciones();
            programacion.editor.validation(formContent);
        },

        cerrar: function () {
            var id = $("#programacion_iCodCabMov").val();

            var options = {
                onSuccessComplete: function (data) {
                    window.location = data;
                }
            };

            baseGrid.ejecutar(route.programacion, "cerrar", id, programacion.idFormGrid, programacion.updateTargetIdGrid, undefined, "¿Está seguro que desea cerrar este programacion?", options.onSuccessComplete);
        },

        paginarParcial: function () {
            $('#tblListaDetalle').DataTable({
                "paging": true,
                "lengthChange": false,
                "searching": false,
                "ordering": true,
                "order": [],
                "info": true,
            });
        },

        imprimirGuia: function () {
            var id = $("#programacion_iCodCabMov").val();
            var url = $("#hdnURLImprimirGuia").val();

            if (id === "0") {
                mensaje.advertencia("Primero debe generar una guía de remisión");
                return;
            }

            window.open(url.toString().replace('__id__', id), '_blank')
        },


        canal: function (tipo, canal) {
            $("#cn" + tipo).removeClass("text-success");
            $("#cn" + tipo).removeClass("text-warning");
            $("#cn" + tipo).removeClass("text-danger");

            if (canal == 1) {
                $("#spcn" + tipo).text("Verde");
                $("#cn" + tipo).addClass("text-success");
            } else if (canal == 2) {
                $("#spcn" + tipo).text("Ambar");
                $("#cn" + tipo).addClass("text-warning");
            } else if (canal == 3) {
                $("#spcn" + tipo).text("Rojo");
                $("#cn" + tipo).addClass("text-danger");
            } else {
                $("#spcn" + tipo).text("Ninguno");
            }

            if (tipo == 1) {
                $("#programacionExt_tiCodCan").val(canal);
            } else if (tipo == 2) {
                $("#programacionExt_tiCodCanAct").val(canal);
            }
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    "programacion.tiCodTipMov": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "programacion.siCodTipDoc": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "programacion.vNumeroDoc": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "programacion.FechaRecepcion": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "programacion.HoraRecepcion": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "programacion.Persona": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    }
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    var id = $(programacion.idFormEditor + " #programacion_iCodCabMov").val();
                    if (id == "" || id == "0")
                        programacion.editor.agregar();
                    else
                        programacion.editor.modificar();
                });
        },

        agregar: function () {

            var persona = $("#programacion_iCodPer").val();

            if (persona == "0" || persona === "") {
                mensaje.advertencia("Debe seleccionar una empresa de la lista");
                return;
            }

            var options = {
                onSuccessComplete: function (data) {
                    $("#programacion_iCodCabMov").val(data.iCodCabMov);
                    $("#programacion_vCorrelativo").val(data.vCorrelativo);

                    var hdn = $("#hdnNuevoArt").val();
                    if (hdn === "1") {
                        programacion.editorDetalle.init(0);
                        $("#hdnNuevoArt").val("0");
                    }

                    $(".div-cerrar").show();

                }
            };
            baseGrid.ejecutar(route.programacion, "agregar", undefined, undefined, undefined, $(programacion.idFormEditor).serialize(), undefined, options.onSuccessComplete, "Registro actualizado satisfactoriamente");
        },

        comboDirecciones: function () {

            var id = $("#programacion_iCodPer").val();

            var options = {
                onSuccessComplete: function (data) {
                    $("#div-dire").html(data);
                }
            };

            baseGrid.ejecutar(route.programacion, "ListarDireccionesPersona", id, undefined, undefined, undefined, undefined, options.onSuccessComplete, "");
        },

        modificar: function () {

            var persona = $("#programacion_iCodPer").val();

            if (persona == "0" || persona === "") {
                mensaje.advertencia("Debe seleccionar una empresa de la lista");
                return;
            }

            var options = {
                onSuccessComplete: function (data) {

                }
            };
            baseGrid.ejecutar(route.programacion, "modificar", undefined, undefined, undefined, $(programacion.idFormEditor).serialize(), undefined, options.onSuccessComplete, "Registro actualizado satisfactoriamente");
        },

        eliminar: function (id) {
            baseGrid.ejecutar(route.programacion, "eliminardetalle", id, programacion.idFormEditorDetalle, programacion.updateTargetIdGridDetalle, undefined, "¿Está seguro que desea eliminar este programacion?");
        }
    },

    editorDetalle: {

        init: function (id, per) {

            if (per == "True" || per == undefined)
                visibleGrab = true;
            else
                visibleGrab = false;

            var title = (id > 0) ? "MODIFICAR PRODUCTO" : "AGREGAR PRODUCTO";

            var idMovCab = $("#programacion_iCodCabMov").val();

            id = idMovCab + "|" + id;

            baseEditor.init(route.programacion, id, title, dialog.normal, "#programacionDetalleDto_Articulo", undefined, undefined, "EditorDetalle", visibleGrab);
        },

    },

    editorDetalleIng: {

        load: function () {
            var formContent = $(programacion.idFormEditorDetalle);

            var options = {
                onSuccessComplete: function (response, data) {
                    response($.map(data, function (item) {
                        return { label: item.Descripcion, value: item.Descripcion, captura: item.Codigo };
                    }))
                },
                select: function (event, ui) {
                    var codigo = ui.item.captura;
                    $("#programacionDetalle_iCodArt").val(codigo);
                }
            };
            baseGrid.autocomplete(route.articulo, "ListaArticulos_Auto", "programacionDetalleDto_Articulo", options.onSuccessComplete, options.select);

            $("#programacionDetalleDto_Articulo").keydown(function (e) {
                if (e.keyCode == 8) {
                    $("#programacionDetalle_iCodArt").val("");
                }
            });

            $("#Stock_siCodAlm").change(function (e) {
                programacion.editorDetalleIng.comboPisos();
            });

            $("#Piso").change(function (e) {
                programacion.editorDetalleIng.comboRacks();
            });

            $("#Rack").change(function (e) {
                programacion.editorDetalleIng.comboUbicacion();
            });

            helperFunctions.formatoNumero(".input-align-right");

            programacion.editorDetalleIng.validation(formContent);
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    "programacionDetalleDto.Articulo": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "programacionDetalle.vSerie": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Stock.siCodAlm": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "DetalleStock.iCodEstArt": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "DetalleStock.dCostoIngreso": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "DetalleStock.dPesoKg": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    }
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    var id = $(programacion.idFormEditorDetalle + " #programacionDetalle_iCodDetMov").val();
                    if (id == "" || id == "0")
                        programacion.editorDetalleIng.agregar();
                    else
                        programacion.editorDetalleIng.modificar();
                });
        },

        comboPisos: function () {

            var id = $("#Stock_siCodAlm").val();

            var options = {
                onSuccessComplete: function (data) {
                    $("#div-pisos").html(data);

                    $("#Piso").change(function (e) {
                        programacion.editorDetalleIng.comboRacks();
                    });
                }
            };

            baseGrid.ejecutar(route.programacion, "ListarUbicacionesPisos", id, undefined, undefined, undefined, undefined, options.onSuccessComplete, "");
        },

        comboRacks: function () {

            var id = $("#Piso").val();
            var idAlm = $("#Stock_siCodAlm").val();
            id = idAlm + "|" + id;

            var options = {
                onSuccessComplete: function (data) {
                    $("#div-racks").html(data);

                    $("#Rack").change(function (e) {
                        programacion.editorDetalleIng.comboUbicacion();
                    });
                }
            };

            baseGrid.ejecutar(route.programacion, "ListarUbicacionesRacks", id, undefined, undefined, undefined, undefined, options.onSuccessComplete, "");
        },

        comboUbicacion: function () {

            var id = $("#Rack").val();
            var idAlm = $("#Stock_siCodAlm").val();
            var idPiso = $("#Piso").val();

            id = idAlm + "|" + idPiso + "|" + id;

            var options = {
                onSuccessComplete: function (data) {
                    $("#div-ubic").html(data);
                }
            };

            baseGrid.ejecutar(route.programacion, "ListarUbicacionesPorRacks", id, undefined, undefined, undefined, undefined, options.onSuccessComplete, "");
        },

        agregar: function () {

            var articulo = $("#programacionDetalle_iCodArt").val();
            var ubicacion = $("#DetalleStock_iCodUbi").val();

            if (articulo == "0" || articulo === "") {
                mensaje.advertencia("Debe seleccionar un producto de la lista");
                return;
            }

            if (ubicacion == "0" || ubicacion === "") {
                mensaje.advertencia("Debe seleccionar la ubicación donde almacenará el producto");
                return;
            }

            baseGrid.modificar(route.programacion, "agregarDetalle", programacion.idFormEditorDetalle, undefined, programacion.updateTargetIdGridDetalle);
        },

        modificar: function () {

            var articulo = $("#programacionDetalle_iCodArt").val();
            var ubicacion = $("#DetalleStock_iCodUbi").val();

            if (articulo == "0" || articulo === "") {
                mensaje.advertencia("Debe seleccionar un producto de la lista");
                return;
            }

            if (ubicacion == "0" || ubicacion === "") {
                mensaje.advertencia("Debe seleccionar la ubicación donde almacenará el producto");
                return;
            }

            baseGrid.modificar(route.programacion, "ActualizarDetalle", programacion.idFormEditorDetalle, undefined, programacion.updateTargetIdGridDetalle);
        }
    },

    editorDetalleSal: {

        load: function () {
            var formContent = $(programacion.idFormEditorDetalle);

            var options = {
                onSuccessComplete: function (response, data) {
                    response($.map(data, function (item) {
                        return { label: item.Descripcion, value: item.Descripcion, captura: item.Codigo };
                    }))
                },
                select: function (event, ui) {
                    var codigo = ui.item.captura;
                    $("#programacionDetalle_iCodDetMovIng").val(codigo);
                    programacion.editorDetalleSal.obtenerDatosMovDetIng(codigo);
                }
            };
            baseGrid.autocomplete(route.programacion, "ListaArticulosParaSalida_Auto", "programacionDetalleDto_Articulo", options.onSuccessComplete, options.select);

            $("#programacionDetalleDto_Articulo").keydown(function (e) {
                if (e.keyCode == 8) {
                    $("#programacionDetalle_iCodDetMovIng").val("");
                    $("#programacionDetalle_vSerie").val("");
                    $("#programacionDetalleDto_Almacen").val("");
                    $("#programacionDetalleDto_Ubicacion").val("");
                    $("#programacionDetalleDto_EstadoArticulo").val("");
                    $("#programacionDetalleDto_CostoIngreso").val("");
                }
            });

            programacion.editorDetalleSal.validation(formContent);
        },

        obtenerDatosMovDetIng: function (id) {

            var options = {
                onSuccessComplete: function (data) {
                    $("#programacionDetalle_vSerie").val(data.Serie);
                    $("#programacionDetalleDto_Almacen").val(data.Almacen);
                    $("#programacionDetalleDto_Ubicacion").val(data.Ubicacion);
                    $("#programacionDetalleDto_EstadoArticulo").val(data.EstadoArticulo);
                    $("#programacionDetalleDto_CostoIngreso").val(data.CostoIngreso);
                }
            };
            baseGrid.ejecutar(route.programacion, "ObtenerDetalleprogramacionParaSalida", id, undefined, undefined, undefined, undefined, options.onSuccessComplete, "");

        },

        validation: function (formContent) {
            $(formContent).formValidation({
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    "programacionDetalleDto.Articulo": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    }
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    var id = $(programacion.idFormEditorDetalle + " #programacionDetalle_iCodDetMov").val();
                    if (id == "" || id == "0")
                        programacion.editorDetalleSal.agregar();
                    else
                        programacion.editorDetalleSal.modificar();
                });
        },

        agregar: function () {

            var articulo = $("#programacionDetalle_iCodDetMovIng").val();

            if (articulo == "0" || articulo === "") {
                mensaje.advertencia("Debe seleccionar un producto de la lista");
                return;
            }

            baseGrid.modificar(route.programacion, "agregarDetalle", programacion.idFormEditorDetalle, undefined, programacion.updateTargetIdGridDetalle);
        },

        modificar: function () {

            var articulo = $("#programacionDetalle_iCodDetMovIng").val();

            if (articulo == "0" || articulo === "") {
                mensaje.advertencia("Debe seleccionar un producto de la lista");
                return;
            }

            baseGrid.modificar(route.programacion, "ActualizarDetalle", programacion.idFormEditorDetalle, undefined, programacion.updateTargetIdGridDetalle);
        }
    },

    archivos: {

        init: function () {

            var title = "ARCHIVOS ADJUNTOS";
            var id = $("#programacion_iCodCabMov").val();

            if (id === "0") {
                mensaje.advertencia("Primero debe generar un programacion para agregar archivos, presione el botón guardar")
                return;
            }

            baseEditor.init(route.programacion, id, title, dialog.normal, undefined, undefined, undefined, "EditorArchivosCab", false);

        },

        load: function () {
            var formContent = $(programacion.idFormEditorArchivo);
            programacion.archivos.validation(formContent);
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    "Descripcion": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Archivo": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    programacion.archivos.agregarArchivo();
                });
        },

        agregarArchivo: function () {

            var formElement = document.getElementById("archivosForm");
            var data = new FormData(formElement);
            var input = document.getElementById('Archivo');

            data.append('Archivo', input.files[0]);

            var options = {
                onSuccessComplete: function (data) {
                    $("#Descripcion").val("");
                    $(programacion.updateTargetIdGridArchivo).html(data);
                    $(programacion.idFormEditorArchivo).data('formValidation').resetForm($(programacion.idFormEditorArchivo));
                }
            };

            var options = {
                route: route.programacion,
                metodo: "AgregarArchivoCab",
                data: data,
                processData: false,
                contentType: false,
                messageSuccess: "Registro Satisfactorio",
                updateTargetId: undefined,
                idWrapperEditor: undefined,
                onSuccessComplete: options.onSuccessComplete,
                close: false
            };

            baseGrid.ejecutarAccion(options);
        },

        eliminarArchivo: function (id) {

            var options = {
                onSuccessComplete: function (data) {
                    $(programacion.updateTargetIdGridArchivo).html(data);
                }
            };
            baseGrid.ejecutar(route.programacion, "EliminarArchivoCab", id, undefined, undefined, undefined, "¿Está seguro que desea eliminar este archivo?", options.onSuccessComplete);
        }

    },

    archivosDet: {

        init: function (id) {

            var title = "ARCHIVOS ADJUNTOS";
            baseEditor.init(route.programacion, id, title, dialog.normal, undefined, undefined, undefined, "EditorArchivosDet", false);

        },

        load: function () {
            var formContent = $(programacion.idFormEditorArchivo);
            programacion.archivosDet.validation(formContent);
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    "Descripcion": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Archivo": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    programacion.archivosDet.agregarArchivo();
                });
        },

        agregarArchivo: function () {

            var formElement = document.getElementById("archivosForm");
            var data = new FormData(formElement);
            var input = document.getElementById('Archivo');

            data.append('Archivo', input.files[0]);

            var options = {
                onSuccessComplete: function (data) {
                    $("#Descripcion").val("");
                    $(programacion.updateTargetIdGridArchivo).html(data);
                    $(programacion.idFormEditorArchivo).data('formValidation').resetForm($(programacion.idFormEditorArchivo));
                }
            };

            var options = {
                route: route.programacion,
                metodo: "AgregarArchivoDet",
                data: data,
                processData: false,
                contentType: false,
                messageSuccess: "Registro Satisfactorio",
                updateTargetId: undefined,
                idWrapperEditor: undefined,
                onSuccessComplete: options.onSuccessComplete,
                close: false
            };

            baseGrid.ejecutarAccion(options);
        },

        eliminarArchivo: function (id) {

            var options = {
                onSuccessComplete: function (data) {
                    $(programacion.updateTargetIdGridArchivo).html(data);
                }
            };
            baseGrid.ejecutar(route.programacion, "EliminarArchivoDet", id, undefined, undefined, undefined, "¿Está seguro que desea eliminar este archivo?", options.onSuccessComplete);
        }

    },

    articulo: {

        init: function () {

            var title = "AGREGAR ARTICULO";
            baseEditor.init(route.programacion, 0, title, dialog.normal, "#Articulo_vDescripcion", undefined, undefined, "editorarticulo");
        },

        load: function () {
            var formContent = $(programacion.idFormEditorArticulo);

            programacion.articulo.validation(formContent);
        },

        validation: function (formContent) {
            $(formContent).formValidation({
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    "Articulo.vDescripcion": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Articulo.vCodigoOriginal": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Articulo.siCodUMed": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Articulo.iCodMarca": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                }
            })
                .on('success.form.fv', function (e) {
                    e.preventDefault();

                    programacion.articulo.agregar();
                });
        },

        agregar: function () {

            var options = {
                onSuccessComplete: function (data) {
                    $("#programacionDetalle_iCodArt").val(data.iCodArt);
                    $("#programacionDetalleDto_Articulo").val(data.vCodigoOriginal + " - " + data.vDescripcion);
                    $(programacion.idFormEditorDetalle).data('formValidation').resetField($('#programacionDetalleDto_Articulo'));
                }
            };
            baseGrid.ejecutar(route.programacion, "agregarArticulo", undefined, programacion.idFormEditorArticulo, programacion.idFormEditorArticulo, $(programacion.idFormEditorArticulo).serialize(), undefined, options.onSuccessComplete, undefined, true, undefined, "AGREGAR ARTICULO");
        },

    },
}
