// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Kategori dropdown'ı değiştiğinde çalışacak fonksiyon
    $('#categoryFilter').on('change', function () {

        var selectedCategory = $(this).val();

        if (selectedCategory === "all") {
            $('.room-item').show();
        } else {
            $('.room-item').each(function () {
                var roomCategory = $(this).data('category');
                if (roomCategory === selectedCategory) {
                    $(this).show();  // Eşleşen kategoriler gösterilir
                } else {
                    $(this).hide();  // Diğer kategoriler gizlenir
                }
            });
        }
    });

    $('#filterButton').click(function () {

        var searchText = $('#searchText').val();
        $('.room-item').each(function () {
            $(this).data();
            
            var description = $(this).data('description');

            if (description.search(searchText)) {
                $(this).show();  // Eşleşenleri göster
            } else {
                $(this).hide();  // Eşleşmeyenleri gizle
            }
        });
    });
});