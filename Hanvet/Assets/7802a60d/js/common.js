//function count to
var homeCount = function(){
  var viewport = $(window).width();
  if (viewport > 991){
    $('.main-banner-count').one('inview', function (event, visible) {
      if (visible) {
        $('.main-banner-number').countTo({
          speed: 2500,
          refreshInterval: 25,
          formatter: function (value, options) {
            return value.toFixed(options.decimals);
          }
        });
      }
    });
  }
};

//function home counting init
homeCount();

//function set active first slide
function refreshFirstLastVisible(event) {
  var $items = $(event.target).find('.owl-item');
  $items.removeClass('owl-item-first-visible owl-item-last-visible');
  $items.eq(event.item.index).addClass('owl-item-first-visible');
  $items.eq(event.item.index + event.page.size - 1).addClass('owl-item-last-visible');
}

//function set paste ad on mobile
var parserAdsFullScreen = function(){
  var dom_html = "#fck_detail";
  var detail = $(dom_html).children();
  if (detail) {
    var divF = $('<div id="divfirst"></div>');
    var divM = $('<div id="admbackground"></div>');
    var divE = $('<div id="divend"></div>');
    for (var i = 0; i < detail.length; i++) {
      var tmp = $(detail[i]).clone();
      if (i < detail.length / 2) divF.append(tmp);
      else divE.append(tmp)
    }
    $(dom_html).html("").append(divF).append(divM).append(divE)
  }
};

//run add on mobile
$(function(){
  // Run code
  var viewport = $(window).width();
  if (viewport < 768){
    parserAdsFullScreen();
    var ad_content = $('#admbackground_src').html();
    var ad_html = $('#admbackground');
    if (ad_html) {
      ad_html.html(ad_content);
    }
  }
});

