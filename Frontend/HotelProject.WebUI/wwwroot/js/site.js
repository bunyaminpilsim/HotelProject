//function applyFilters() {
//    var selectedCategory = $('#categoryFilter').val();
//    var searchText = $('#searchText2').val().toLowerCase();

//    if (searchText && searchText.length >= 3) {
//        filterByCategoryAndDescription(selectedCategory, searchText);
//    } else {
//        filterByCategoryOnly(selectedCategory);
//    }
//}
//function filterByCategoryOnly(selectedCategory) {
//    if (selectedCategory === "all") {
//        $('.room-item').show();
//    } else {
//        $('.room-item').each(function () {
//            var roomCategory = $(this).data('category');
//            if (roomCategory == selectedCategory) {
//                $(this).show();
//            } else {
//                $(this).hide();
//            }        });
//    }
//}

//function filterByCategoryAndDescription(selectedCategory, searchText) {
//    $('.room-item').each(function () {
//        var roomCategory = $(this).data('category');
//        var description = ($(this).data('description') || '');

//        if (typeof description === 'string') {
//            description = description.toLowerCase();
//        } else {
//            description = ''; // Dize değilse boş bir dize ile doldur
//        }

//        var categoryMatch = (selectedCategory === "all" || roomCategory === selectedCategory);
//        var descriptionMatch = description.includes(searchText);

//        if (categoryMatch && descriptionMatch) {
//            $(this).show();  
//        } else {
//            $(this).hide(); 
//        }
//    });
//}

//$('#categoryFilter').on('change', applyFilters);
//$('#searchText2').on('input', applyFilters);


$('#categoryFilter, #searchText2').on('change keyup', function () {
    applyFilters();
});

function applyFilters() {
    var categoryName = $('#categoryFilter').val();

    var description = $('#searchText2').val();

            if (typeof description === 'string') {
                description = description.toLowerCase();
            } else {
                description = ''; // Dize değilse boş bir dize ile doldur
    }


    const url = `/Room/FilterRooms?categoryName=${categoryName}&description=${description}`;
    $.ajax({
        url: url, 
        type: 'GET',
        success: function (data) {
            updateRoomList(data)
        },  
        error: function (xhr, status, error) {
            console.error('Hata:', error);
        }
    });
}

function updateRoomList(data) {
    const roomList = $('#roomList');
    roomList.empty();

    data.forEach(item => {
        const roomItem = `
        <div class="col-lg-4 col-md-6 wow fadeInUp room-item" data-category="${ item.categoryName}" data-description="${item.description}" data-wow-delay="0.1s">
            <div class="shadow rounded overflow-hidden">
                <div class="position-relative">
                    <img class="img-fluid" src="${ item.roomCoverImage}" alt="">
            <small class="position-absolute start-0 top-100 translate-middle-y bg-primary text-white rounded py-1 px-3 ms-4" > ${ item.price } ₺/Gece</small>
                </div>
                <div class="p-4 mt-2">
                    <div class="d-flex justify-content-between mb-3">
                        <h5 class="mb-0">${ item.title}</h5>
                        <div class="ps-2">
                            <small class="fa fa-star text-primary"></small>
                            <small class="fa fa-star text-primary"></small>
                            <small class="fa fa-star text-primary"></small>
                            <small class="fa fa-star text-primary"></small>
                            <small class="fa fa-star text-primary"></small>
                        </div>
                    </div>
                    <div class="d-flex mb-3">
                        <small class="border-end me-3 pe-3"><i class="fa fa-bed text-primary me-2"></i>${ item.bedCount} Yatak</small>
                        <small class="border-end me-3 pe-3"><i class="fa fa-bed text-primary me-2"></i>${ item.categoryName} Kategori</small>
                        <small class="border-end me-3 pe-3"><i class="fa fa-bath text-primary me-2"></i>${ item.bathCount} Banyo</small>
                        <small><i class="fa fa-wifi text-primary me-2"></i>Wifi</small>
                    </div>
                            <p class="text-body mb-3">${item.description}</p>
                            <div class="d-flex justify-content-between">
                        <a class="btn btn-sm btn-primary rounded py-2 px-4" href="/Booking/Index/">Detayları Gör</a>
                        <a class="btn btn-sm btn-dark rounded py-2 px-4" href="/Booking/Index/">Rezervasyon Yap</a>
                    </div>
                </div>
            </div>
        </div>
        `;
        roomList.append(roomItem);
    });
}

                      