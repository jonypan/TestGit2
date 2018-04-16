$('.swiper-slide').click(function () {
    $('.swiper-slide').each(function () {
        if ($(this).hasClass('swiper-slide-active')) {
            $(this).removeClass('swiper-slide-active');
        }
    });
    $(this).addClass('swiper-slide-active');
    var year = $(this).attr('data-id');
    loadListShareHolders(year);
});

//$('.swiper-button-next').click(function(){
//    var year = '';
//    $('.swiper-slide').each(function() {
//        if ($(this).hasClass('swiper-slide-active')) {
//            year = $(this).after().after().attr('data-id');
//            loadListShareHolders(year);
//        }
//    });
//});
//
//$('.swiper-button-prev').click(function(){
//    var year = '';
//    $('.swiper-slide').each(function() {
//        if ($(this).hasClass('swiper-slide-active')) {
//            year = $(this).next().attr('data-id');
//            loadListShareHolders(year);
//        }
//    });
//});

function loadListShareHolders(year) {
    $('.list-share-holders').empty();
    $('.list-share-holders').append('<div class="loading-img"></div>');

    $.ajax({
        url: loadShareHolderUrl,
        dataType: 'html',
        type: 'post',
        data: {
            year: year
        },
        success: function (result) {
            $('.list-share-holders').empty();
            $('.list-share-holders').append(result);
        }
    });
}

/**
 * Event close popup
 * @param {type} param1
 * @param {type} param2
 */
$('#ModalGallery').on('hidden.bs.modal', function () {
    $('#ModalGallery .modal-body').empty();
});

/**
 * Event close popup
 * @param {type} param1
 * @param {type} param2
 */
$('#ModalView').on('hidden.bs.modal', function () {
    $('#ModalView .modal-body').empty();
});

/**
 * Load list gallery to popup
 * @param {type} param1
 * @param {type} param2
 * @param {type} param3
 */
$('.gallery_popup').on('click', function () {
    var galleryId = $(this).attr('data-id');
    $('#ModalGallery .modal-body').empty();
    $('#ModalGallery .modal-body').append('<p align="center"><img src="' + assetsUrl + '/custom/loading.gif" /></p>');

    $.ajax({
        async: false,
        url: loadGalleryUrl,
        dataType: 'json',
        type: 'post',
        data: {
            galleryId: galleryId
        },
        success: function (json) {
            if (json.status === true) {
                $('#ModalGallery .modal-body').empty();
                $('#ModalGallery .modal-body').append('<div id="fotorama" class="fotorama">');
                if (json.data.gallery) {
                    if (json.data.gallery.type_id == 1) { // Gallery images
                        if (json.data.gallery_items) {
                            $.each(json.data.gallery_items, function () {
                                var item = this;
                                $('#ModalGallery .fotorama').append('<img src="' + item.image + '" data-caption="' + item.name + '" alt="' + item.name + '" />');
                            });
                        }
                    } else { // Gallery videos
                        if (json.data.gallery_items) {
                            $.each(json.data.gallery_items, function () {
                                var item = this;
                                $('#ModalGallery .fotorama').append('<a href="' + item.source + '" data-img="' + item.image + '" data-caption="' + item.name + '"></a>');
                            });
                        }
                    }
                }
                $('#ModalGallery .modal-body').append('</div>');
            } else {
                $('#ModalGallery .modal-body').empty();
                $('#ModalGallery .modal-body').append('<p align="center">' + json.message + '</p>');
            }
        }
    });
});

/**
 * Load agency's info to popup
 * @param {type} agencyId
 * @returns {undefined}
 */
