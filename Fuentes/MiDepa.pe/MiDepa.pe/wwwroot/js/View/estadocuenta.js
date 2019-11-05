var estadocuenta = {
    idFormGrid: "#articuloGridForm",
    idFormEditor: "#pagoEditorForm",
    updateTargetIdGrid: "#articulo-wrapper",

    grid: {

        load: function () {

            $("#CodigoCampania").change(function (e) {
                estadocuenta.grid.limpiarDatos();
                estadocuenta.grid.listarDatos();
            });

        },

        listarDatos: function () {

            var options = {
                onSuccessComplete: function (data) {
                    estadocuenta.grid.datosEstadoCuenta(data);
                    estadocuenta.grid.construirGraficoGastosMes(data);
                    estadocuenta.grid.construirRetrasoMes(data);
                    estadocuenta.grid.construirTablaGastosMes(data);
                    estadocuenta.grid.construirTablaPagosMes(data);
                }
            };

            var id = $("#CodigoCampania").val();
            baseGrid.ejecutar(route.estadocuenta, "ListarDatosEstadoCuenta", id, undefined, undefined, undefined, undefined, options.onSuccessComplete, "");
        },

        limpiarDatos: function (data) {
            $('#morris-donut-chart').empty();
            $('#canvas-preview').remove(); // this is my <canvas> element
            $('#preview').append('<canvas id="canvas-preview"><canvas>');
            $('#tbl_detesc tbody').empty();
            $('#tbl_pago tbody').empty();
        },

        datosEstadoCuenta: function (data) {

            var totalGastosMes, totalDeudaMes, totalPagadoMes, totalIntereses, totalPagado, totalEstadoCuenta;

            totalGastosMes = data.MontosEstadoCuenta.MontoPagar;
            totalIntereses = data.MontosEstadoCuenta.TotalInteres;
            totalEstadoCuenta = totalGastosMes + totalIntereses;

            totalEstadoCuenta = helperFunctions.formatearNumero(totalEstadoCuenta);
            totalPagado = helperFunctions.formatearNumero(data.MontosEstadoCuenta.MontoPagado);
            totalGastosMes = helperFunctions.formatearNumero(data.MontosEstadoCuenta.MontoPagar);
            totalDeudaMes = helperFunctions.formatearNumero(data.MontosEstadoCuenta.Saldo);

            $("#tit_det").html('Total Periodo S/. ' + totalGastosMes);
            $("#dias_ret").html('Tienes : ' + data.DiasRetraso + ' día(s) de retraso');
            $("#deu_mes").html('<small>Total Saldo Mes: </small> S/ ' + totalDeudaMes);
            $("#fec_emi").html('<small>Fecha Emisión: </small>' + data.MontosEstadoCuenta.FechaEmision);
            $("#fec_ven").html('<small>Fecha Vencimiento: </small>' + data.MontosEstadoCuenta.FechaVencimiento);
            $("#tot_est_cue").html('S/. ' + totalEstadoCuenta);
            $("#tot_pag").html('S/. ' + totalPagado);
            $("#hdn_edc").val(data.MontosEstadoCuenta.EstadoCuentaId);

        },

        construirGraficoGastosMes: function (data) {
            var programado = 0;
            var realizado = 0;
            var faltante = 0;

            var dataGrafico = [];
            var dataColor = [];

            $.each(data.ListaDetalleEstadoCuenta, function (key, value) {
                var item = { label: value.Concepto, value: value.MontoPagar }
                dataGrafico.push(item);
                dataColor.push(helperFunctions.coloresPorNumero(key));
            });

            Morris.Donut({
                element: 'morris-donut-chart',
                data: dataGrafico,
                resize: true,
                colors: dataColor
            });

            //$("#totProgAnio").html(helperFunctions.formatearNumero(programado) + " " + data.ProgramaActivo.UnidadMedida);
        },

        construirRetrasoMes: function (data) {
            var valorAceptado = 0;
            var valorModerado = 1;
            var valorPeligro = 2;
            var incioValorModerado = valorModerado;
            var incioValorPeligro = valorPeligro;

            var color = "";
            if (data.DiasRetraso <= valorAceptado) {
                color = "#7ace4c";
            } else if (data.DiasRetraso <= valorModerado) {
                color = "#fb4";
            } else {
                color = "#f33155";
            }

            var opts = {
                angle: 0, // The span of the gauge arc
                lineWidth: 0.44, // The line thickness
                radiusScale: 1, // Relative radius
                pointer: {
                    length: 0.6, // // Relative to gauge radius
                    strokeWidth: 0.035, // The thickness
                    color: '#000000' // Fill color
                },
                staticLabels: {
                    font: "15px sans-serif",
                    labels: [data.DiasRetraso],
                    fractionDigits: 0
                },
                staticZones: [
                    { strokeStyle: color, min: 0, max: 100 }, // Red from 100 to 130
                ],
                limitMax: false,     // If false, max value increases automatically if value > maxValue
                limitMin: false,     // If true, the min value of the gauge will be fixed
                colorStart: '#6FADCF',   // Colors
                colorStop: '#8FC0DA',    // just experiment with them
                strokeColor: '#E0E0E0',  // to see which ones work best for you
                generateGradient: true,
                highDpiSupport: true,     // High resolution support

            };
            var target = document.getElementById('canvas-preview'); // your canvas element
            var gauge = new Gauge(target).setOptions(opts); // create sexy gauge!
            gauge.maxValue = 100; // set max gauge value
            gauge.setMinValue(0);  // Prefer setter over gauge.minValue = 0
            gauge.animationSpeed = 32; // set animation speed (32 is default value)
            gauge.set(data.DiasRetraso); // set actual value
        },

        construirTablaGastosMes: function (data) {

            var _html = "";
            var _cont = 1;

            $.each(data.ListaDetalleEstadoCuenta, function (key, value) {
                var montoPagar = helperFunctions.formatearNumero(value.MontoPagar);
                _html += '<tr>';
                _html += '<td>' + _cont + '</td>';
                _html += '<td class="txt-oflo">' + value.Concepto + '</td>';
                _html += '<td><span class="text-info"> S/. ' + montoPagar + '</span></td>';
                _html += '</tr>';
                _cont++;
            });

            $("#tbl_detesc tbody").append(_html);

        },

        construirTablaPagosMes: function (data) {

            var _html = "";
            var _cont = 1;

            $.each(data.ListaPagosEstadoCuenta, function (key, value) {

                var monto = helperFunctions.formatearNumero(value.Monto);
                var estado = estadocuenta.grid.estadoPorCodigo(value.EstadoId);
                _html += '<tr>';
                if (value.EstadoId == 1) {
                    _html += '<td><a href="#" onclick="estadocuenta.editor.init(' + value.PagoId + ')">' + _cont + '</a> </td>';
                } else {
                    _html += '<td><a href="#" onclick="estadocuenta.editor.initRO(' + value.PagoId + ')">' + _cont + '</a> </td>';
                }
                _html += '<td class="txt-oflo">' + value.FechaPago + '</td>';
                _html += '<td>' + estado + '</td>';
                _html += '<td><span class="text-info"> S/. ' + monto + '</span></td>';
                if (value.EstadoId == 1) {
                    _html += '<td><button onclick="estadocuenta.grid.eliminarPago(' + value.PagoId + ')" class="btn btn-circle btn-danger text-white btn-xs" href="javascript:void(0)"><i class="ti-trash"></i></button></td>';
                } else {
                    _html += '<td></td>';
                }
                _html += '</tr>';
                _cont++;
            });

            _html += '<tr>';
            _html += '<td colspan="5">';
            _html += '<a id="lnk_pago" class="btn btn-rounded btn-danger btn-block p-10">AGREGAR PAGO</a>';
            _html += '</td>';
            _html += '</tr>';

            $("#tbl_pago tbody").append(_html);

            $("#lnk_pago").click(function (e) {
                estadocuenta.grid.editorPago();
            });
        },

        estadoPorCodigo: function (codigo) {

            var estado = "";

            switch (codigo) {
                case 1:
                    estado = '<span class="label label-info label-rouded">Pendiente</span>';
                    break;
                case 2:
                    estado = '<span class="label label-success label-rouded">Aprobado</span>';
                    break;
                case 3:
                    estado = '<span class="label label-danger label-rouded">Rechazado</span>';
                    break;
                default:
                    break;
            }

            return estado;
        },

        editorPago: function () {

            var id = $("#Pago_PagoId").val();
            estadocuenta.editor.init(id);
        },

        eliminarPago: function (id) {

            var options = {
                onSuccessComplete: function (data) {
                    estadocuenta.grid.limpiarDatos();
                    estadocuenta.grid.listarDatos();
                }
            };

            baseGrid.ejecutar(route.estadocuenta, "Eliminar", id, undefined, undefined, undefined, "¿Realmente desea eliminar este pago?", options.onSuccessComplete);

        }

    },

    editor: {

        init: function (id, per) {

            //if (per == "True" || per == undefined)
            //    visibleGrab = true;
            //else
            //    visibleGrab = false;

            var visibleGrab = true;

            var title = (id > 0) ? "MODIFICAR PAGO" : "AGREGAR PAGO";
            baseEditor.init(route.estadocuenta, id, title, dialog.normal, "#Pago_NroVoucher", undefined, undefined, "EditorPago", visibleGrab);
        },

        initRO: function (id) {
            baseEditor.init(route.pago, id, "VER PAGO", dialog.normal, "#Pago_NroVoucher", undefined, undefined, "EditorRO", false);
        },

        load: function () {
            var formContent = $(estadocuenta.idFormEditor);

            var estadoCuentaId = $("#hdn_edc").val();
            $("#Pago_EstadoCuentaId").val(estadoCuentaId);

            helperFunctions.formatoNumero(".input-align-right");

            estadocuenta.editor.validation(formContent);
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
                    "Pago.NroVoucher": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Pago.Monto": {
                        validators: {
                            notEmpty: {
                                message: 'Este campo es obligatorio'
                            }
                        }
                    },
                    "Pago.CuentaBancariaId": {
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

                    var id = $(estadocuenta.idFormEditor + " #Pago_PagoId").val();
                    if (id == "" || id == "0")
                        estadocuenta.editor.agregar();
                    else
                        estadocuenta.editor.modificar();
                });
        },

        agregar: function () {

            var formElement = document.getElementById("pagoEditorForm");
            var data = new FormData(formElement);
            var input1 = document.getElementById('Adjunto1');
            var input2 = document.getElementById('Adjunto2');
            var input3 = document.getElementById('Adjunto3');

            data.append('Adjunto1', input1.files[0]);
            data.append('Adjunto2', input2.files[0]);
            data.append('Adjunto3', input3.files[0]);

            var options = {
                onSuccessComplete: function (data) {
                    estadocuenta.grid.limpiarDatos();
                    estadocuenta.grid.listarDatos();
                }
            };

            var options = {
                route: route.estadocuenta,
                metodo: "Agregar",
                data: data,
                processData: false,
                contentType: false,
                messageSuccess: "Registro Satisfactorio",
                onSuccessComplete: options.onSuccessComplete,
                updateTargetId: undefined,
                idWrapperEditor: undefined,
                close: true
            };

            baseGrid.ejecutarAccion(options);
        },

        modificar: function () {

            var options = {
                onSuccessComplete: function (data) {
                    estadocuenta.grid.limpiarDatos();
                    estadocuenta.grid.listarDatos();
                }
            };

            baseGrid.ejecutar(route.estadocuenta, "Modificar", undefined, undefined, undefined, $(estadocuenta.idFormEditor).serialize(), undefined, options.onSuccessComplete, undefined, true);

        }
    },

}