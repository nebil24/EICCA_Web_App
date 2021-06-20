// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function(){
    $(window).scroll(function() {
        if ($(this).scrollTop() > 100) {
          $('.navbar-bg').addClass('solid');
        } else {
          $('.navbar-bg').removeClass('solid');
        }
    });
});