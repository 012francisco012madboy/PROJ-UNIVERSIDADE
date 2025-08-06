function trocarTipo() {
    var select = document.getElementById('tipoSelect');
    var input = document.getElementById('textInput');
    var texto = document.getElementById('textLabel');

    var valor = select.value;

    if (valor === "1") {
        input.type = "number";
        input.placeholder = select.selectedOptions[0].text;
        texto.innerText = select.selectedOptions[0].text;
    }
    else if (valor === "2") {
        input.type = "text";
        input.placeholder = select.selectedOptions[0].text;
        texto.innerText = select.selectedOptions[0].text;
    }
}

function carregarMunicipios(idProvincia) {
    if (!idProvincia) return;

    fetch(`/Select/ListarMunicipios?idProvincia=${idProvincia}`)
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById("municipioSelect");
        select.innerHTML = '<option value="-1">-- Selecionar --</option>';

        data.forEach(each => {
            const option = document.createElement("option");
            option.value = each.municipioId;
            option.text = each.nome;
            select.appendChild(option);
        });
    });
}

function carregarCursosMedio(idAreaFormacao) {
    if (!idAreaFormacao) return;

    fetch(`/Select/ListarCursosMedio?idAreaFormacao=${idAreaFormacao}`)
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById("cursoMedioSelect");
        select.innerHTML = '<option value="-1">-- Selecionar --</option>';

        data.forEach(each => {
            const option = document.createElement("option");
            option.value = each.cursoMedioID;
            option.text = each.nome;
            select.appendChild(option);
        });
    });
}

function carregarFaculdades(idCampus) {
    if (!idCampus) return;

    fetch(`/Select/ListarFaculdades?idCampus=${idCampus}`)
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById("faculdadeSelect");
        select.innerHTML = '<option value="-1">-- Selecionar --</option>';

        data.forEach(each => {
            const option = document.createElement("option");
            option.value = each.faculdadeID;
            option.text = each.nome;
            select.appendChild(option);
        });
    });
}

function carregarCursosFaculdade(idFaculdade) {
    if (!idFaculdade) return;

    fetch(`/Select/ListarCursosFaculdade?idFaculdade=${idFaculdade}`)
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById("cursoSelect");
        select.innerHTML = '<option value="-1">-- Selecionar --</option>';

        data.forEach(each => {
            const option = document.createElement("option");
            option.value = each.cursoID;
            option.text = each.nome;
            select.appendChild(option);
        });
    });
}

function carregarBancos(idTipoPagamento) {
    const select = document.getElementById("bancoSelect");

    if (!idTipoPagamento || idTipoPagamento == "-1") {
        select.innerHTML = '<option value="-1">-- Selecionar --</option>';
    }
    else if (idTipoPagamento == "0") {
        select.innerHTML = '<option value="0">Todos bancos</option>';
    }
    else {
        fetch(`/Select/ListarBancos?idTipoPagamento=${idTipoPagamento}`)
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option value="-1">-- Selecionar --</option>';

            data.forEach(each => {
                const option = document.createElement("option");
                option.value = each.bancoID;
                option.text = each.nome;
                select.appendChild(option);
            });
        });
    }
}