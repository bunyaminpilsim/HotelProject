
    // Kategori dropdown'ı değiştiğinde çalışacak fonksiyon
    $('#categoryFilter').on('change', function () {

        var selectedCategory = $(this).val();
        var searchText = $('#searchText2').val();

        if (searchText && searchText.length >= 3) {
            if (selectedCategory === "all") {
                searchDescriptionFunction(searchText);
            }
            else {
                searchAllFilter(selectedCategory, searchText);
            }
        }
        else {
            searchCategoryFunction(selectedCategory);
        }
    });

$('#searchText2').on('input', function () {
    var searchText = $(this).val().toLowerCase(); // Kullanıcının girdiği metni küçük harfe çevir
    var selectedCategory = $('#categoryFilter').val();

    if (selectedCategory && selectedCategory != 'all') {
        if (searchText.length >= 3) {
            searchAllFilter(selectedCategory, searchText);
        }
    } else {
        searchDescriptionFunction(searchText);
    }  
});

function searchAllFilter(selectedCategory, searchText) {
    $('.room-item').each(function () {

        var roomCategory = $(this).data('category');
        var description = $(this).data('description');

        if (typeof description === 'string') {
            description = description.toLowerCase();
        } else {
            description = ''; // Dize değilse boş bir dize ile doldur
        }

        if (roomCategory === selectedCategory && description.includes(searchText)) {
            $(this).show();  // Eşleşen kategoriler gösterilir
        } else {
            $(this).hide();  // Diğer kategoriler gizlenir
        }
    });
}
function searchCategoryFunction(selectedCategory) {
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
}
function searchDescriptionFunction(searchText) {
    // En az 3 karakter girildi mi kontrolü
    if (searchText.length >= 3) {
        $('.room-item').each(function () {
            var description = $(this).data('description');

            // Eğer description bir dizeyse, küçük harfe çevir
            if (typeof description === 'string') {
                description = description.toLowerCase();
            } else {
                description = ''; // Dize değilse boş bir dize ile doldur
            }

            // Eğer description, searchText'i içeriyorsa göster, aksi takdirde gizle
            if (description.includes(searchText)) {
                $(this).show();  // Eşleşenleri göster
            } else {
                $(this).hide();  // Eşleşmeyenleri gizle
            }
        });
    } else {
        // 3 karakterden azsa tüm öğeleri göster
        $('.room-item').show();
    }
}

