var helperFunctions = {
    obtenerFormatoFecha: function () {
        return "dd/mm/yy";
    },

    obtenerFormatoFechaHora: function () {
        return "dd/mm/yy";
    },

    altoDisponible: function (borde) {
        if (borde == undefined) borde = 20;
        return $(window).height() - borde;
    },

    anchoDisponible: function () {
        return $(window).width - 20;
    },

    rellenarCerosIzquierda: function (num, digitos) {
        if (digitos == undefined) digitos = 2;
        var longitudNum = num.toString().length
        var resultado = num.toString();
        var ceros = "";
        if (longitudNum < digitos) {
            var cerosFaltantes = digitos - longitudNum;
            for (i = 0; i < cerosFaltantes; i++) ceros += '0'
            resultado = ceros + num;
        }
        return resultado;
    },

    ocultarInactivar: function (formContent, id_control) {
        var control = $(formContent).find(id_control);
        $(control).find(":input").prop("disabled", "disabled");
        $(control).hide();
    },

    mostrarActivar: function (formContent, id_control) {
        var control = $(formContent).find(id_control);
        $(control).show();
        $(control).find(":input").prop("disabled", "");
    },

    mostrarBase64: function (base64URL) {
        var win = window.open();
        win.document.write('<img src="' + base64URL + '" />');
    },

    desactivar: function (formContent, control_name, quitarValidacion) {
        var control = $(formContent).find("[name='" + control_name + "']");
        $(control).val("");
        if (quitarValidacion == true) helperFunctions.removeFielValidator(formContent, control_name);
        $(control).prop("disabled", "disabled");
    },

    activar: function (formContent, control_name, activarValidacion) {
        $(formContent).find("[name='" + control_name + "']").prop("disabled", "");

        if (activarValidacion == true) helperFunctions.addFielValidator(formContent, control_name);
    },

    __highlight: function (s, t) {
        var matcher = new RegExp("(" + $.ui.autocomplete.escapeRegex(t) + ")", "ig");
        return s.replace(matcher, "<strong>$1</strong>");
    },

    datepickerGrilla: function (formContent) {
        $(formContent).find(".date").each(function (index, value) {
            var divContainer = $(this);
            var inputName = $(divContainer).find("input").attr("name");
            var inputId = $(divContainer).find("input").attr("id");
            var inputIdJQ = "#" + inputId;
            $(inputIdJQ).attr("data-inputmask", "'alias': 'dd/mm/yyyy'");
            $(inputIdJQ).attr("data-mask", "");

            $(inputIdJQ).inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });

            //$(divContainer).datepicker({
            //    format: "dd/mm/yyyy",
            //    todayBtn: "linked",
            //    language: "es",
            //    autoclose: true
            //})
            //.on('changeDate', function (e) {
            //    //$(formContent).formValidation('revalidateField', inputName);
            //});
        });
    },

    datepicker: function (formContent) {
        $(formContent).find(".date").each(function (index, value) {
            var divContainer = $(this);
            var inputName = $(divContainer).find("input").attr("name");
            var inputId = $(divContainer).find("input").attr("id");
            var inputIdJQ = "#" + inputId;
            $(inputIdJQ).attr("data-inputmask", "'alias': 'dd/mm/yyyy'");
            $(inputIdJQ).attr("data-mask", "");

            $(inputIdJQ).inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });

            $(divContainer).datepicker({
                format: "dd/mm/yyyy",
                todayBtn: "linked",
                language: "es",
                autoclose: true
            })
                .on('changeDate', function (e) {
                    //$(formContent).formValidation('revalidateField', inputName);
                });
        });
    },

    asignarMascara: function (control, mascara) {
        $(control).inputmask("mask", { "mask": mascara });
    },

    datepickerXFilter: function (formContent) {
        $(formContent).find(".dateFilter").each(function (index, value) {
            var divContainer = $(this);
            var inputId = $(divContainer).find("input").attr("id");

            $("#" + inputId).datepicker({
                format: "dd/mm/yy",
                todayBtn: "linked",
                language: "es",
                autoclose: true
            });
        });
    },

    addFielValidator: function (formContent, control_name) {
        $(formContent).formValidation('addField', control_name);
        $(formContent).formValidation('revalidateField', control_name);
    },

    removeFielValidator: function (formContent, control_name) {
        $(formContent).formValidation('revalidateField', control_name);
        $(formContent).formValidation('removeField', control_name);
    },

    refreshFielValidator: function (formContent, control_name) {
        $(formContent).formValidation('revalidateField', control_name);
    },

    soloNumeros: function (e) {
        var code = e.which || e.keyCode, allowedKeys = [8, 9, 13, 27, 35, 36, 37, 38, 39, 46, 110, 190];

        if (allowedKeys.indexOf(code) > -1) {
            return;
        }

        if ((e.shiftKey || (code < 48 || code > 57)) && (code < 96 || code > 105)) {
            e.preventDefault();
        }
    },

    soloText: function (e) {
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
        especiales = "8-37-39-46";

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        if (letras.indexOf(tecla) == -1 && !tecla_especial) {
            return false;
        }
    },

    formatearNumero: function (numero, decimales) {
        if (decimales == undefined) {
            decimales = 2;
        }
        return numero.toFixed(decimales).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    },

    getTooltipFlot: function (label, x, y) {
        return label + ": " + helperFunctions.formatearNumero(y);
    },

    touchSpin: function (input) {
        //Bootstrap-TouchSpin
        $(input).TouchSpin({
            verticalbuttons: true,
            verticalupclass: 'ti-plus',
            verticaldownclass: 'ti-minus',
            buttondown_class: "btn btn-link",
            buttonup_class: "btn btn-link",
            min: 1900,
            max: 2900,
        });
    },

    touchSpinAnio: function (input) {
        //Bootstrap-TouchSpin
        $(input).TouchSpin({
            verticalbuttons: true,
            verticalupclass: 'ti-plus',
            verticaldownclass: 'ti-minus',
            buttondown_class: "btn btn-link",
            buttonup_class: "btn btn-link",
            min: 1900,
            max: 2900,
        });
    },

    formatoNumero: function (input) {

        $(input).on({
            "focus": function (event) {
                $(event.target).select();
            },
            "blur": function (event) {
                $(event.target).val(function (index, value) {
                    var valor = parseFloat(value.replace(/,/g, "")).toFixed(2);
                    return valor.replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ",");
                });
            }
        });

    },

    ordenarJson: function (data, prop, asc) {
        data = data.sort(function (a, b) {
            if (asc) {
                return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0);
            } else {
                return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
            }
        });

        return data;
    },

    generarGraficoBarras: function (typ, label, datakey, ds, divCanvas, onClick, staked, divConCanvas, responsive, alto, ancho, mainTainAspectRatio, barPercentage,formatearNumero, decimalesLabel) {

        var type2 = ""
        if (typ == "line") type2 = "linear";
        if (staked == undefined) staked = false;
        if (alto == undefined) alto = 120;
        if (divConCanvas == undefined) divConCanvas = '#contCanvas';
        if (responsive == undefined) responsive = true;
        if (mainTainAspectRatio == undefined) mainTainAspectRatio = true;
        if (barPercentage == undefined) barPercentage = 0.8;
        if (decimalesLabel == undefined) decimalesLabel = 2;
        if (formatearNumero == undefined) formatearNumero = true;
        
        $('#' + divCanvas).remove(); // this is my <canvas> element
        $(divConCanvas).append('<canvas id="' + divCanvas + '"><canvas>');

        var ctx = document.getElementById(divCanvas).getContext("2d");
        document.getElementById(divCanvas).height = alto;
        if (ancho != undefined) document.getElementById(divCanvas).width = ancho;
        var theChart;

        theChart = new Chart(ctx, {
            type: typ,
            data: {
                labels: label,
                datakeys: datakey,
                datasets: ds
            },
            options: {
                responsive: responsive,
                maintainAspectRatio: mainTainAspectRatio,
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        },
                        stacked: staked,
                    }],
                    xAxes: [{
                        barPercentage: barPercentage,
                        gridLines: {
                            color: "rgba(0, 0, 0, 0)",
                        }
                    }]
                },
                tooltips: {
                    mode: 'label',
                    label: 'mylabel',
                    callbacks: {
                        label: function (tooltipItem, data) {
                            if (formatearNumero) {
                                return data.datasets[tooltipItem.datasetIndex].label + ': ' + helperFunctions.formatearNumero(data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index], decimalesLabel);
                            } else {
                                return data.datasets[tooltipItem.datasetIndex].label + ': ' + data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                            }
                        }
                    },
                }
            }
        });

        document.getElementById(divCanvas).onclick = function (evt) {
            onClick(evt, theChart);
        }
    },

    marcaHijosMenu: function (bParCheck, sParId) {
        $('input[type=checkbox]').each(function () {
            if (this.value == sParId) {
                this.checked = bParCheck;
                helperFunctions.marcaHijosMenu(bParCheck, this.id);
            }
        });
    },

    marcaPadresMenu: function (bParCheck, sParId) {
        var bThisStatus = false;
        // Bucle para ver si tiene hijos marcados
        $('input[type=checkbox]').each(function () {
            if (this.value == sParId && this.checked)
                bThisStatus = true;
        });
        $('input[type=checkbox]').each(function () {
            // Si hay que marcar
            if (this.id == sParId && bParCheck) {
                this.checked = bParCheck;
                helperFunctions.marcaPadresMenu(bParCheck, this.value);
            }
            // Desmarcar solo los padres que no tengan hijos marcados
            //else if (this.id == sParId && !bParCheck && !bThisStatus) {
            //    this.checked = bParCheck;
            //    MarcaPadresMenu(bParCheck, this.value);
            //}
        });

    },

    getSesion: function (name) {

        var url = "";
        var valor = "";
        url = helperAjax.obtenerUrlAbsoluta("General/ObtenerSesion");

        $.ajax({
            url: url,
            async: false,
            //type: params.type,
            //encoding: params.encoding,
            data: { name : name },
            success: function (data) {
                valor = data;
                return valor;
            },
            error: function (jqXhr, textStatus, errorThrown) {
            }
        });

        return valor;

    },

    setSesion: function (name, value) {
        var url = "";
        url = helperAjax.obtenerUrlAbsoluta("General/CrearSesion");

        $.ajax({
            url: url,
            data: { name: name, value: value },
            success: function (data) {
            },
            error: function (jqXhr, textStatus, errorThrown) {
            }
        });
    },

    coloresPorNumero: function (num) {
        var color = "";

        switch (num) {
            case 0:
                color = "#41b3f9";
                break;
            case 1:
                color = "#7ace4c";
                break;
            case 2:
                color = "#fb4";
                break;
            case 3:
                color = "info";
                break;
            case 4:
                color = "primary";
                break;
            default:
                color = "";
        }

        return color;
    },
}