function loadPopupAgency(agencyId) {
    $('#ModalView').modal({backdrop: 'static', keyboard: false});
    $('#ModalView .modal-body').empty();
    $('#ModalView .modal-body').append('<p align="center"><img src="' + assetsUrl + '/custom/loading.gif" /></p>');

    $.ajax({
        async: false,
        url: loadAgencyUrl,
        dataType: 'json',
        type: 'post',
        data: {
            agencyId: agencyId
        },
        success: function (json) {
            if (json.status === true) {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('\
                    <div class="modal-view branch-view">\
                        <div class="row">\
                            <div class="col-md-7">\
                                <div class="modal-view-img"><img src="' + json.data.image + '" alt="' + json.data.name + '" /></div>\
                            </div>\
                            <div class="col-md-5">\
                                <div class="modal-view-content">\
                                    <div class="branch-title">' + json.data.name + '</div>\
                                    <div class="maincontent">\
                                        <p class="p-icon"><i class="fa fa-home"></i>' + json.data.address + '</p>\
                                        <p class="p-icon"><i class="fa fa-phone"></i>' + json.data.phone + ' |  ' + json.data.hotline + '</p>\
                                        <p>Chủ đại lý:</p>\
                                        <p class="branch-name">' + json.data.director + '</p>\
                                    </div>\
                                </div>\
                            </div>\
                        </div>\
                    </div>'
                        );
            } else {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('<p align="center">' + json.message + '</p>');
            }
        }
    });
}
/**
 * Load branch's info to popup
 * @param {type} branchId
 * @returns {undefined}
 */
function loadPopupBranch(branchId) {
    $('#ModalView').modal({backdrop: 'static', keyboard: false});
    $('#ModalView .modal-body').empty();
    $('#ModalView .modal-body').append('<p align="center"><img src="' + assetsUrl + '/custom/loading.gif" /></p>');

    $.ajax({
        async: false,
        url: loadBranchUrl,
        dataType: 'json',
        type: 'post',
        data: {
            branchId: branchId
        },
        success: function (json) {
            if (json.status === true) {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('\
                    <div class="modal-view branch-view">\
                        <div class="row">\
                            <div class="col-md-7">\
                                <div class="modal-view-img"><img src="' + json.data.image + '" alt="' + json.data.name + '" /></div>\
                            </div>\
                            <div class="col-md-5">\
                                <div class="modal-view-content">\
                                    <div class="branch-title">' + json.data.name + '</div>\
                                    <div class="maincontent">\
                                        <p class="p-icon"><i class="fa fa-home"></i>' + json.data.address + '</p>\
                                        <p class="p-icon"><i class="fa fa-phone"></i>' + json.data.phone + ' |  ' + json.data.hotline + '</p>\
                                        <p>Giám đốc chi nhánh:</p>\
                                        <p class="branch-name">' + json.data.director + '</p>\
                                    </div>\
                                </div>\
                            </div>\
                        </div>\
                    </div>'
                        );
            } else {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('<p align="center">' + json.message + '</p>');
            }
        }
    });
}

/**
 * Load staff's info to popup
 * @param {type} staffId
 * @returns {undefined}
 */
function loadPopupStaff(staffId) {
    $('#ModalView').modal({backdrop: 'static', keyboard: false});
    $('#ModalView .modal-body').empty();
    $('#ModalView .modal-body').append('<p align="center"><img src="' + assetsUrl + '/custom/loading.gif" /></p>');

    $.ajax({
        async: false,
        url: loadStaffUrl,
        dataType: 'json',
        type: 'post',
        data: {
            staffId: staffId
        },
        success: function (json) {
            if (json.status === true) {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('\
                    <div class="modal-view leaders-view">\
                        <div class="row">\
                            <div class="col-md-6">\
                                <div class="modal-view-img"><img src="' + json.data.image + '" alt="' + json.data.name + '" /></div>\
                            </div>\
                            <div class="col-md-6">\
                                <div class="modal-view-content">\
                                    <div class="leaders-title">' + json.data.name + '</div>\
                                    <div class="leaders-desc">' + json.data.regency_name + '</div>\
                                    <div class="maincontent">' + json.data.description + '</div>\
                                </div>\
                            </div>\
                        </div>\
                    </div>'
                        );
            } else {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('<p align="center">' + json.message + '</p>');
            }
        }
    });
}

/**
 * Load prize's info to popup
 * @param {type} prizeId
 * @returns {undefined}
 */
