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