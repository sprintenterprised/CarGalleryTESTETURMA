// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function toggleDetalhes(id) {
    var detalhesCarro = document.getElementById('_CardCarros' + id);
    if (detalhesCarro.style.display === 'none') {
        detalhesCarro.style.display = 'block';
    } else {
        detalhesCarro.style.display = 'none';
    }
}