function loadPopupPrize(prizeId) {
    $('#ModalView').modal({backdrop: 'static', keyboard: false});
    $('#ModalView .modal-body').empty();
    $('#ModalView .modal-body').append('<p align="center"><img src="' + assetsUrl + '/custom/loading.gif" /></p>');

    $.ajax({
        async: false,
        url: loadPrizeUrl,
        dataType: 'json',
        type: 'post',
        data: {
            prizeId: prizeId
        },
        success: function (json) {
            if (json.status === true) {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('\
                    <div class="modal-view prize-view">\
                        <div class="row">\
                            <div class="col-md-6">\
                                <div class="modal-view-img"><img src="' + uploadUrl + json.data.image + '" alt="' + json.data.name + '" /></div>\
                            </div>\
                            <div class="col-md-6">\
                                <div class="modal-view-content">\
                                    <div class="prize-title">' + json.data.name + '</div>\
                                    <div class="maincontent">' + json.data.description + '</div>\
                                </div>\
                            </div>\
                        </div>\
                    </div>'
                        );
            } else {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('<p align="center">' + json.message + '</p>');
            }
        }
    });
}

/**
 * Load video's content to popup
 * @param {type} videoId
 * @returns {undefined}
 */
function loadPopupVideo(videoId) {
    $('#ModalView').modal({backdrop: 'static', keyboard: false});
    $('#ModalView .modal-body').empty();
    $('#ModalView .modal-body').append('<p align="center"><img src="' + assetsUrl + '/custom/loading.gif" /></p>');
    $.ajax({
        async: false,
        url: "/home/VideoGetLink",
        dataType: 'json',
        type: 'post',
        data: {
            videoId: videoId
        },
        success: function (json) {
            if (json.status === true) {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('<div id="fotorama" class="fotorama">');
                $('#ModalView .modal-body').append('<iframe width="100%" height="500" src="' + json.source +'" frameborder="0" allowfullscreen></iframe>');
                $('#ModalView .modal-body').append('</div>');
            } else {
                $('#ModalView .modal-body').empty();
                $('#ModalView .modal-body').append('<p align="center">Không thấy video</p>');
            }
        }
    });
}

// Load product categories level 2 when change level1's value
$(document).on('change', '#category_parent', function () {
    var parentId = $(this).val();
    if (parentId != '') {
        window.location = childId;
    }
    /*
     $('#category_child').empty();
     $('#category_child').append('<option value="">Nhóm tác dụng</option>');

     if (parentId != '') {
     if (productCategories) {
     $.each(productCategories, function () {
     var item = this;
     if (item.parent_id == parentId) {
     $('#category_child').append('<option value="' + item.product_category_id + '">' + item.name + '</option>');
     }
     });
     }
     }
     */
});

// Filter products by level2's value
$(document).on('change', '#category_child', function () {
    var childId = $(this).val();
    if (childId != '') {
        window.location = childId;
    }
});

$('.story_of_traphaco').on('click', function () {
    if ($(this).parent().hasClass('active')) {
        console.log($(this).attr('data-route'));
    }
});

// Redirect to pages
function goHistory() {
    //showAlert('history');
    window.location = historyUrl;
}
function goLeader() {
    //showAlert('leader');
    window.location = leaderUrl;
}
function goPrize() {
    //showAlert('prize');
    window.location = prizeUrl;
}
function goVision() {
    //showAlert('vision');
    window.location = visionUrl;
}

/**
 * Frontend login
 * @returns {Boolean}
 */
function frontendLogin() {
    if ($('#username').val() == '') {
        showAlert(please_type_username);
        return false;
    }
    if ($('#password').val() == '') {
        showAlert(please_type_password);
        return false;
    }

    $('.btn-login').hide();
    $('.img-loading').show();

    $.ajax({
        url: loginUrl,
        dataType: 'json',
        type: 'post',
        data: {
            username: $('#username').val(),
            password: $('#password').val()
        },
        success: function (result) {
            $('.btn-login').show();
            $('.img-loading').hide();

            if (result.status === true) {
                setTimeout(function () {
                    window.location = downloadUrl;
                }, 1000);
            } else {
                showAlert(result.message);
            }
        }
    });
}

$('.btn-login').click(function () {
    frontendLogin();
});

