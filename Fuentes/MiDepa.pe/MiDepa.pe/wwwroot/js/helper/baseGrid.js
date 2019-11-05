var baseGrid = {
    /*
    route: {                OBLIGATORIO
        area,               OBLIGATORIO
        controller,         OBLIGATORIO
        idTab               OBLIGATORIO
    },    
    idFormGrid,             OBLIGATORIO   
    idWrapperGrid,          OBLIGATORIO
    addFunction             OBLIGATORIO
    */
    init: function (route, idFormGrid, idWrapperGrid, addFunction) {
        var formGridContent = $(route.idTab + " " + idFormGrid);
        if (formGridContent.length === 0) {
            formGridContent = $(idFormGrid);
        }

        $(formGridContent).find(".btn-agregar").on("click", function (e) {
            addFunction();
        });

        $(formGridContent).find(".btn-limpiar").on("click", function (e) {
            baseGrid.refresh(route, idFormGrid);
        });

        $(formGridContent).find(".btn-search").on("click", function (e) {
            baseGrid.find(route, idFormGrid, undefined, idWrapperGrid, 1);
        });

        baseGrid.pagination(route, idFormGrid, undefined, idWrapperGrid);
    },

    /*
    route: {                OBLIGATORIO
        area,               OBLIGATORIO
        controller,         OBLIGATORIO
        idTab               OBLIGATORIO
    },    
    idFormGrid,             OBLIGATORIO   
    searcher: {             OPCIONAL        
        metodo                  OPCIONAL
        idWrapperGrid,          OBLIGATORIO
    }, 
    add: {                  OPCIONAL
        onOpen                  OBLIGATORIO
        data                    OPCIONAL
    },
    hover: {             OPCIONAL
        idTabla                 OBLIGATORIO
    },
    selected: {             OPCIONAL
        idTabla,                OBLIGATORIO
        indexGrid               OBLIGATORIO
    }
    */
    initCustom: function (options) {
        var formGridContent = $(options.route.idTab + " " + options.idFormGrid);
        if (formGridContent.length === 0) {
            formGridContent = $(options.idFormGrid);
        }

        if (options.add !== undefined) {
            $(formGridContent).find(".btn-add").on("click", function (e) {
                options.add.onOpen(options.add.data);
            });
        }

        if (options.searcher !== undefined) {
            $(formGridContent).find(".btn-find").on("click", function (e) {
                baseGrid.find(options.route, options.idFormGrid, options.searcher.metodo, options.searcher.idWrapperGrid, 1);
            });
        }

        baseGrid.pagination(options.route, options.idFormGrid, options.searcher.metodo, options.searcher.idWrapperGrid);

        if (options.hover !== undefined) {
            var idTabla1 = options.hover.idTabla;
            if (idTabla1 !== undefined) {
                $(idTabla1 + ' tbody tr').hover(function () {
                    $(this).toggleClass('row_mouseOver');
                });
            }
        }

        if (options.selected !== undefined) {
            var idTabla2 = options.selected.idTabla;
            var indexGrid = options.selected.indexGrid;
            if (idTabla2 !== undefined && indexGrid !== undefined) {
                //Obtenemnos el id seleccionado
                var rowSelectedId = helperConstantes.getRowSelected(indexGrid);
                //recorremos las filas y si esta el Id lo seleccionamos
                if (rowSelectedId !== undefined) {
                    $(idTabla2 + ' tbody tr').each(function () {
                        var itemId = $(this).find("input#itemId").val();
                        if (itemId === rowSelectedId) {
                            $(this).toggleClass('row_mouseSelected');
                        }
                    });
                }

                $(idTabla2 + ' tbody tr').click(function () {
                    $(idTabla2 + ' tbody tr.row_mouseSelected').removeClass("row_mouseSelected");
                    $(this).toggleClass('row_mouseSelected');
                    var itemSelectedId = $(this).find("input#itemId").val();
                    helperConstantes.setRowSelected(indexGrid, itemSelectedId);
                });
            }
        }

        var totalRegistros = $(formGridContent).find('#totalRegistroBandeja').val();
        $(formGridContent).find('#totRegistro').html(totalRegistros);
    },


    initActa: function (options) {
        var formGridContent = $(options.route.idTab + " " + options.idFormGrid);
        if (formGridContent.length === 0) {
            formGridContent = $(options.idFormGrid);
        }

        if (options.add !== undefined) {
            $(formGridContent).find(".btn-add").on("click", function (e) {
                options.add.onOpen(options.add.data);
            });
        }

        if (options.searcher !== undefined) {
            $(formGridContent).find(".btn-find").on("click", function (e) {
                baseGrid.find(options.route, options.idFormGrid, options.searcher.metodo, options.searcher.idWrapperGrid, 1);
            });
        }

        baseGrid.paginationActa(options.route, options.idFormGrid, options.searcher.metodo, options.searcher.idWrapperGrid);

        if (options.hover !== undefined) {
            var idTabla1 = options.hover.idTabla;
            if (idTabla1 !== undefined) {
                $(idTabla1 + ' tbody tr').hover(function () {
                    $(this).toggleClass('row_mouseOver');
                });
            }
        }

        if (options.selected !== undefined) {
            var idTabla2 = options.selected.idTabla;
            var indexGrid = options.selected.indexGrid;
            if (idTabla2 !== undefined && indexGrid !== undefined) {
                //Obtenemnos el id seleccionado
                var rowSelectedId = helperConstantes.getRowSelected(indexGrid);
                //recorremos las filas y si esta el Id lo seleccionamos
                if (rowSelectedId !== undefined) {
                    $(idTabla2 + ' tbody tr').each(function () {
                        var itemId = $(this).find("input#itemId").val();
                        if (itemId === rowSelectedId) {
                            $(this).toggleClass('row_mouseSelected');
                        }
                    });
                }

                $(idTabla2 + ' tbody tr').click(function () {
                    $(idTabla2 + ' tbody tr.row_mouseSelected').removeClass("row_mouseSelected");
                    $(this).toggleClass('row_mouseSelected');
                    var itemSelectedId = $(this).find("input#itemId").val();
                    helperConstantes.setRowSelected(indexGrid, itemSelectedId);
                });
            }
        }

        var totalRegistros = $(formGridContent).find('#totalRegistroBandeja').val();
        $(formGridContent).find('#totRegistro').html(totalRegistros);
    },


    find: function (route, idFormName, metodo, idWrapperGrid, index, id, dataAdicional, onSuccessAdicional) {
        var formContent = $(idFormName);
        if (index !== undefined) {
            $(formContent).find("#Index").val(index);
        }
        if (metodo === undefined) metodo = "Refrescar";
        var url = "";
        if (route.area === undefined) {
            url = route.controller + "/" + metodo + "/" + id;
        } else {
            url = route.area + "/" + route.controller + "/" + metodo + "/" + id;
        }
        if (route.idTab !== "") {
            idFormName = route.idTab + " " + idFormName;
        }

        var data = $(formContent).serialize();
        if (id !== undefined) {
            data = data + "&id=" + id;
        }
        if (dataAdicional !== undefined) {
            data = dataAdicional;
        }

        var params = {
            url: url,
            data: data,
            updateTargetId: idWrapperGrid,
            onSuccessComplete: onSuccessAdicional,
        };
        helperAjax.sendGet(params);
    },

    refresh: function (route, idFormName) {
        $(idFormName)[0].reset();
    },

    findActa: function (route, idFormName, metodo, idWrapperGrid, index) {
        var formContent = $(idFormName);
        if (index !== undefined) {
            $(formContent).find("#Index").val(index);
        }
        if (metodo === undefined) metodo = "RefrescarGridEstructura";
        var url = documentoSupervision.area + "/" + documentoSupervision.controller + "/" + metodo;
        if (route.idTab !== "") {
            idFormName = route.idTab + " " + idFormName;
        }

        var data = $(formContent).serialize();

        var params = {
            url: url,
            data: data,
            updateTargetId: idWrapperGrid
        };
        helperAjax.sendGet(params);
    },

    pagination: function (route, idFormName, metodo, idWrapperGrid) {
        var contentPagination = $(idFormName).find("ul.pagination");
        $(contentPagination).find("a").each(function (index, value) {
            $(this).attr("href", "#");

            $(this).on("click", function (e) {
                e.preventDefault();

                if ($(this).parent().attr("class") !== "disabled") {
                    ;
                    var index = $(this).html();
                    if (index === "«") {
                        index = parseInt($(idFormName).find("#Index").val()) - 1;
                    }
                    else if (index === "»") {
                        index = parseInt($(idFormName).find("#Index").val()) + 1;
                    }

                    baseGrid.find(route, idFormName, metodo, idWrapperGrid, index);
                }
            });
        });

    },

    paginationActa: function (route, idFormName, metodo, idWrapperGrid) {
        var contentPagination = $(idFormName).find("ul.pagination");
        $(contentPagination).find("a").each(function (index, value) {
            $(this).attr("href", "#");

            $(this).on("click", function (e) {
                e.preventDefault();

                if ($(this).parent().attr("class") !== "disabled") {
                    var index = $(this).html();
                    if (index === "«") {
                        index = parseInt($(idFormName).find("#Index").val()) - 1;
                    }
                    else if (index === "»") {
                        index = parseInt($(idFormName).find("#Index").val()) + 1;
                    }

                    baseGrid.findActa(route, idFormName, metodo, idWrapperGrid, index);




                }
            });
        });

    },

    headerUpdate: function (formContent, idRowFilter) {
        baseGrid.unirGridconFiltro(formContent, idRowFilter);
        helperGrid.headerArrow(formContent, idRowFilter);
    },

    unirGridconFiltro: function (formContent, idRowFilter) {
        $(formContent).find(".grid-head").before($(formContent).find(idRowFilter));
    },

    ejecutar: function (route, metodo, id, idFormGrid, updateTargetId, data, messageConfirmation, onSuccessComplete, messageSuccess, close, formatNumber, formCerrar, async) {
        var url = "";
        if (idFormGrid !== undefined) {
            if (route.area === undefined) {
                url = route.controller + "/" + metodo + "/";
            } else {
                url = route.area + "/" + route.controller + "/" + metodo + "/";
            }
        } else {
            if (route.area === undefined) {
                url = route.controller + "/" + metodo + "/" + id;
            } else {
                url = route.area + "/" + route.controller + "/" + metodo + "/" + id;
            }
        }

        if (formatNumber == undefined) {
            formatNumber = true;
        }

        $('input[type=text]').val(function () {
            if (!$(this).hasClass('minu')) {
                return this.value.toUpperCase();
            } else {
                return this.value;
            }
        })

        if (messageSuccess == undefined) {
            messageSuccess = "Registro actualizado satisfactoriamente";
        }

        var params = {
            url: url,
            messageConfirmation: messageConfirmation,
            onSuccessComplete: onSuccessComplete,
            messageSuccess: messageSuccess,
            updateTargetId: updateTargetId,
            close: close,
            formCerrar: formCerrar,
            async: async
        };

        if (idFormGrid !== undefined) {
            var dataGrid = $(idFormGrid).serialize();
            var concantenar;
            if (dataGrid === "") {
                concantenar = "";
            } else {
                concantenar = "&"
            }
            if (data === undefined)
                params.data = dataGrid + concantenar + "id=" + id;
            else
                params.data = dataGrid + concantenar + data;// decodeURIComponent($.param(data));
        } else if (data !== undefined) {
            params.data = data;
            if (formatNumber == true) params.data = params.data.replace(/%2C/g, '');
        }

        helperAjax.sendPost(params);
    },

    /*
    route: {                OBLIGATORIO
        area,               OBLIGATORIO
        controller,         OBLIGATORIO
        idTab               OBLIGATORIO
    },
    metodo:            OBLIGATORIO
    id:                OPCIONAL*
    data: {}           OPCIONAL*
    updateTargetId:    OPCIONAL
    idWrapperEditor:   OPCIONAL
    messageSuccess     OPCIONAL
    onSuccess          OPCIONAL   
    type               OPCIONAL, por defecto POST
    */
    ejecutarAccion: function (options) {
        //Mensaje
        if (options.messageSuccess === undefined) options.messageSuccess = "Registro actualizado satisfactoriamente";

        //URL
        var url = "";
        if (options.route.area === undefined) {
            url = options.route.controller + "/" + options.metodo;
        } else {
            url = options.route.area + "/" + options.route.controller + "/" + options.metodo;
        }
        if (options.id !== undefined) {
            url = url + "/" + options.id;
        }
        if (options.route.area === "") {
            url = options.route.controller + "/" + options.metodo;
        }

        //Partametros Ajax
        var params = {
            url: url,
            data: options.data,
            processData: options.processData,
            contentType: options.contentType,
            updateTargetId: options.updateTargetId,
            onSuccess: options.onSuccess,
            onSuccessComplete: options.onSuccessComplete,
            idWrapperEditor: options.idWrapperEditor,
            messageSuccess: options.messageSuccess,
            recargar: options.recargar,
            close: options.close
        };

        if (options.type === undefined)
            helperAjax.sendPost(params);
        else if (options.type === "POST") {
            helperAjax.sendPost(params);
        }
        else if (options.type === "GET") {
            helperAjax.sendGet(params);
        }
    },

    agregar: function (route, idFormEditor, idFormGrid, updateTargetId, close) {
        var url = "";
        if (route.area === undefined) {
            url = route.controller + "/agregar";
        } else {
            url = route.area + "/" + route.controller + "/agregar";
        }

        $('input[type=text]').val(function () {
            if (!$(this).hasClass('minu')) {
                return this.value.toUpperCase();
            } else {
                return this.value;
            }
        })

        var data = $(idFormEditor).serialize();
        if (idFormGrid !== undefined) {
            data = data + "&" + $(idFormGrid).serialize();
        }

        var params = {
            url: url,
            data: data,
            messageSuccess: "Registro actualizado satisfactoriamente",
            updateTargetId: updateTargetId,
            idWrapperEditor: idFormEditor,
            close: close
        };
        helperAjax.sendPost(params);
    },

    modificar: function (route, metodo, idFormEditor, idFormGrid, updateTargetId, close, dataAdicional, messageConfirmation) {
        if (metodo === undefined) {
            metodo = "modificar";
        }
        var url = "";
        if (route.area === undefined) {
            url = route.controller + "/" + metodo;
        } else {
            url = route.area + "/" + route.controller + "/" + metodo;
        }

        $('input[type=text]').val(function () {
            if (!$(this).hasClass('minu')) {
                return this.value.toUpperCase();
            } else {
                return this.value;
            }
        })

        var data = $(idFormEditor).serialize();
        if (idFormGrid !== undefined) {
            data = data + "&" + $(idFormGrid).serialize();
        }

        if (dataAdicional !== undefined) {
            //data = data + "&" + $.param(dataAdicional);
            data = dataAdicional;
        }

        var params = {
            url: url,
            data: data,
            messageConfirmation: messageConfirmation,
            messageSuccess: "Registro actualizado satisfactoriamente",
            updateTargetId: updateTargetId,
            idWrapperEditor: idFormEditor,
            close: close
        };
        helperAjax.sendPost(params);
    },

    eliminar: function (route, id, updateTargetId) {
        var url = "";
        if (idFormGrid !== undefined) {
            if (route.area === undefined) {
                url = route.controller + "/eliminar/";
            } else {
                url = route.area + "/" + route.controller + "/eliminar/";
            }
        } else {
            if (route.area === undefined) {
                url = route.controller + "/eliminar/" + id;
            } else {
                url = route.area + "/" + route.controller + "/eliminar/" + id;
            }
        }

        var params = {
            url: url,
            messageSuccess: "Registro actualizado satisfactoriamente",
            updateTargetId: updateTargetId
        };

        if (idFormGrid !== undefined) {
            var dataGrid = $(idFormGrid).serialize();
            params.data = dataGrid + "&id=" + id;
        }

        helperAjax.sendPost(params);
    },

    activar: function (route, id, idFormGrid, updateTargetId, data) {
        var url = "";
        if (idFormGrid !== undefined) {
            if (route.area === undefined) {
                url = route.controller + "/activar/";
            } else {
                url = route.area + "/" + route.controller + "/activar/";
            }
        } else {
            if (route.area === undefined) {
                url = route.controller + "/activar/" + id;
            } else {
                url = route.area + "/" + route.controller + "/activar/" + id;
            }
        }

        var params = {
            url: url,
            messageSuccess: "Registro actualizado satisfactoriamente",
            updateTargetId: updateTargetId
        };

        if (idFormGrid !== undefined) {
            var dataGrid = $(idFormGrid).serialize();
            if (data === undefined)
                params.data = dataGrid + "&id=" + id;
            else
                params.data = dataGrid + "&" + decodeURIComponent($.param(data));
        } else if (data !== undefined) {
            params.data = decodeURIComponent($.param(data));
        }

        helperAjax.sendPost(params);
    },

    desactivar: function (route, id, idFormGrid, updateTargetId, data) {
        var url = "";
        if (idFormGrid !== undefined) {
            if (route.area === undefined) {
                url = route.controller + "/desactivar/";
            } else {
                url = route.area + "/" + route.controller + "/desactivar/";
            }
        } else {
            if (route.area === undefined) {
                url = route.controller + "/desactivar/" + id;
            } else {
                url = route.area + "/" + route.controller + "/desactivar/" + id;
            }
        }

        var params = {
            url: url,
            messageSuccess: "Registro actualizado satisfactoriamente",
            updateTargetId: updateTargetId
        };

        if (idFormGrid !== undefined) {
            var dataGrid = $(idFormGrid).serialize();
            if (data === undefined)
                params.data = dataGrid + "&id=" + id;
            else
                params.data = dataGrid + "&" + decodeURIComponent($.param(data));
        } else if (data !== undefined) {
            params.data = decodeURIComponent($.param(data));
        }

        helperAjax.sendPost(params);
    },

    cleanFilter: function (sender) {
        var fila = $(sender).parent("th").parent("tr");
        $(fila).find(":input:not([type=hidden])").each(function () {
            ;
            if ($(this).is(':checkbox')) {
                $(this).prop("checked", false);
            } else {
                $(this).val('');
            }
        });

    },

    autocomplete: function (route, metodo, controlId, onSuccess, select, dataAdicional) {
        var controlId = "#" + controlId;
        var url = "";
        if (route.area === undefined) {
            url = route.controller + "/" + metodo + "/";
        } else {
            url = route.area + "/" + route.controller + "/" + metodo + "/";
        }

        url = helperAjax.obtenerUrlAbsoluta(url);

        $(controlId).autocomplete({
            highlight: true,
            source: function (request, response) {

                var strTerm = request.term;
                if (dataAdicional != undefined) {
                    strTerm = strTerm + "|" + dataAdicional
                }

                $.ajax({
                    url: url,
                    type: "POST",
                    dataType: "json",
                    data: { term: strTerm },
                    success: function (data) {
                        onSuccess(response, data);
                    }
                })
            },
            select: function (event, ui) {
                select(event, ui);
            },
            messages: {
                noResults: '',
                results: function (resultsCount) { }
            }
        });
    }
}