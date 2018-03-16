$(function (){
    'use strict';
    // Tab
    // ================================
    // if( $('.content-tab').length > 0){
    //     $('.content-tab').hide();
    //     $('ul.header-tab li:first').addClass('active').show();
    //     $('.content-tab:first').show();
    //     $('ul.header-tab li').click(function() {
    //         $('ul.header-tab li').removeClass('active');
    //         $(this).addClass('active');
    //         $('.content-tab').hide();
    //         var activeTab = $(this).find('a').attr('href');
    //         $(activeTab).fadeIn();
    //         return false;
    //     });
    // }
    // Toggle Menu
    // ================================
    var html = $('html, body'),
        navContainer = $('.nav-container'),
        navToggle = $('.nav-toggle'),
        navDropdownToggle = $('.has-dropdown'),
        fixedHeader = $('#header');
    // Nav toggle
    navToggle.on('click', function(e) {
        var $this = $(this);
        e.preventDefault();
        $this.toggleClass('is-active');
        navContainer.toggleClass('is-visible');
        html.toggleClass('nav-open');
        fixedHeader.toggleClass('fixed');
    });

    // Nav dropdown toggle
    navDropdownToggle.on('click', function() {
        var $this = $(this);
        $this.toggleClass('is-active').children('ul').toggleClass('is-visible');
    });
   
    // Toggle Menu
    // ================================
    $('#search-form').hide();
    $('.search-toggle').click(function() {
        $('.search-toggle').toggleClass('hover');
        $('#search-form').slideToggle();
    });

    var prDropDownMenu = $('#dropdownMenuPr').parent();
    prDropDownMenu.find('a').click(function() {
        prDropDownMenu.find('.dd-text').html('');
        prDropDownMenu.find('.dd-text').html($(this).html());
    });
});