$('#password').bind('keypress', function (e) {
    if (e.keyCode === 13) {
        frontendLogin();
        return false;
    }
    return true;
});

/**
 * Search by keyword
 * @param {type} keyword
 * @returns {Boolean}
 */
function search(keyword) {
    if ($('#input_search').val() == '') {
        showAlert(please_type_keyword);
        return false;
    } else {
        if ($('#input_search').val().length < 3) {
            showAlert(keyword_least);
            return false;
        }
    }
    if ($('input[name="rd_search"]:checked').val() == 1) {
        window.location = productUrl + '?name=' + $('#input_search').val();
    } else if ($('input[name="rd_search"]:checked').val() == 2) {
        window.location = newsUrl + '?title=' + $('#input_search').val();
    } else if ($('input[name="rd_search"]:checked').val() == 3) {
        window.location = shareholderUrl + '?title=' + $('#input_search').val();
    }
}
/**
 * Event when click search button
 */
$('.btn-search').click(function () {
    search();
});
/**
 * Event press enter to search
 */
$('#input_search').bind('keypress', function (e) {
    if (e.keyCode === 13) {
        search();
        return false;
    }
    return true;
});

/**
 * Alert message
 * @param {type} message
 * @returns {undefined}
 */
function showAlert(message) {
    bootbox.alert(message);
}

/**
 * Even click to send contact
 */
$(document).on('click', '.btn-send', function () {
    sendContact(false);
});

/**
 * Event when click to product button
 */
$(document).on('click', '.send-product', function () {
    sendContact(true);
});

/**
 * Send contact
 * @returns {Boolean}
 */
function sendContact(requirePhone) {
    var name = '';
    var email = '';
    var phone = '';
    var title = '';
    var content = '';
    var productId = '';

    // Check for title
    if ($('#contactName').val().length === 0) {
        showAlert(please_type_name);
        return false;
    } else {
        name = $('#contactName').val();
    }
    // Check for email
    if ($('#contactEmail').val().length === 0) {
        showAlert(please_type_email);
        return false;
    } else {
        var emailReg = new RegExp(/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$/i);
        if (!emailReg.test($("#contactEmail").val())) {
            showAlert(email_invalid);
            return false;
        }
        email = $("#contactEmail").val();
    }

    // Check for phone
    if (requirePhone === true) {
        if ($('#contactPhone').val() == '') {
            showAlert(please_type_phone);
            return false;
        }
    }
    if ($('#contactPhone').val().length > 0) {
        if (isNaN($('#contactPhone').val())) {
            showAlert(phone_invalid);
            return false;
        } else {
            if ($('#contactPhone').val().length < 10 || $('#contactPhone').val().length > 15) {
                showAlert(phone_range_require);
                return false;
            }
        }
        phone = $('#contactPhone').val();
    }

    // Check for content
    if (requirePhone === true) {
        if ($('#contactTitle').val().length === 0) {
            showAlert(please_type_title);
            return false;
        } else {
            title = $('#contactTitle').val();
        }
    }
    // Title
    title = $('#contactTitle').val();

    // Content
    if ($('#contactContent').val().length === 0) {
        showAlert(please_type_content);
        return false;
    } else {
        content = $('#contactContent').val();
    }
    // Product's id
    if ($('#product_id').val() != '') {
        productId = $('#product_id').val();
    }

    $.ajax({
        url: sendContactUrl,
        dataType: 'json',
        type: 'post',
        data: {
            name: name,
            email: email,
            phone: phone,
            title: title,
            content: content,
            productId: productId
        },
        success: function (result) {
            $('.btn-send').show();
            $('.img-loading').hide();
            showAlert(result.message);
            if (result.status === true) {
                setTimeout(function () {
                    if (requirePhone === true) {
                        $('#contactName').val('');
                        $('#contactEmail').val('');
                        $('#contactPhone').val('');
                        $('#contactTitle').val('');
                        $('#contactContent').val('');
                        location.reload();
                    } else {
                        $('#contactName').val('');
                        $('#contactEmail').val('');
                        $('#contactContent').val('');
                        window.location = contactUrl;
                    }
                }, 2000);
            }
        }
    });
}