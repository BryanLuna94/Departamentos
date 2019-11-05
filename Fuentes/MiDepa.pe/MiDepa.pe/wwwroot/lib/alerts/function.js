function alertSW_info(msg) {
    swal(msg);
};

function alertSW_warning(msg, titulo) {
    if (titulo == undefined) titulo = "¡Advertencia!"
    swal({
        title: titulo,
        text: msg,
        type: "warning"
    });
};

function alertSW_error(msg, titulo) {
    if (titulo == undefined) titulo = "¡Error!"
    swal({
        title: titulo,
        text: msg,
        type: "error"
    });
};

function alertSW_success(msg, titulo) {
    if (titulo == undefined) titulo = "¡Bien!"
    swal({
        title: titulo,
        text: msg,
        type: "success"
    });
};