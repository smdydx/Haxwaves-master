// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleReadMore() {
    const moreText = document.getElementById('more-text');
    const readMoreLink = document.getElementById('read-more');

    if (moreText.style.display === 'none') {
        moreText.style.display = 'inline';
        readMoreLink.textContent = 'Read Less';
    } else {
        moreText.style.display = 'none';
        readMoreLink.textContent = 'Read More';
    }
}
//document.addEventListener('DOMContentLoaded', function () {
//    var dropdown = document.querySelector('.nav-item.dropdown');
//    dropdown.addEventListener('mouseover', function () {
//       var menu = dropdown.querySelector('.dropdown-menu');
//        menu.classList.add('show');
//    });
//    dropdown.addEventListener('mouseout', function () {
//        var menu = dropdown.querySelector('.dropdown-menu');
//       menu.classList.remove('show');
//    });
//});<script>
// Function to update the active navigation link