$(document).ready(function(){

  //menu scroll
  $(window).scroll(function(){
    var mheight = $('.navigator').height();
    if($(this).scrollTop() > 0){
      $('.navigator').addClass("navigator-fixed");
      $('body').css("padding-top",mheight);
    }
    //if($(this).scrollTop() < mheight){
    //  $('.navigator').removeClass("navigator-fixed");
    //  $('body').css("padding-top","0");
    //}
  });

  //expand menu
  $('.expand-menu').click(function(e) {
    e.preventDefault();
    var menu = $('.menu');
    if (menu.hasClass('menu-tiny')) {
      $(this).removeClass('active');
      menu.removeClass('menu-tiny')
        .slideUp();
      $('.header').addClass('header-mobile');
    } else {
      $(this).addClass('active');
      menu.addClass('menu-tiny')
        .slideDown();
      $('.header').removeClass('header-mobile');
    }
  });
//expand submenu
  $('.menu .btn-submenu').click(function(e) {
    e.preventDefault();
    var grand = $(this).parent().parent();
    var root = $(this).parent().parent().parent();
    if ($(this).hasClass('fa-plus')) {
      $(this).removeClass('fa-plus');
      $(this).addClass('fa-minus');
      $('li.mobile-active > .mega-menu',$(root)).slideUp();
      $('li.mobile-active > a > .btn-submenu',$(root)).removeClass('fa-minus');
      $('li.mobile-active > a > .btn-submenu',$(root)).addClass('fa-plus');
      $('li.mobile-active',$(root)).removeClass('mobile-active').addClass('mobile-hidden');
      $(grand).addClass('mobile-active').removeClass('mobile-hidden');
      $('>.mega-menu',$(grand)).slideDown();
    } else {
      $(this).removeClass('fa-minus');
      $(this).addClass('fa-plus');
      $(grand).removeClass('mobile-active').addClass('mobile-hidden');
      $('>.mega-menu',$(grand)).slideUp();
    }
  });

  //expand menutop
  $('.expand-menutop').click(function(e) {
    e.preventDefault();
    var menuTop = $('.menu-top');
    if (menuTop.hasClass('menu-top-tiny')) {
      $(this).removeClass('active');
      menuTop.removeClass('menu-top-tiny')
        .slideUp();
      $('.navigator-top').addClass('navigator-top-mobile');
    } else {
      $(this).addClass('active');
      menuTop.addClass('menu-top-tiny')
        .slideDown();
      $('.navigator-top').removeClass('navigator-top-mobile');
    }
  });

  //expand search
  $('.expand-search').on('click',function(e){
    var megaSearch = $('.mega-search');
    e.stopPropagation();
    megaSearch.show();
  });
  $('body').click(function(e) {
    var boxSearch = $('.mega-search');
    if (boxSearch.is(':visible') && $(e.target).parents('.mega-search').length == 0){
      boxSearch.hide();
    }
  });

  //searchlist click
  $('.search-list li .radio-inline label').on('click',function(){
      var parent = $(this).parent().parent();
      if(!parent.hasClass('active')){
        $('input',$('.search-list li.active')).attr('checked',false );
        $('.search-list li.active').removeClass('active');
        $('input',$(this)).attr('checked',true);
        parent.addClass('active');
      }
  });

  //heart slider
  var heartslider = $('#heartslider');
  heartslider.owlCarousel({
    items:1,
    loop:true,
    margin:0,
    responsiveClass:false,
    nav:false,
    dots:true,
    autoplay:true,
    autoHeight:false,
    autoplayTimeout:6000,
    autoplaySpeed:1000,
    autoplayHoverPause:false,
    navText:false,
    thumbs: true,
    video:true,
    center:true,
    lazyLoad:true,
    thumbsPrerendered: true,
  });

  // Auto play when load page
  setTimeout(
    function () {
      $(".active .owl-video-play-icon").trigger("click");
    }, 100);

  // Auto play when change slide
  heartslider.on('changed.owl.carousel', function (event) {
    setTimeout(
      function () {
        $(".active .owl-video-play-icon").trigger("click");
      }, 100);
  });

  //when stop video slider next
  heartslider.on('stop.owl.video', function (event) {
    setTimeout(
      function () {
        heartslider.trigger('next.owl.carousel');
      }, 100);
  });

  //banner slider
  $('#bannerslider').owlCarousel({
    items:1,
    loop:true,
    margin:0,
    responsiveClass:false,
    nav:false,
    dots:true,
    autoplay:true,
    autoHeight:true,
    autoplayTimeout:6000,
    autoplaySpeed:1000,
    autoplayHoverPause:false,
    navText:false,
    onInitialize: function (event) {
      if ($('.main-banner .owl-carousel .mb-item').length <= 1) {
        this.settings.loop = false;
      }
    }
  });

  //hn slider
  $('#hnslider').owlCarousel({
    loop:true,
    responsiveClass:true,
    nav:false,
    dots:true,
    autoplay:true,
    autoHeight:false,
    autoplayTimeout:10000,
    autoplayHoverPause:false,
    navText:false,
    responsive:{
      0:{
        items:2,
        margin:10
      },
      481:{
        items:2,
        margin:20
      },
      768:{
        items:3,
        margin:30
      }
    }
  });

  //hn slider
  $('#pdslider').owlCarousel({
      loop: true,
      responsiveClass: true,
      nav: false,
      dots: true,
      autoplay: true,
      autoHeight: false,
      autoplayTimeout: 10000,
      autoplayHoverPause: false,
      navText: false,
      responsive: {
          0: {
              items: 2,
              margin: 10
          },
          481: {
              items: 2,
              margin: 20
          },
          768: {
              items: 3,
              margin: 30
          }
      }
  });
  //news other slider
  $('#newsotherslider').owlCarousel({
    loop:true,
    responsiveClass:true,
    nav:false,
    dots:true,
    autoplay:true,
    autoHeight:false,
    autoplayTimeout:10000,
    autoplayHoverPause:false,
    navText:false,
    responsive:{
      0:{
        items:2,
        margin:10
      },
      768:{
        items:3,
        margin:38
      },
      992:{
        items:4,
        margin:38
      }
    },
    onInitialize: function (event) {
      var viewport = $(window).width();
      if ($('.home-news-slider .grid').length <= 4 && viewport >= 992) {
        this.settings.loop = false;
      }
      if ($('.home-news-slider .grid').length <= 3 && viewport >= 768) {
        this.settings.loop = false;
      }
      if ($('.home-news-slider .grid').length <= 2) {
        this.settings.loop = false;
      }
    }
  });

  //hp slider
  $('#hpslider').owlCarousel({
    items:1,
    loop:true,
    margin:0,
    responsiveClass:false,
    nav:false,
    dots:true,
    autoplay:true,
    autoHeight:false,
    autoplayTimeout:5000,
    autoplaySpeed:1000,
    autoplayHoverPause:true,
    navText:false
  });

  //area point click
  $('.area-point').on('click',function(e){
    e.preventDefault();
    var link = $(this).attr('href');
    console.log(link);
    $('.area-point.active',$('.box-area-map')).removeClass('active');
    $('.box-area-pane',$('.box-area-content')).hide();
    $(this).addClass('active');
    $(link).show();
  });

  //scroll to #feeauto
  $('.scroll-down').click(function (e) {
    e.preventDefault();
    $('html, body').animate({scrollTop: $('.home-news').offset().top}, 800);
  });

  //sidebar banner
  $('#sidebarbanner').owlCarousel({
    items:1,
    loop:true,
    margin:0,
    responsiveClass:false,
    nav:false,
    dots:true,
    autoplay:true,
    autoHeight:false,
    autoplayTimeout:5000,
    autoplaySpeed:1000,
    autoplayHoverPause:true,
    navText:false
  });

  //prize slider
  $('.prize-slider').owlCarousel({
    loop:false,
    responsiveClass:true,
    nav:false,
    dots:true,
    autoplay:false,
    autoHeight:false,
    autoplayTimeout:10000,
    autoplayHoverPause:false,
    navText:false,
    responsive:{
      0:{
        items:2,
        margin:10
      },
      481:{
        items:2,
        margin:20
      },
      768:{
        items:3,
        margin:30
      },
      992:{
        items:4,
        margin:30
      }
    }
  });

  //po slider
  $('#poslider').owlCarousel({
    loop:false,
    responsiveClass:true,
    nav:false,
    dots:true,
    autoplay:false,
    autoHeight:false,
    autoplayTimeout:10000,
    autoplayHoverPause:false,
    navText:false,
    responsive:{
      0:{
        items:2,
        margin:10
      },
      481:{
        items:2,
        margin:20
      },
      768:{
        items:3,
        margin:30
      },
      992:{
        items:4,
        margin:30
      }
    }
  });

  //product content more click
  $('.product-content-more a').on('click',function(e){
    e.preventDefault();
    var parent = $(this).parent();
    var productContentList = $('.product-content-list');
    $('.product-content-item',productContentList).each(function(){
      if(!$(this).hasClass('active')){
        $(this).show();
      }
    });
    parent.hide();
  });

  //image detail click
  $('.product-detail-thumb a').click(function(e) {
    e.preventDefault();
    var parent = $(this).parent();
    var grand = $(this).parent().parent().parent();
    var x = $(this).attr('href');
    $('li',$(grand)).removeClass('active');
    $(parent).addClass('active');
    $('.product-detail-img img').attr('src',x);
  });

  //faq detail
  var faqList = $('.faq-list');
  var faqView = $('.faq-view');
  faqList.find('.faq-item').first().addClass('active');
  faqList.find('.faq-item-content').first().show();
  $('.maincontent',faqView).html(faqList.find('.faq-item-content .maincontent').first().html());
  $('.faq-item .faq-item-title').on('click',function(){
    var parent = $(this).parent();
    var content = $('.faq-item-content .maincontent',parent).html();
    $('.faq-list .faq-item.active .faq-item-content').slideUp();
    $('.faq-list .faq-item.active').removeClass('active');
    $(parent).addClass('active');
    $('.faq-item-content',$(parent)).slideDown();
    $('.maincontent',faqView).html(content);
  });

  // button top
  $(window).scroll(function () {
    if ($(this).scrollTop() > 150) {
      $('.go-top').fadeIn();
    } else {
      $('.go-top').fadeOut();
    }
  });
  $('.go-top').click(function(e){
    e.preventDefault();
    $("html, body").animate({scrollTop: $('body').offset().top}, 700);
  });

  //storyslider
  $('#storyslider').owlCarousel({
    items:1,
    loop:true,
    margin:0,
    responsiveClass:false,
    nav:false,
    dots:false,
    autoplay:true,
    autoHeight:false,
    autoplayTimeout:6000,
    autoplaySpeed:1000,
    autoplayHoverPause:false,
    navText:false,
    thumbs: true,
    thumbsPrerendered: true,
    onInitialize: function (event) {
      if ($('.box-story-content .owl-carousel .box-story-item').length <= 1) {
        this.settings.loop = false;
      }
    }
  });
  //storyslider
  $('#mainslide').owlCarousel({
      items: 1,
      loop: true,
      margin: 0,
      responsiveClass: false,
      nav: false,
      dots: false,
      autoplay: true,
      autoHeight: false,
      autoplayTimeout: 6000,
      autoplaySpeed: 1000,
      autoplayHoverPause: false,
      navText: false,
      thumbs: true,
      thumbsPrerendered: true,
      onInitialize: function (event) {
          if ($('.box-story-content .owl-carousel .box-story-item').length <= 1) {
              this.settings.loop = false;
          }
      }
  });
  //brand tab area map change
  var imgFirst = $('.branch-tabs a[data-toggle="tab"]').first();
  var imgSrcFirst = imgFirst.attr('data-src');
  $('.branch-map img').attr('src',imgSrcFirst);
  $('.branch-tabs a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    var imgSrc = $(this).attr('data-src');
    $('.branch-map img').attr('src',imgSrc);
  });

  //shareholders history more click
  $(document).on('click', '.sh-more a', function(e) {  
    e.preventDefault();
    var shroot = $(this).parent().parent();
    if(shroot.hasClass('active')){
      $('li',shroot).each(function(){
        if(!$(this).hasClass('active')){
          $(this).hide();
        }
      });
      shroot.removeClass('active');
    }else{
      shroot.addClass('active');
      $('li',shroot).each(function(){
        if(!$(this).hasClass('active')){
          $(this).show();
        }
      });
    }
  });

  //s logo slider
  var slogoslider = $('#slogoslider');
  slogoslider.owlCarousel({
    loop:true,
    margin:0,
    responsiveClass:true,
    nav:false,
    dots:false,
    autoplay:true,
    autoHeight:false,
    autoplayTimeout:7000,
    autoplayHoverPause:false,
    navText:false,
    mouseDrag:false,
    touchDrag:false,
    responsive:{
      0:{
        items:2
      },
      768:{
        items:3
      },
      992:{
        items:4
      }
    },
    onInitialized: function (event) {
      refreshFirstLastVisible(event);
      var viewport = $(window).width();
      if ($('.shareholders-logo .sl-item').length <= 4 && viewport >= 992) {
        this.settings.loop = false;
      }
      if ($('.shareholders-logo .sl-item').length <= 3 && viewport >= 768) {
        this.settings.loop = false;
      }
      if ($('.shareholders-logo .sl-item').length <= 2) {
        this.settings.loop = false;
      }
    },
    onChanged: function (event) {
      refreshFirstLastVisible(event);
    }
  });
  var stextslider = $('#stextslider');
  stextslider.owlCarousel({
    loop:true,
    margin:0,
    items:1,
    responsiveClass:true,
    nav:false,
    dots:false,
    autoplay:true,
    autoHeight:false,
    autoplayTimeout:7000,
    autoplayHoverPause:false,
    navText:false,
    mouseDrag:false,
    touchDrag:false,
    onInitialized: function (event) {
      var viewport = $(window).width();
      if ($('.shareholders-text .sl-item-text').length <= 4 && viewport >= 992) {
        this.settings.loop = false;
      }
      if ($('.shareholders-text .sl-item-text').length <= 3 && viewport >= 768) {
        this.settings.loop = false;
      }
      if ($('.shareholders-text .sl-item-text').length <= 2) {
        this.settings.loop = false;
      }
    }
  });
  $('.sl-next').click(function() {
    slogoslider.trigger('next.owl.carousel');
    stextslider.trigger('next.owl.carousel');
  });
  $('.sl-prev').click(function() {
    slogoslider.trigger('prev.owl.carousel');
    stextslider.trigger('prev.owl.carousel');
  });

  //history slider
  var mySwiper = new Swiper ('.sh-slider-outer .swiper-container', {
    // Optional parameters
    direction: 'vertical',
    slidesPerView: 3,
    centeredSlides: true,
    nextButton: '.swiper-button-prev',
    prevButton: '.swiper-button-next',
  });

});

//gallery modal call view and slideshow on modal
var viewID;
var modalGallery = function(id){
  $('#ModalGallery').modal({backdrop: 'static', keyboard: false});
  viewID = id-1;
};
$('#ModalGallery').on('shown.bs.modal', function (e) {
  var $fotoramaDiv = $('#fotorama').fotorama({
    nav: 'thumbs',
    fit: 'scaledown',
    thumbwidth: 180,
    thumbheight: 108,
    thumbmargin: 10,
    maxwidth: '100%',
    width: '100%',
  });
  var fotorama = $fotoramaDiv.data('fotorama');
  fotorama.show(viewID);
});

(function() {
  var viewport = $(window).width();
  if (viewport > 991) {
    $('.history-title').one('inview', function (event, visible) {
      if (visible) {$(this).addClass('animated fadeInUp');}
    });
    $('.history-list .history-item:even').one('inview', function (event, visible) {
      if (visible) {
        $('.history-content',$(this)).addClass('animated delayp4 animated-2s fadeInUp');
        $('.history-year',$(this)).addClass('animated delayp2 animated-2s fadeInRight');
      }
    });
    $('.history-list .history-item:odd').one('inview', function (event, visible) {
      if (visible) {
        $('.history-content',$(this)).addClass('animated delayp4 animated-2s fadeInUp');
        $('.history-year',$(this)).addClass('animated delayp2 animated-2s fadeInLeft');
      }
    });
    $('.history-start').one('inview', function (event, visible) {
      if (visible) {$(this).addClass('animated delayp4 fadeInUp');}
    });
  }
})(jQuery);

